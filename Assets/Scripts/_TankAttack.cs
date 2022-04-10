using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _TankAttack : MonoBehaviour
{
    /*
         发射相关
                   */
    //开火位置
    protected Transform tankFirePosition;
    //子弹预制体
    public GameObject shellPrefab;
    public float tankshellSpeed;
    //发射键
    public KeyCode tankFireKey;
    //发射音效
    public AudioClip tankShotAudio;

    /*
         碰撞计时器
                   */
    //计时器
    private float tankCollisionLastTime;
    private float tankCollisionCurTime;

    protected void tankAttackStart()
    {
        tankFirePosition = this.transform.Find("tankFirePosition");
    }

    protected void tankCollision(Collider collider)
    {
        tankCollisionCurTime = Time.time;
        if (tankCollisionCurTime - tankCollisionLastTime < 1)
            return;
        tankCollisionLastTime = Time.time;

        float[] message = new float[2];
        message[0] = 10;
        message[1] = 20;

        float[] message2 = new float[2];
        message2[0] = 2;
        message2[1] = 5;

        if (collider.tag == "tank" && this.tag != "tank")
            collider.SendMessage("TakeDamage", message, SendMessageOptions.DontRequireReceiver);
        else if (collider.tag == "player")
            collider.SendMessage("TakeDamage", message2, SendMessageOptions.DontRequireReceiver);
        else if (collider.tag == "building")
            this.GetComponent<TankHealth>().TakeDamage(message2);
    }

    public abstract void tankFire();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
