using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemId : MonoBehaviour {

    public int id;
    public string itemtag;
    public Item equip1;
    public Item equip2;
    public Item equip3;
    public Item equip4;
    public Item equip5;
    public Item equip6;
    public void TransferToEquip()
    {
        if (id != 0)
        {
            GameObject item = GameObject.FindGameObjectWithTag(itemtag);
            Item bagitem = item.GetComponent<Item>();
            if (equip1.id == 0)
            {
                equip1.id = id;
                id = 0;
                bagitem.id = 0;

            }
            else if (equip2.id == 0)
            {
                equip2.id = id;
                id = 0;
                bagitem.id = 0;

            }
            else if (equip3.id == 0)
            {
                equip3.id = id;
                id = 0;
                bagitem.id = 0;

            }
            else if (equip4.id == 0)
            {
                equip4.id = id;
                id = 0;
                bagitem.id = 0;

            }
            else if (equip5.id == 0)
            {
                equip5.id = id;
                id = 0;
                bagitem.id = 0;

            }
            else if (equip6.id == 0)
            {
                equip6.id = id;
                id = 0;
                bagitem.id = 0;

            }

        }
    }
}
