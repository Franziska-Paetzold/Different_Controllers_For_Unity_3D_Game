using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBlueCube : MonoBehaviour {

    public Collider colliderOfYellowCube;

    public Rigidbody ridgidbody;
	// Use this for initialization
	void Start () {
        ridgidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        transform.position += new Vector3(0.0f, 0.0f, -0.01f);
		
	}

    private void FixedUpdate()
    {
       // ridgidbody.collisionDetectionMode();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position += new Vector3(0.0f, 0.0f, -0.01f);
        print("Collider trigger triggered");
    }
}
