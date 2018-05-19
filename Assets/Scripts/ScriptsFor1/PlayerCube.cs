using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour {
    
    public float rotationSpeed = 100.0f;
    public float movingSpeed = 10.0f;
    private float rotation = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float z = Input.GetAxis("Vertical") * Time.deltaTime * movingSpeed;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float rotation = x * rotationSpeed;
        transform.Translate(0.0f, 0.0f, z);
        transform.Rotate(0.0f, rotation, 0.0f);

    }
}
