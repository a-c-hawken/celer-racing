using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{   
    public void Update()
    {
        transform.Rotate(0, 0.5f, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //add 5 to the money variable
            PlayerPrefs.SetFloat("currentMoney", PlayerPrefs.GetFloat("currentMoney") + 5);
            this.gameObject.SetActive(false);
        }
    }
}
