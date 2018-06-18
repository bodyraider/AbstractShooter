using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsInfo : MonoBehaviour {

    public static ItemsInfo _instance;
    private Dictionary<int, ItemInfo> itemdictionary = new Dictionary<int, ItemInfo>();

    public TextAsset objInfoList;
    void Awake()
    {
        _instance = this;
        ReadInfo();
        
    }

    public ItemInfo GetItemInfoById(int id)
    {
        ItemInfo info = null;
        itemdictionary.TryGetValue(id, out info);
        return info;
    }

    void ReadInfo()
    {
        string text = objInfoList.text;
        string[] strArray = text.Split('\n');
        foreach (string str in strArray)
        {
            string[] proArray = str.Split(',');
            ItemInfo info = new ItemInfo();


            int id = int.Parse(proArray[0]);
            string name = proArray[1];
            string icon = proArray[2];
            int atk = int.Parse(proArray[3]);
            int atkspeed = int.Parse(proArray[4]);
            int health = int.Parse(proArray[5]);
            int healspeed = int.Parse(proArray[6]);
            int def = int.Parse(proArray[7]);
            int power = int.Parse(proArray[8]);
            int strength = int.Parse(proArray[9]);
            int quick = int.Parse(proArray[10]);
            string des = proArray[11];
            info.id = id;
            info.name = name;
            info.icon = icon;
            info.atk = atk;
            info.atkspeed = atkspeed;
            info.health = health;
            info.healspeed = healspeed;
            info.def = def;
            info.power = power;
            info.strength = strength;
            info.quick = quick;
            info.des = des;
            itemdictionary.Add(info.id, info);

        }
    }

}
public class ItemInfo
{
    public int id;
    public string name;
    public string icon;
    public int atk;
    public int atkspeed;
    public int health;
    public int healspeed;
    public int def;
    public int power;
    public int strength;
    public int quick;
    public string des;
}
