using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestRequests : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        StartCoroutine(GetImages());
    }

    IEnumerator GetImages()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://pixabay.com/get/gd3a77db3eb2b52e0272f1d5e9164753c0ea7826ac9286ef2ffae0ed5be4b2c55c962ad6beb19f9ff60085993e9fee41f_340.jpg");
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
            image.sprite = imgSprite;
        }
    }
}
