using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankMovementTeki2 : MonoBehaviour
{
    //行进速度一秒五米    
    public float speed;
    //旋转速度一秒三十度
    public float angularSpeeed;

    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource ad;

    //获取刚体组件
    private Rigidbody rigidbd;

    //获取玩家
    private GameObject playerObject;

    private NavMeshAgent agent;

    //计时器
    private float lastTime;
    private float curTime;

    void Start()
    {
        rigidbd = this.GetComponent<Rigidbody>();
        ad = this.GetComponent<AudioSource>();
        playerObject = GameObject.Find("Tank1");
        agent = GetComponent<NavMeshAgent>();
        curTime = Time.time;
        lastTime = curTime - 2;
    }

    private Vector3 GivemeTheFinalDest(Vector3 oriposition)
    {
        Vector3 rnt = new Vector3(0, 0, 0);
        float r = (float)System.Math.Sqrt(Random.Range(25.0f, 484.0f));
        rnt.x = oriposition.x + r * (float)System.Math.Cos(Random.Range(0, 2 * 3.1415f));
        rnt.z = oriposition.z + r * (float)System.Math.Sin(Random.Range(0, 2 * 3.1415f));
        return rnt;
    }

    void FixedUpdate()
    {
        if (playerObject == null || this == null)
            return;

        if (Vector3.Distance(this.transform.position, playerObject.transform.position) < 15.0f)
        {
            curTime = Time.time;
            if (curTime - lastTime < 2.0)
                return;
            lastTime = Time.time;

            agent.destination = GivemeTheFinalDest(playerObject.transform.position);
            
            int times = 10;
            while (Vector3.Distance(agent.destination, playerObject.transform.position) < Vector3.Distance(agent.destination, this.transform.position) && times > 0)
            {
                agent.destination = GivemeTheFinalDest(playerObject.transform.position);
                times--;
            }
        }
        else if (Vector3.Distance(this.transform.position, playerObject.transform.position) > 17.0f && Vector3.Distance(this.transform.position, playerObject.transform.position) < 22.0f)
        {
            agent.destination = this.transform.position + 0.1f*(playerObject.transform.position - this.transform.position);
        }
        else if (Vector3.Distance(this.transform.position, playerObject.transform.position) > 22.0f)
        {
            agent.destination = playerObject.transform.position;
            //agent.destination = GivemeTheFinalDest(playerObject.transform.position);
        }
        /*
        int times = 5;
        while (Vector3.Distance(agent.destination, playerObject.transform.position) < Vector3.Distance(agent.destination, this.transform.position) && times > 0)
        { 
            agent.destination = GivemeTheFinalDest(playerObject.transform.position); 
            times --;
        }
        */


        ad.clip = drivingAudio;

        if (ad.isPlaying == false)
            ad.Play();
    }

    void Backnow()
    {

    }
}
