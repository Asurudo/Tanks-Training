using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject shellExplositionPrefab;
    public AudioClip shellExplositionAudio;

    //导弹来自哪里，一共有两个可能的值：player与teki，分别代表玩家和敌人
    private string fromWhere;

    public void setFromWhere(string fw)
    {
        fromWhere = fw;
    }

    //装配返回一个范围区间
    float[] damageRange(float minDamage, float maxDamage)
    {
        float[] damageRange = new float[2];
        damageRange[0] = minDamage;
        damageRange[1] = maxDamage;
        return damageRange;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //触发检测
    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(shellExplositionAudio, transform.position);
        GameObject.Instantiate(shellExplositionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);

        //敌人不会被彼此的炮弹伤害到
        if(collider.tag == "player" || fromWhere == "player" && collider.tag == "tank")
        {
            collider.SendMessage("TakeDamage", damageRange(10, 20), SendMessageOptions.DontRequireReceiver);
        }
    }
}
