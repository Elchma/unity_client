using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class SendCoordinatePopup : MonoBehaviour
{
    public static SendCoordinatePopup Instance {get; private set; }
    [SerializeField] private TextMeshProUGUI confirmationText;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private GameObject confirmationWindow;
    [SerializeField] private GameObject waitWindow;
    [SerializeField] private GameObject resultWindow;

    private void Awake()
    {
        Instance = this;

        gameObject.SetActive(false);
    }

    public void ShowConfirmationPopup(string coordinates)
    {
        confirmationText.text = "Do you want to send this coordinates ?\n\n" + coordinates;
        gameObject.SetActive(true);
        confirmationWindow.SetActive(true);
    }

    public void Confirmation(bool confirm)
    {
        if (confirm)
        {
            confirmationWindow.SetActive(false);
            waitWindow.SetActive(true);
        }
        else
        {
            ClosePopup();
        }
    }

    public void ShowResults(string text, bool success)
    {
        var match = Regex.Matches(text, "\\\"([^\\\"]+)\\\"");
        if (success)
        {
            resultText.text = "Success !" + "\n" + match[1];
            resultText.color = Color.green;
        }
        else
        {
            if (match.Count > 1)
            {
                resultText.text = "Error on " + match[0] + "\n" + match[1];
            }
            else
            {
                resultText.text = "Timeout";
            }
            resultText.color = Color.red;
        }
        resultWindow.SetActive(true);
        waitWindow.SetActive(false);
    }

    public void ClosePopup()
    {
        confirmationWindow.SetActive(false);
        resultWindow.SetActive(false);
        waitWindow.SetActive(false);
        gameObject.SetActive(false);
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
