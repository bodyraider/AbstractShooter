using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenCol : MonoBehaviour {
    public List<GameObject> enemy = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy.Add(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy.Remove(other.gameObject);
        }
    }
}
