using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixUIController : MonoBehaviour {

    public bool isopen = false;
    public void Open()
    {
        if (!isopen)
        {
            this.gameObject.SetActive(true);
            isopen = true;
        }
        else
        {
            this.gameObject.SetActive(false);
            isopen = false;
        }
    }

}
