using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMovementTeki2 : _TankMovementTeki
{
    public override void tankRunning()
    {
        if (playerObject == null || this == null)
            return;

        float distance = Vector3.Distance(this.transform.position, playerObject.transform.position);
        if (distance > 15.0f)
        {
            this.GetComponent<NavMeshAgent>().enabled = true;
            tankAgent.destination = playerObject.transform.position;
        }
        else if (distance < 15.0f)
        {
            this.transform.forward = playerObject.transform.position - this.transform.position;
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.SendMessage("tankFire", SendMessageOptions.DontRequireReceiver);
        }

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
