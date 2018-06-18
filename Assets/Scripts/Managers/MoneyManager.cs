using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyManager : MonoBehaviour
{
    public static int money;    //static相当于全局变量


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        money = 0;
    }


    void Update ()
    {
        text.text = money.ToString();
    }
}
