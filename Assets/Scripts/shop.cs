using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shop : MonoBehaviour
{
    public float currentCar =1f;
    public float currentCarStatus = 0f;
    public float money = 0f;
    float carUnequip;

    public Dictionary<string, float[]> carStats = new Dictionary<string, float[]>();
    
    public Text carTitle;
    public Text price;
    public Text carStatsText;
    public Text actonText;
    public Text moneyText;

    public GameObject car3DModel;

    // Start is called before the first frame update
    void Start()
    {
        //add the car stats to the dictionary, in the order of car accerlation, rotation speed, top speed
        carStats.Add("car1", new float[] { 0.50f, 100f, 50f});
        carStats.Add("car2", new float[] { 0.43f, 94f, 55f});
        carStats.Add("car3", new float[] { 0.55f, 110f, 48f});
        carStats.Add("car4", new float[] { 0.48f, 98f, 52f});
        carStats.Add("car5", new float[] { 0.47f, 90f, 56f});
        carStats.Add("car6", new float[] { 0.48f, 99f, 51f});
        carStats.Add("car7", new float[] { 0.50f, 100f, 50f});
        carStats.Add("car8", new float[] { 0.43f, 94f, 55f});
        carStats.Add("car9", new float[] { 0.55f, 110f, 54f});
        carStats.Add("car10", new float[] { 0.52f, 105f, 60f});
        
        money = PlayerPrefs.GetFloat("money");
        currentCar = PlayerPrefs.GetFloat("currentCar");
        if (currentCar == 0)
        {
            currentCar = 1;
            PlayerPrefs.SetFloat("car1", 2);
        }
    }
    void Update()
    {
        //display the stats of the current car
        carTitle.text = "Car " + currentCar.ToString();
        price.text = "Price: $" + (currentCar * 1000).ToString();
        moneyText.text = "Bank: $" + money.ToString();
        carStatsText.text = "Acceleration: " + carStats["car" + currentCar.ToString()][0].ToString() + "\n Turning Speed: " + carStats["car" + currentCar.ToString()][1].ToString() + "\nTop Speed: " + carStats["car" + currentCar.ToString()][2].ToString();
        //if the player presses the left arrow key, go to the previous car
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left();
        }
        //if the player presses the right arrow key, go to the next car
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right();
        }
        //current car get current status
        currentCarStatus = PlayerPrefs.GetFloat("car" + currentCar.ToString());
        if (currentCarStatus == 0)
        {
            actonText.text = "Buy";
        }
        else if (currentCarStatus == 1)
        {
            actonText.text = "Equipt";
        }
        else if (currentCarStatus == 2)
        {
            actonText.text = "Equipped";
        }
        setColour();

    }
    public void left()
    {   
    if (currentCar > 1)
        {
            currentCar--;
        }
    }
    public void right()
    {
        if (currentCar < 10)
        {
            currentCar++;
        }
    }

    public void action()
    {
        if (money >= currentCar * 1000)
        {
            if (currentCarStatus == 0)
            {
                money -= currentCar * 1000;
                PlayerPrefs.SetFloat("money", money);
                PlayerPrefs.SetFloat("car" + currentCar.ToString(), 1);
                PlayerPrefs.SetFloat("currentCar", currentCar);
                PlayerPrefs.SetFloat("car0", 1);
            }
            else if (currentCarStatus == 1)
            {
                unequip();
                PlayerPrefs.SetFloat("car" + currentCar.ToString(), 2);
                PlayerPrefs.SetFloat("currentCar", currentCar);
                carUnequip = 1f;
            }
            else
            {
                PlayerPrefs.SetFloat("currentCar", 1);
                PlayerPrefs.SetFloat("car1", 2);
                PlayerPrefs.SetFloat("car" + currentCar.ToString(), 1);
            }
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    public void back()
    {
        PlayerPrefs.SetFloat("money", money);
        SceneManager.LoadScene("mainMenu");
    }
    public void unequip()
    {   
        if (carUnequip < 11f)
        {
            if(PlayerPrefs.GetFloat("car" + carUnequip) == 2)
            {
                PlayerPrefs.SetFloat("car" + carUnequip, 1);
                Debug.Log("unequipped" + carUnequip);
            }
             carUnequip++; 
             unequip();
        }
    }
    void setColour()
    {
        //set car color to the current car, car 1 = black, car 2 = blue, car 3 = green, car 4 = red, car 5 = yellow, car 6 = purple, car 7 = white, car 8 = orange, car 9 = pink, car 10 = gold
        if (currentCar == 1)
        {
            car3DModel.GetComponent<Renderer>().material.color = Color.black;
        }
        else if (currentCar == 2)
        {
            car3DModel.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (currentCar == 3)
        {
            car3DModel.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (currentCar == 4)
        {
            car3DModel.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (currentCar == 5)
        {
            car3DModel.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (currentCar == 6)
        {
            car3DModel.GetComponent<Renderer>().material.color = new Color(0.5f, 0f, 0.5f, 1f);
        }
        else if (currentCar == 7)
        {
            car3DModel.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (currentCar == 8)
        {
            car3DModel.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0f, 1f);
        }
        else if (currentCar == 9)
        {
            car3DModel.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0.5f, 1f);
        }
        else if (currentCar == 10)
        {
            car3DModel.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }
}
