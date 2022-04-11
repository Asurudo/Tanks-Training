using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _TankMovement : MonoBehaviour
{
    //行进速度  
    public float tankSpeed;
    //旋转速度
    public float tankAngularSpeeed;


    //空闲时音频
    public AudioClip tankIdleAudio;
    //驾驶时音频
    public AudioClip tankDrivingAudio;
    //真正播放的音频
    protected AudioSource tankRunningAudio;

    //刚体组件
    protected Rigidbody tankRigidbody;

    public abstract void tankRunning();
    protected void tankMovementStart()
    {
        tankRigidbody = this.GetComponent<Rigidbody>();
        tankRunningAudio = this.GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
}
