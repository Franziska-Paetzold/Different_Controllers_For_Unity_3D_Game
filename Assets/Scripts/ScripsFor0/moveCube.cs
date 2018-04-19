using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCube : MonoBehaviour {

    private float currZ = 0.0f;
    

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.01f);
    }

    /*

    //used for gameobjects with rifgidbodies
    private void FixedUpdate()
    {
        //moving the cube fowards and backwards
        var counter = 0;
        bool forwardFlag = true;
        if ((counter == 0) & (counter <= 50))
        {
            forwardFlag = true;
            counter++;
            if (counter == 50)
            {
                counter = counter - 51;
                print("Trigger B");
            }
        }
        if (counter < 0)
        {
            forwardFlag = false;
            counter--;
            print("Trigger C");
            if (counter == -50)
            {
                counter = counter + 50;
                print("Trigger D");
            }
        }
        moveForwardsBackwards(forwardFlag);
        print(counter);



    }

    void moveForwardsBackwards(bool flag)
    {
        if (flag == true)
        {
            currZ += 0.01f;
        }
        if (flag == false)
        {
            currZ += -0.01f;

        }
        transform.position += new Vector3(0.0f, 0.0f, currZ);
    }
    */

}
