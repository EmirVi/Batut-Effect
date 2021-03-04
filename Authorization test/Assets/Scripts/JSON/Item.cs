using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    // [SerializeField]
    // private string name;
    public string name;
    public int age;
    public ItemParameters itemParameters;


    public Item(string name, int age, ItemParameters itemParameters)
    {
        this.name = name;
        this.age = age;
        this.itemParameters = itemParameters;
    }
}

[System.Serializable]
public class ItemParameters
{
    public int param1;
    public int param2;
    public int[] paramArray;

    public ItemParameters(int param1, int param2, int[] paramArray)
    {
        this.param1 = param1;
        this.param2 = param2;
        this.paramArray = paramArray;
    }
}

[System.Serializable]
public class ItemShop
{
    public string itemName;
    public ItemShopProperties itemShopProperties;
}

[System.Serializable]
public class ItemShopProperties
{
    public float itemPrice;
    public int itemWeight;
}