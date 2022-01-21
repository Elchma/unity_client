using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SendCoordinatePopup : MonoBehaviour
{
    public static SendCoordinatePopup Instance {get; private set; }
    [SerializeField] private RequestManager requestManager;
    [SerializeField] private TextMeshProUGUI textMeshPro;
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
        textMeshPro.text = "Do you want to send this coordinates ?\n\n" + coordinates;
        gameObject.SetActive(true);
    }

    public void Confirmation(bool confirm)
    {
        if (confirm)
        {
            confirmationWindow.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
