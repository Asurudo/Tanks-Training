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
        
        //获取敌人与玩家的距离
        float distance = Vector3.Distance(this.transform.position, playerObject.transform.position);
        //如果距离过大，则将目的地坐标设置为玩家位置
        if (distance > 15.0f)
        {
            this.GetComponent<NavMeshAgent>().enabled = true;
            tankAgent.destination = playerObject.transform.position;
        }
        //否则将炮头对准玩家，停下后开火
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
