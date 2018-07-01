using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetItemIntoBag : MonoBehaviour {
    public List<Image> ItemList = new List<Image>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X))
        {
            InsertItemIntoGrid(Random.Range(101, 109));
        }
	}

    public void InsertItemIntoGrid(int id)
    {
        foreach (Image item in ItemList)
        {
            Item _item = item.GetComponent<Item>();
            if (_item.id == 0)
            {
                _item.id = id;
                break;
            }
        }
    }
}
