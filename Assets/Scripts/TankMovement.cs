using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    //行进速度一秒五米    
    public float speed;
    //旋转速度一秒三十度
    public float angularSpeeed;
    //坦克编号
    public float number;

    public AudioClip idleAudio;
    public AudioClip drivingAudio;

    private AudioSource runningaudio;

    //获取刚体组件
    private Rigidbody objrigidbody;

    void Start()
    {
        objrigidbody = this.GetComponent<Rigidbody>();
        runningaudio = this.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //垂直 WS键 v = 1|-1
        float v = Input.GetAxis("Verticalplayer" + number);
        objrigidbody.velocity = transform.forward * v * speed;

        //水平 AD键 h = 1|-1
        float h = Input.GetAxis("Horizontalplayer" + number);
        //水平旋转速度               绕着y轴
        objrigidbody.angularVelocity = transform.up * h * angularSpeeed;

        if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)
            runningaudio.clip = drivingAudio;
        else
            runningaudio.clip = idleAudio;
        if (runningaudio.isPlaying == false)
            runningaudio.Play();

    }
}
