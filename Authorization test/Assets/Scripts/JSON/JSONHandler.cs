using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class JSONHandler : MonoBehaviour
{
    public string mainUrl = "https://api.npoint.io/9d11d63e4384832b2762";

    [TextArea(10, 20)]
    public string outputJSON;

    public Item outputItem;
    public ItemShop outputShopItem_1;
    public ItemShop outputShopItem_2;

    private void Start()
    {
        StartCoroutine(FromJson());
    }

    void ToJson()
    {
        int[] tmpArray = { 12, 45, 7, 15 };
        ItemParameters itemParameters = new ItemParameters(2, 3, tmpArray);
        Item item = new Item("John", 20, itemParameters);

        outputJSON = JsonUtility.ToJson(item, true);
    }

    IEnumerator FromJson()
    {
        UnityWebRequest www = UnityWebRequest.Get(mainUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            //Convert the JSON to Item class parameters

            // outputItem = (Item)JsonUtility.FromJson(www.downloadHandler.text, typeof(Item));
            // outputJSON = JsonUtility.ToJson(outputItem, true);
            // Debug.Log(www.downloadHandler.text);
            // Debug.Log(outputItem.name);
            // Debug.Log(outputItem.age);

            JSONNode node = JSON.Parse(www.downloadHandler.text);
            JSONNode products = node["products"];
            Debug.Log(products);

            foreach (JSONNode item in products.Children)
            {
                Debug.Log(item);
            }

            for (int i = 0; i < products.Count; i++)
            {
                switch(i)
                {
                    case 0:
                        outputShopItem_1.itemName = products[i]["item_name"].Value;
                        outputShopItem_1.itemShopProperties.itemPrice = float.Parse(products[i]["item_properties"][0]["item_price"].Value, CultureInfo.InvariantCulture);
                        outputShopItem_1.itemShopProperties.itemWeight = int.Parse(products[i]["item_properties"][0]["item_weight"].Value, CultureInfo.InvariantCulture);
                        break;
                    case 1:
                        outputShopItem_2.itemName = products[i]["item_name"].Value;
                        outputShopItem_2.itemShopProperties.itemPrice = float.Parse(products[i]["item_properties"][0]["item_price"].Value, CultureInfo.InvariantCulture);
                        outputShopItem_2.itemShopProperties.itemWeight = int.Parse(products[i]["item_properties"][0]["item_weight"].Value, CultureInfo.InvariantCulture);
                        break;
                }
            }
        }
    }
}
