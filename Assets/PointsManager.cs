using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointsManager : MonoBehaviour {

    public static int propertypoints = 0;
    public static int killcount = 0;
    Text text;
    void Start () {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        text.text = "剩余点数：" + propertypoints;
	}
}
