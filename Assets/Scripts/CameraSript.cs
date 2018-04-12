using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSript : MonoBehaviour {

    public Transform playerCubeTransform;
    public float delaySpeed = 0.01f;
    private Vector3 offset;
    
	void Start () {
        //Abstand Kamera zum Objekt
        offset = transform.position - playerCubeTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerCubeTransform.rotation, Time.time * delaySpeed);
        print("Time: " + Time.time + ", delay: "+ delaySpeed + ", Product of delay: " + (Time.time * delaySpeed));
        transform.position = playerCubeTransform.position + offset;
    }
}
