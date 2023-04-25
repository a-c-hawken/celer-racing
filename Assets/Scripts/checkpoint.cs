using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{   
    public GameObject startTimer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            startTimer.GetComponent<startTimer>().checkpointTrigger();
            this.gameObject.SetActive(false);
        }
    }
    public void setCheckpointActive()
    {
        this.gameObject.SetActive(true);
    }


}
