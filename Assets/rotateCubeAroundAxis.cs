using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCubeAroundAxis : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float rotation = x * 10.0f;
        
        transform.position += new Vector3(Mathf.Cos(rotation), Mathf.Cos(rotation), 0.01f);
    }
}
