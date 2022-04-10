using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : _TankMovement
{
    public override void tankRunning()
    {
        //垂直 WS键 v = 1|-1
        float v = Input.GetAxis("Vertical");
        tankRigidbody.velocity = transform.forward * v * tankSpeed;

        //水平 AD键 h = 1|-1
        float h = Input.GetAxis("Horizontal");
        //水平旋转速度                   绕着y轴
        tankRigidbody.angularVelocity = transform.up * h * tankAngularSpeeed;

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
            tankRunningAudio.clip = tankDrivingAudio;
        else
            tankRunningAudio.clip = tankIdleAudio;
        if (tankRunningAudio.isPlaying == false)
            tankRunningAudio.Play();
    }

    void Start()
    {
        tankMovementStart();
    }

    void FixedUpdate()
    {
        tankRunning();
    }
}
