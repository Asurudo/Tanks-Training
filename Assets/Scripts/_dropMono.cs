using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class _dropMono : MonoBehaviour
{
    //获取主控
    private GameObject GM;

    protected void dropMonoStart()
    {
        GM = GameObject.Find("GameManager");
    }
    
    //如果碰撞的是玩家，则捡起物品
    protected void pickUp(Collider collider, string callBackFunc)
    {
        if (collider.tag == "player")
        {
            GM.SendMessage(callBackFunc, SendMessageOptions.DontRequireReceiver);
            GameObject.Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
