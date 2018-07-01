using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour {
    ItemInfo item1info;
    ItemInfo item2info;
    ItemInfo item3info;
    ItemInfo item4info;
    ItemInfo item5info;
    ItemInfo item6info;
    public Image item1;
    public Image item2;
    public Image item3;
    public Image item4;
    public Image item5;
    public Image item6;
    public Text _base_health;
    public Text _base_healthspeed;
    public Text _base_atk;
    public Text _base_atkspeed;
    public Text _base_def;
    public Text _base_power;
    public Text _base_strength;
    public Text _base_quick;
    public Text _item_health;
    public Text _item_healthspeed;
    public Text _item_atk;
    public Text _item_atkspeed;
    public Text _item_def;
    public Text _item_power;
    public Text _item_strength;
    public Text _item_quick;
    public int atk;
    public int atkspeed; //攻速百分制
    public int health;
    public int healspeed;
    public int def;
    public int power;
    public int strength;
    public int quick;
    int base_atk;
    float base_atktime;
    int base_health;
    int base_healspeed;
    int base_def;
    int base_atkspeed;
    int base_power;
    int base_strength;
    int base_quick;
    int item_atk = 0;
    int item_atkspeed = 0;
    int item_health = 0;
    int item_healspeed = 0;
    int item_def = 0;
    int item_power = 0;
    int item_strength = 0;
    int item_quick = 0;

    int get_power = 0;
    int get_strength = 0;
    int get_quick = 0;

    void Awake()
    {
        CalculateAllItemsBuff();
        CalculateBaseProperty();
        CalculateFinalProperty();
        ShowValuesInPanel();
    }
    void Update()
    {
        CalculateAllItemsBuff();
        CalculateBaseProperty();
        CalculateFinalProperty();
        ShowValuesInPanel();
    }

    void CalculateFinalProperty()
    {
        atk = base_atk + item_atk;
        atkspeed = base_atkspeed + item_atkspeed;
        health = base_health + item_health;
        healspeed = base_healspeed + item_healspeed;
        def = base_def + item_def;
        power = base_power + item_power;
        strength = base_strength + item_strength;
        quick = base_quick + item_quick;
    }

    void CalculateBaseProperty()
    {
        //base_XXX是面板里的白字，get_XXX是加点得到的
        base_atk = 100 + 2*get_power;                  //1力量 = 2攻  +10血         
        base_atktime = 100 / (100 + get_quick);
        base_health = 1000 + 20 * get_strength + 10 * get_power;
        base_healspeed = get_quick;                    //1敏捷 = 1%攻速  +1/秒生命恢复
        base_def = get_strength;                       //1体力 = 20血 +1格挡
        base_atkspeed = 100 + get_quick;
        base_power = get_power;
        base_strength = get_strength;
        base_quick = get_quick;
    }

    void CalculateAllItemsBuff()
    {
        item1info = item1.GetComponent<Item>().GetItemInfo();
        item2info = item2.GetComponent<Item>().GetItemInfo();
        item3info = item3.GetComponent<Item>().GetItemInfo();
        item4info = item4.GetComponent<Item>().GetItemInfo();
        item5info = item5.GetComponent<Item>().GetItemInfo();
        item6info = item6.GetComponent<Item>().GetItemInfo();

        item_atk =   item1info.atk + 2 * item1info.power 
                   + item2info.atk + 2 * item2info.power 
                   + item3info.atk + 2 * item3info.power 
                   + item4info.atk + 2 * item4info.power 
                   + item5info.atk + 2 * item5info.power 
                   + item6info.atk + 2 * item6info.power;

        item_atkspeed =   item1info.atkspeed + item1info.quick 
                        + item2info.atkspeed + item2info.quick 
                        + item3info.atkspeed + item3info.quick 
                        + item4info.atkspeed + item4info.quick 
                        + item5info.atkspeed + item5info.quick 
                        + item6info.atkspeed + item6info.quick;

        item_health =     item1info.health + 20 * item1info.strength + 10 * item1info.power
                        + item2info.health + 20 * item2info.strength + 10 * item2info.power
                        + item3info.health + 20 * item3info.strength + 10 * item3info.power
                        + item4info.health + 20 * item4info.strength + 10 * item4info.power
                        + item5info.health + 20 * item5info.strength + 10 * item5info.power
                        + item6info.health + 20 * item6info.strength + 10 * item6info.power;

        item_healspeed =   item1info.healspeed  + item1info.quick
                         + item2info.healspeed  + item2info.quick
                         + item3info.healspeed  + item3info.quick
                         + item4info.healspeed  + item4info.quick
                         + item5info.healspeed  + item5info.quick
                         + item6info.healspeed  + item6info.quick;

        item_def =   item1info.def + item1info.strength
                   + item2info.def + item2info.strength
                   + item3info.def + item3info.strength
                   + item4info.def + item4info.strength
                   + item5info.def + item5info.strength
                   + item6info.def + item6info.strength;
        item_power = item1info.power + item2info.power + item3info.power + item4info.power + item5info.power + item6info.power;
        item_strength = item1info.strength + item2info.strength + item3info.strength + item4info.strength + item5info.strength + item6info.strength;
        item_quick = item1info.quick + item2info.quick + item3info.quick + item4info.quick + item5info.quick + item6info.quick;                
    }
    void ShowValuesInPanel()
    {
        _base_health.text = base_health.ToString();
        _base_healthspeed.text = base_healspeed.ToString();
        _base_atk.text = base_atk.ToString();
        _base_atkspeed.text = base_atkspeed.ToString() + "%";
        _base_def.text = base_def.ToString();
        _base_power.text = base_power.ToString();
        _base_strength.text = base_strength.ToString();
        _base_quick.text = base_quick.ToString();
        _item_health.text = "+" + item_health.ToString();
        _item_healthspeed.text = "+" + item_healspeed.ToString();
        _item_atk.text = "+" + item_atk.ToString();
        _item_atkspeed.text = "+" + item_atkspeed.ToString() + "%";
        _item_def.text = "+" + item_def.ToString();
        _item_power.text = "+" + item_power.ToString();
        _item_strength.text = "+" + item_strength.ToString();
        _item_quick.text = "+" + item_quick.ToString();

    }

    public void PowerUp()
    {
        if (PointsManager.propertypoints > 0)
        {
            get_power++;
            PointsManager.propertypoints--;
        }
    }

    public void StrengthUp()
    {
        if (PointsManager.propertypoints > 0)
        {
            get_strength++;
            PointsManager.propertypoints--;
        }
    }

    public void QuickUp()
    {
        if (PointsManager.propertypoints > 0)
        {
            get_quick++;
            PointsManager.propertypoints--;
        }
    }
}
