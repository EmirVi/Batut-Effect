using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class PaintingManager : MonoBehaviour
{
    public string mainURL;

    public List<Painting> scenePaintings = new List<Painting>();

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(mainURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            JSONNode node = JSON.Parse(www.downloadHandler.text);
            JSONNode paintings = node["Paintings"];

            for (int i = 0; i < scenePaintings.Count; i++)
            {
                string paintingID = paintings[i]["painting_id"].Value;
                string paintingURL = paintings[i]["painting_url"].Value;
                string paintingName = paintings[i]["painting_name"].Value;
                string paintingAuthor = paintings[i]["painting_author"].Value;
                scenePaintings[i].LoadALL(paintingID, paintingURL, paintingName, paintingAuthor);
            }
        }
    }
}