using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class PlayerCubeLM : MonoBehaviour {

    LeapServiceProvider provider;
    public float rotationSpeed = 0.3f;
    public float movingSpeed = 0.3f;

    // Use this for initialization
    void Start()
    {
        provider = FindObjectOfType<LeapServiceProvider>() as LeapServiceProvider;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {

            //jumping
            //TODO: Sprung weniger fehleranfällig machen (in Höhe und Drehung), ggf Abfrage vom letzten frame
            float hight = hand.PalmVelocity.y;
            if (hight >= 0.5f)
            {
                transform.Translate(0.0f, 1.5f, 0.0f);
            }
            else { 

            //rotation
            if (hand.Basis.rotation.ToQuaternion().eulerAngles.z > 200 && hand.Basis.rotation.ToQuaternion().eulerAngles.z < 340)
            {
                //rotation right
                float rotation = hand.Basis.rotation.ToQuaternion().eulerAngles.z * rotationSpeed * Time.deltaTime;
                transform.Rotate(0.0f, rotation, 0.0f);
            }
            else if (hand.Basis.rotation.ToQuaternion().eulerAngles.z > 10 && hand.Basis.rotation.ToQuaternion().eulerAngles.z < 90) {
                //rotation left
                float rotation = hand.Basis.rotation.ToQuaternion().eulerAngles.z * rotationSpeed*4 * Time.deltaTime;
                transform.Rotate(0.0f, -rotation, 0.0f);
            }

            //movement
            if (hand.Basis.rotation.ToQuaternion().eulerAngles.x > 200 && hand.Basis.rotation.ToQuaternion().eulerAngles.x < 340)
            {
                //rotation backwards
                float move = hand.Basis.rotation.ToQuaternion().eulerAngles.x * movingSpeed * Time.deltaTime;
                transform.Translate(0.0f, 0.0f, -move);
            }
            else if (hand.Basis.rotation.ToQuaternion().eulerAngles.x > 10 && hand.Basis.rotation.ToQuaternion().eulerAngles.x < 90)
            {
                ///rotation forewards
                float move = hand.Basis.rotation.ToQuaternion().eulerAngles.x * movingSpeed*4 * Time.deltaTime;
                transform.Translate(0.0f, 0.0f, move);
            }
            }

        }
        
    }

}
