using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestManager : MonoBehaviour
{
    public void SendCollisionPoint(Vector3 point)
    {
        SendCoordinatePopup.Instance.ShowConfirmationPopup(point.ToString());
        // StartCoroutine(UploadPoint(point));
    }

    IEnumerator UploadPoint(Vector3 point)
    {
        WWWForm form = new WWWForm();
        form.AddField("x", point.x.ToString().Replace(",", "."));
        form.AddField("y", point.y.ToString().Replace(",", "."));
        form.AddField("z", point.z.ToString().Replace(",", "."));

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/coordinate/", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }

        www.Dispose();
    }
}