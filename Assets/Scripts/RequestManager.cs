using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RequestManager : MonoBehaviour
{
    Vector3 collisionPoint = Vector3.zero;

    public void NewCollisionPoint(Vector3 point)
    {
        collisionPoint = point;
        SendCoordinatePopup.Instance.ShowConfirmationPopup(point.ToString());
    }

    public void SendCollsionPoint()
    {  
        StartCoroutine(UploadPoint(collisionPoint));
    }

    IEnumerator UploadPoint(Vector3 point)
    {
        WWWForm form = new WWWForm();
        form.AddField("x", point.x.ToString().Replace(",", "."));
        form.AddField("y", point.y.ToString().Replace(",", "."));
        form.AddField("z", point.z.ToString().Replace(",", "."));

        UnityWebRequest www = UnityWebRequest.Post("http://127.0.0.1:8000/coordinate/", form);
        www.timeout = 5;
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            SendCoordinatePopup.Instance.ShowResults(www.downloadHandler.text, false);
        }
        else
        {
            SendCoordinatePopup.Instance.ShowResults(www.downloadHandler.text, true);
        }

        www.Dispose();
    }
}