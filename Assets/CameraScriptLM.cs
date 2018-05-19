using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptLM : MonoBehaviour
{

    public GameObject playerCube;
    public float delaySpeed = 0.05f;
    private Vector3 offset;
    private Quaternion previousRotation;

    // Use this for initialization
    void Start()
    {
        //Abstand Kamera zum Objekt
        offset = transform.position - playerCube.transform.position;
        //offset = new Vector3 (0.0f, 1.0f, -5.0f);

        //for creating a smooth slerp
        previousRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = playerCube.transform.position + offset;

        Quaternion targetRotation = Quaternion.Slerp(previousRotation, playerCube.transform.rotation, delaySpeed);

        //product of Quaternion and Vector3 is Vector3 --> Matrizenmultiplikation!
        Vector3 targetRotated = targetRotation * offset;

        transform.position = playerCube.transform.position + targetRotated;
        transform.rotation = targetRotation;

        previousRotation = transform.rotation;
    }
}
