using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSript : MonoBehaviour {

    public GameObject playerCube;
    public float delaySpeed = 0.05f;
    private Vector3 offset;
    private Quaternion previousRotation;

    void Start () {
        //Abstand Kamera zum Objekt
            offset = transform.position - playerCube.transform.position;
        //offset = new Vector3 (0.0f, 1.0f, -5.0f);

        //for creating a smooth slerp
        previousRotation = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        //transform.position = playerCube.transform.position + offset;
        
        Quaternion targetRotation = Quaternion.Slerp(previousRotation, playerCube.transform.rotation, delaySpeed);
        
        //product of Quaternion and Vector3 is Vector3 --> Matrizenmultiplikation!
        Vector3 targetRotated = targetRotation * offset;

        transform.position = playerCube.transform.position + targetRotated;
        transform.rotation = targetRotation;

        previousRotation = transform.rotation;
    }
}

//Ergebnis immer noch falsch
/*
  public GameObject playerCube;
    public float delaySpeed = 0.05f;
    private Vector3 offset;

    //Todo: HardCode, should be the same as in PlayerCube
    private float rotationSpeed = 10.0f;

    void Start () {
        //Abstand Kamera zum Objekt
        offset = transform.position - playerCube.transform.position;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = playerCube.transform.position + offset;

        //Todo: code redundancy from PlayerCube.cs
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float rotation = x * rotationSpeed;
        transform.Rotate(0.0f, rotation, 0.0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, playerCube.transform.rotation, Time.deltaTime*delaySpeed);
    }
}
 * /

    //es gibt angeblich kein rotation
/*
 public GameObject playerCube;
    public float delaySpeed = 0.05f;
    private Vector3 offset;
    private PlayerCube playerCubeScript;

    void Start () {
        //Abstand Kamera zum Objekt
        offset = transform.position - playerCube.transform.position;
        
        PlayerCube playerCubeScript = transform.GetComponent<PlayerCube>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = playerCube.transform.position + offset;
        transform.Rotate(0.0f, playerCubeScript.rotation, 0.0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerCube.transform.rotation, Time.deltaTime*delaySpeed);
    }
}

*/


//NullReferenceException: Object reference not set to an instance of an object
/*
    public GameObject playerCube;
    public float delaySpeed = 0.05f;
    private Vector3 offset;

    private PlayerCube playerCubeScript;

    void Start () {
        //Abstand Kamera zum Objekt
        offset = transform.position - playerCube.transform.position;

        playerCube = GameObject.Find("PlayerCube");
        PlayerCube playerCubeScript = playerCube.GetComponent<PlayerCube>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = playerCube.transform.position + offset;


        //rotate the offset like the cube
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float rotation = x * playerCubeScript.rotationSpeed;
        transform.Rotate(0.0f, rotation, 0.0f);

        //transform.Rotate(0.0f, playerCubeScript.rotation, 0.0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerCube.transform.rotation, Time.deltaTime*delaySpeed);
    }
}

    */
