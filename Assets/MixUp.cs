using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixUp : MonoBehaviour {
    public Image item1;
    public Image item2;
    public GameObject bag;

    public void MixUpTwoItems()
    {
        int output;
        Item _item1 = item1.GetComponent<Item>();
        Item _item2 = item2.GetComponent<Item>();
        GetItemIntoBag getItemIntoBag = bag.GetComponent<GetItemIntoBag>();
        int id1 = _item1.id;
        int id2 = _item2.id;
        if (id1 / 100 == id2 / 100 && id1 != 0 && id2 != 0)
        {
            output = (id1 / 100 + 1) * 100 + Random.Range(1, 10);
            getItemIntoBag.InsertItemIntoGrid(output);
            _item1.id = 0;
            _item2.id = 0;

        }



    }
}
