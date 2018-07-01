using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bet : MonoBehaviour {
    public GameObject bag;
    public int prize = 10;
	public void Gamble()
    {
        if (MoneyManager.money >= prize)
        {
            MoneyManager.money -= prize;
            GetItemIntoBag getItemIntoBag = bag.GetComponent<GetItemIntoBag>();
            getItemIntoBag.InsertItemIntoGrid(Random.Range(101, 109));
        }
    }
}
