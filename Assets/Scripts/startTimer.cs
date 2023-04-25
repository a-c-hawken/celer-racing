using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startTimer : MonoBehaviour
{
    public float timer = 0f; 
    public float start = 0f;
    public float[] times;
    public float checkpoint = 0f; 
    public float checkpointCnt = 3f; 
    private float pauseStart = 0f;
    public float currentTrack;
    public float bestTime;

    public Text timerText;
    public Text finalTimes;
    public Text currentLap;
    public Text money;

    public GameObject player;
    public GameObject[] checkpoints;
    public GameObject finishUI;

    public bool paused = false;

    public GameObject[] coins;

    void Start()
    {
        times = new float[4];
        //find object with tag "checkpoint"
        checkpoints = GameObject.FindGameObjectsWithTag("checkpoint");
        finishUI.SetActive(false);
        coins = GameObject.FindGameObjectsWithTag("coin");
        PlayerPrefs.SetFloat("currentMoney", 0f);
        currentTrack = PlayerPrefs.GetFloat("currentlyLoadedTrack");
        bestTime = PlayerPrefs.GetFloat("bestTime" + currentTrack.ToString());
    }
    void Update()
    {   
        //Pause/Unpause using the escape key 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused == false)
            {
                pause();
                paused = true;
            }
            else
            {
                resume();
                paused = false;
            }
        }
        //Display current lap
        currentLap.text = "Lap: " + start.ToString("0");
        money.text = "$" + PlayerPrefs.GetFloat("currentMoney").ToString("0");
    }
    void FixedUpdate()
    {
        if (start > 0f)
        {   
            timer += Time.deltaTime;
        }
        if (start == 4f)
        {
            start = 0f;
            //Total Time
            times[3] = times[0] + times[1] + times[2];
            //Display Times
            finishUI.SetActive(true);
            finalTimes.text = "Lap 1: " + times[0].ToString("0.00" + "s") + "\nLap 2: " + times[1].ToString("0.00" + "s") + "\nLap 3: " + times[2].ToString("0.00" + "s") + "\nTotal Time: " + times[3].ToString("0.00" + "s");
            PlayerPrefs.SetFloat("totalTimeT1", times[3]);
            if(times[3] > bestTime)
            {
                PlayerPrefs.SetFloat("bestTime" + currentTrack.ToString(), times[3]);
            }
            this.gameObject.SetActive(false);
            PlayerPrefs.SetFloat("money", PlayerPrefs.GetFloat("money") + PlayerPrefs.GetFloat("currentMoney"));
        }
        timerText.text = timer.ToString("0.00" + "s");
        float money = PlayerPrefs.GetFloat("currentMoney");
    }
    //On collision with the player.
    void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.tag == "Player"){
            if (start == 0f){
                timer = 0f;
                start = 1f;
            }else if (checkpoint > checkpointCnt){
                //Save Time
                times[(int)start -1] = timer;          
                start += 1f;
                timer = 0f;
                checkpoint = 0f;
                //Reset Checkpoints
                foreach (GameObject checkpoint in checkpoints)
                {
                    checkpoint.GetComponent<checkpoint>().setCheckpointActive();
                }
                foreach (GameObject coin in coins)
                {
                    coin.SetActive(true);
                }
            }
            player.GetComponent<playerMovement>().checkpointTrigger();
        }
    }
    //Called from checkpoint.cs
    public void checkpointTrigger()
    {
        checkpoint += 1f;
        player.GetComponent<playerMovement>().checkpointTrigger();
    }
    //Pause/Unpause
    public void pause()
    {
        pauseStart = start;
        start = 0f;
        finishUI.SetActive(true);        
    }
    public void resume()
    {
        start = pauseStart;
        finishUI.SetActive(false);
    }
    
    
}
