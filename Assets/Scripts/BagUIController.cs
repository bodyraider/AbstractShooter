using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUIController : MonoBehaviour {
    public bool isopen = false;
    public PlayerStatusUIController PlayerStatusUIController;
	public void Open()
    {
        if (!isopen)
        {
            this.gameObject.SetActive(true);
            isopen = true;
            if (PlayerStatusUIController.isopen)
            {
                PlayerStatusUIController.gameObject.SetActive(false);
                PlayerStatusUIController.isopen = false;
            }
        }
        else
        {
            this.gameObject.SetActive(false);
            isopen = false;
        }
    }
  
}
