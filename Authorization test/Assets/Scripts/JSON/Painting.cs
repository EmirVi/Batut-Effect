using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Painting : MonoBehaviour
{
    public string id;
    public Text textID;

    [Space(10)]
    public string paintingName;
    public Text textName;
    [Space(10)]
    public string paintingAuthor;
    public Text textAuthor;
    [Space(10)]
    public string paint_img;
    public Image imgRef;

    public void LoadALL(string ID, string imgURL, string name, string author)
    {
        StartCoroutine(LoadPaintingInformation(ID, imgURL, name, author));
    }

    IEnumerator LoadPaintingInformation(string ID, string imgURL, string name, string author)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imgURL);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            Sprite imgSprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f), 100);
            imgRef.sprite = imgSprite;
        }

        id = ID;
        paint_img = imgURL;
        paintingName = name;
        paintingAuthor = author;

        textID.text = id;
        textName.text = name;
        textAuthor.text = author;
    }
}