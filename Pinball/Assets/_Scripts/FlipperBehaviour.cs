using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperBehaviour : MonoBehaviour
{
    Transform initialTrans;
    public bool isLeftFlipper = true;
    JointMotor2D motor;
    HingeJoint2D hinge;
    AudioSource source;
    bool isPlaying = false;
    // Use this for initialization
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        hinge = gameObject.GetComponent<HingeJoint2D>();
        motor = hinge.motor;
        if(isLeftFlipper) // Setting up stereo for each flipper
        {
            source.panStereo = -0.8f;
        }
        else
        {
            source.panStereo = 0.8f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        /* Adding the ability to flip the flippers.
         * My solution to controlling 2 separate game objects at the time was,
         * to give both of them this script and set both of their isLeftFlipper appropriately
         */
        if (isLeftFlipper) 
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                motor.motorSpeed = -500; //Bring left flipper up and play a sound
                hinge.motor = motor;
                if(isPlaying == false)
                {
                    source.Play();
                    isPlaying = true;
                }

            }
            else
            {
                motor.motorSpeed = 500; //Bring left flipper back down and set the sound flag to false
                hinge.motor = motor;
                isPlaying = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                motor.motorSpeed = 500; //Bring right flipper up and play a sound
                hinge.motor = motor;
                if (isPlaying == false)
                {
                    source.Play();
                    isPlaying = true;
                }
            }
            else
            {
                motor.motorSpeed = -500; //Bring right flipper back down and set the sound flag to false
                hinge.motor = motor;
                isPlaying = false;
            }
        }
    }
}
