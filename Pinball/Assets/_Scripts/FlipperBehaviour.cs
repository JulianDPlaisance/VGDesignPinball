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
        if(isLeftFlipper)
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
        if (isLeftFlipper)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                motor.motorSpeed = -500;
                hinge.motor = motor;
                if(isPlaying == false)
                {
                    source.Play();
                    isPlaying = true;
                }

            }
            else
            {
                motor.motorSpeed = 500;
                hinge.motor = motor;
                isPlaying = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                motor.motorSpeed = 500;
                hinge.motor = motor;
                if (isPlaying == false)
                {
                    source.Play();
                    isPlaying = true;
                }
            }
            else
            {
                motor.motorSpeed = -500;
                hinge.motor = motor;
                isPlaying = false;
            }
        }
    }
}
