using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMovementTeki1 : _TankMovementTeki
{
    public override void tankRunning()
    {
        if (playerObject == null || this == null)
            return;
        tankAgent.destination = GivemeTheFinalDest(playerObject.transform.position, 2.0f, 6.0f);

        tankRunningAudio.clip = tankDrivingAudio;

        if (tankRunningAudio.isPlaying == false)
            tankRunningAudio.Play();
    } 
    void Start()
    {
        tankMovementTekiStart();
    }

    void FixedUpdate()
    {
        tankRunning();
    }
}
