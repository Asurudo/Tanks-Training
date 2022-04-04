using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //开火位置
    private Transform FirePosition;
    //子弹预制体
    public GameObject shellPrefab;
    //发射键
    public KeyCode fireKey;
    public float shellSpeed = 10;

    public AudioClip shotAudio;

    //计时器
    private float lastTime;   
    private float curTime;


    void Start()
    {
        FirePosition = transform.Find("FirePosition");
    }

    
    void Update()
    {
        //如果按下按键
        if(Input.GetKeyDown(fireKey))
        {
            AudioSource.PlayClipAtPoint(shotAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, FirePosition.position, FirePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
        }
    }

    //触发检测
    public void OnTriggerEnter(Collider collider)
    {
        curTime = Time.time;
        if(curTime - lastTime < 1)
             return ;
        lastTime = Time.time; 

        float[] message = new float[2];  
        message[0] = 10;  
        message[1] = 20;

        float[] message2 = new float[2];
        message2[0] = 2;
        message2[1] = 5;

        if (collider.tag == "tank" && this.tag != "tank")
        { 
            collider.SendMessage("TakeDamage", message, SendMessageOptions.DontRequireReceiver);
            collider.SendMessage("Backnow");
        }
        if (collider.tag == "player")
        {
            collider.SendMessage("TakeDamage", message2, SendMessageOptions.DontRequireReceiver);
            //this.transform.position -= transform.forward * 1.0f;
        }
        else if (collider.tag == "building")
            this.GetComponent<TankHealth>().TakeDamage(message2);
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "tank" && this.tag != "tank")
            collider.SendMessage("Backnow");
    }
}
