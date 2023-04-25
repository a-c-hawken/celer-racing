using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 movement;
    public Vector3 lastPos;
    public Quaternion lastRot;

    public GameObject car3DModel;

    public float currentSpeed = 0f;
    public float currentCar;
    //These can all be adjusted out and inside of this script
    public float rotationSpeed = 100f;
    //These change depending on the car
    public float speed = 0.5f;
    public float speedReverse = 0.2f;
    public float minSpeed = 0, maxSpeed = 50f;
    //Boundries of the player 
    public float minHeight = -3f, maxHeight = 5f;

    public Dictionary<string, float[]> carStats = new Dictionary<string, float[]>();

    public Text speedText;

    void Start(){
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
        
        currentCar = PlayerPrefs.GetFloat("currentCar");
        if (currentCar == 0)
        {
            currentCar = 1;
            PlayerPrefs.SetFloat("car1", 2);
        }
        //set the car stats to the current car
        speed = carStats["car" + currentCar][0];
        rotationSpeed = carStats["car" + currentCar][1];
        maxSpeed = carStats["car" + currentCar][2]; 
        setColour();
    }
    void Update() {
        //Get WASD/Arrow Keys input and saves it the movement Vector3 variable
        movement.y = Input.GetAxisRaw("Vertical"); 
        movement.x = Input.GetAxisRaw("Horizontal");
        //Rotates the car based on the horizontal input
        transform.Rotate(0f, movement.x * rotationSpeed * Time.deltaTime, 0f);
        //Moves the car forward based on the vertical input
        transform.Translate(0f, 0f, currentSpeed * Time.deltaTime);
    }
    void FixedUpdate()
    {   
        //This is the speed system. It adds speed when the player presses W and removes speed when the player presses S.
        if (movement.y > 0f)
        {
            currentSpeed += speed;
        }
        else if (movement.y == 0f && currentSpeed > 0f)
        {
            currentSpeed -= speed;
        } else if (movement.y == -1f)
        {
            currentSpeed -= speedReverse;
        }else if (movement.y == 0f && currentSpeed < 0f)
        {
            currentSpeed += speedReverse;
        }
        //Clamps the speed between the min and max speed
        currentSpeed = Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
        //Display the speed on the UI
        speedText.text = currentSpeed.ToString("0");
        //If the car goes below the map or too far above, it resets to the last checkpoint
        if (transform.position.y < minHeight || transform.position.y > maxHeight)
        {
            transform.position = lastPos;
            transform.rotation = lastRot;
            currentSpeed = 0f;
            PlayerPrefs.SetFloat("currentMoney", PlayerPrefs.GetFloat("currentMoney") - 10);
        }
        
    }
    //This is called when the player hits a checkpoint and is trigger by another script. 
    public void checkpointTrigger()
    {
        lastPos = transform.position;
        lastRot = transform.rotation;
        lastPos.y += 2f;
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
