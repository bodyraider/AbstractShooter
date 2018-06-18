using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour {
    Image image;
    ItemsInfo itemsinfo;
    public ItemInfo item;
    public Text text;
    public GameObject background;
    GameObject gamemanager;
    Sprite itemimage;
    string pngname;
    public int id;
    public Image mixpanel;
    public Image bagpanel;
    public Item mix1;
    public Item mix2;
    public GameObject bag;
    public GameObject itempanel;
    void Awake () {        	
        
        
    }
    private void Update()
    {
        ShowItemIcon();
        ShowItemLevel();
    }

    void ShowItemIcon()
    {
        if (id != 0)
        {
            image = GetComponent<Image>();
            image.enabled = true;
            item = GetItemInfo();
            pngname = item.icon;
            Texture2D _tex = (Texture2D)Resources.Load(pngname);
            itemimage = Sprite.Create(_tex, new Rect(0.0f, 0.0f, _tex.width, _tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            image.sprite = itemimage;
        }
        if (id == 0)
        {
            image = GetComponent<Image>();
            image.enabled = false;
        }

    }

    void ShowItemLevel()
    {
        Text itemlevel = GetComponentInChildren<Text>();
        if (id != 0)
        {
            
            itemlevel.text = "LV" + id / 100;
        }
        else
            itemlevel.text = "";
    }

    public void ShowItemDes()
    {
        if (id != 0)
        {           
            text.text = item.name + " (LV" + item.id/100 + ')' + '\n' + item.des;
            background.gameObject.SetActive(true);
        }
    }
    public void HideItemDes()
    {
        if (id != 0)
        {
            text.text = item.des;
            background.gameObject.SetActive(false);
        }
    }
    public void TransferItemToMixPanel()
    {
        MixUIController mixUIController = mixpanel.GetComponent<MixUIController>();
        bool isopen = mixUIController.isopen;
        if (id !=0 && isopen)
        {
            if (mix1.id == 0)
            {
                mix1.id = id;
                id = 0;
            }
            else if (mix2.id == 0)
            {
                mix2.id = id;
                id = 0;
            }

        }
    }
    public void FromMixToBag()
    {
        if (id != 0)
        {
            GetItemIntoBag getItemIntoBag = bag.GetComponent<GetItemIntoBag>();
            getItemIntoBag.InsertItemIntoGrid(id);
            id = 0;

        }
    }
    public void FromEquipToBag()
    {       
        BagUIController bagUIController = bagpanel.GetComponent<BagUIController>();
        if (id != 0 && bagUIController.isopen)
        {
            GetItemIntoBag getItemIntoBag = bag.GetComponent<GetItemIntoBag>();
            getItemIntoBag.InsertItemIntoGrid(id);
            id = 0;

        }
    }
    public void SaveItemIdToPanel()
    {
        if (id != 0)
        {
            ItemId itemId = itempanel.GetComponent<ItemId>();
            itemId.id = id;
            itemId.itemtag = this.gameObject.tag;
        }
    }
    public ItemInfo GetItemInfo()
    {
        gamemanager = GameObject.FindGameObjectWithTag("GameManager");
        itemsinfo = gamemanager.GetComponent<ItemsInfo>();
        item = itemsinfo.GetItemInfoById(id);
        return item;
    }

}
