using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class PlayerScriptArduino : MonoBehaviour {

    private SerialPort arduino = new SerialPort("COM4", 9600);
    private string arduinoMessage = "";
    public float movingSpeed = 0.1f;
    public float rotationSpeed = 0.3f;

    private int potValue;
    private int previousPotValue = 0;
    private int redButton;
    private int blueButton;

    // Use this for initialization
    void Start () {
        if (!arduino.IsOpen) {
            arduino.Open();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (arduino.IsOpen){
            arduinoMessage = arduino.ReadLine();
            Debug.Log(arduinoMessage);

            //get the Value of [potentiometer, redButton, blueButton]
            string[] message = arduinoMessage.Split(',');

            //rotation
            if (int.TryParse(message[0], out potValue)) { 
                float rotation = rotationSpeed * Time.deltaTime * 5.86f ;
                if (potValue > previousPotValue)
                {
                    transform.Rotate(0.0f, rotation, 0.0f);
                }
                else if (potValue < previousPotValue)
                {
                    transform.Rotate(0.0f, -rotation, 0.0f);
                }
                else
                {
                    transform.Rotate(0.0f, 0.0f, 0.0f);
                }

                previousPotValue = potValue;
            }

            //moving forward
            if (int.TryParse(message[1], out redButton))
            {
                if (redButton == 1) { 
                    float currZ = transform.position.z;
                    float z = (currZ+ 0.1f)  * movingSpeed;
                    transform.Translate(0.0f, 0.0f, z);
                }
            }

            //jumping
            if (int.TryParse(message[2], out blueButton))
            {
                if (blueButton == 1) { 
                    transform.Translate(0.0f, 1.0f, 0.0f);
                }
            }
            
            

        }
	}

    void OnApplicationQuit()
    {
        // Make sure to close the port in the end
        if (arduino.IsOpen)
            arduino.Close();
    }  
}