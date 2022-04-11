using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _TankAttack : MonoBehaviour
{
    //开火位置
    protected Transform tankFirePosition;
    //子弹预制体
    public GameObject shellPrefab;
    public float tankshellSpeed;
    //发射键
    public KeyCode tankFireKey;
    //发射音效
    public AudioClip tankShotAudio;

    //计时器
    private float tankCollisionLastTime;
    private float tankCollisionCurTime;

    //装配返回一个范围区间
    float[] damageRange(float minDamage, float maxDamage)
    {
        float[] damageRange = new float[2];
        damageRange[0] = minDamage; 
        damageRange[1] = maxDamage;
        return damageRange;
    }

    protected void tankAttackStart()
    {
        tankFirePosition = this.transform.Find("tankFirePosition");
    }

    protected void tankCollision(Collider collider)
    {
        //设置碰撞间隔，防止碰撞过于频繁
        tankCollisionCurTime = Time.time;
        if (tankCollisionCurTime - tankCollisionLastTime < 1.0f)
            return;
        tankCollisionLastTime = Time.time;

        //如果是敌人碰撞玩家或者建筑，则敌人受到[10,20]的伤害
        if (collider.tag == "tank" && this.tag != "tank")
            collider.SendMessage("TakeDamage", damageRange(10, 20), SendMessageOptions.DontRequireReceiver);
        //而玩家自己只受到[2,5]的伤害
        else if (collider.tag == "player")
            collider.SendMessage("TakeDamage", damageRange(2, 5), SendMessageOptions.DontRequireReceiver);
        //如果碰到建筑，自身受到[2,5]的伤害
        else if (collider.tag == "building")
            this.GetComponent<TankHealth>().TakeDamage(damageRange(2, 5));
    }

    public abstract void tankFire();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
