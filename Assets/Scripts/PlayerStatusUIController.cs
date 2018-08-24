using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusUIController : MonoBehaviour {
    public BagUIController BagUIController;
    public bool isopen = false;
    public void Open()
    {
        if (!isopen)
        {
            this.gameObject.SetActive(true);
            isopen = true;
            if (BagUIController.isopen)
            {
                BagUIController.gameObject.SetActive(false);
                BagUIController.isopen = false;
            }
        }
        else
        {
            this.gameObject.SetActive(false);
            isopen = false;
        }
    }

}
