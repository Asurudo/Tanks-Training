using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class _TankMovementTeki : _TankMovement
{
    //玩家
    protected GameObject playerObject;
    
    //自动寻路
    protected NavMeshAgent tankAgent;

    //索敌函数，传入位置(x,y,z)，返回平面上位置半径内圆一点
    protected Vector3 GivemeTheFinalDest(Vector3 oriposition, float minR, float maxR)
    {
        Vector3 rnt = new Vector3(0, 0, 0);
        float r = (float)System.Math.Sqrt(Random.Range(minR * minR, maxR * maxR));
        rnt.x = oriposition.x + r * (float)System.Math.Cos(Random.Range(0, 2 * 3.1415f));
        rnt.z = oriposition.z + r * (float)System.Math.Sin(Random.Range(0, 2 * 3.1415f));
        return rnt;
    }

    protected void tankMovementTekiStart()
    {
        tankRigidbody = this.GetComponent<Rigidbody>();
        tankRunningAudio = this.GetComponent<AudioSource>();
        playerObject = GameObject.Find("Tank1");
        tankAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
