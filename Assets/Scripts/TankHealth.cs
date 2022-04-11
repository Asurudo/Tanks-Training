using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    //此时真实血量
    public float HP;
    //坦克爆炸
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;
    //两个掉落物
    public GameObject drop1;
    public GameObject drop2;
    
    //血条相关变量
    public Slider HPSlider;
    private float HPTotal;

    //主控
    private GameObject GM;

    //概率，返回真假
    private bool inThePercent(float odd)
    {
        float chs = Random.Range(0, 100);
        return odd <= chs;
    }

    public void TakeDamage(float[] damageBoundary)
    {
        if (HP <= 0)
            return;
        HP -= Random.Range(damageBoundary[0], damageBoundary[1]);
        HPSlider.value = HP / HPTotal;
        //血量归零
        if (HP <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);

            //30%的可能性掉1，50%的可能性掉2
            if (inThePercent(30))
                GameObject.Instantiate(drop1, transform.position + Vector3.up, Quaternion.identity);
            else if (inThePercent(72))
                GameObject.Instantiate(drop2, transform.position + Vector3.up, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
            //敌人数量减少
            GM.GetComponent<StageControl>().liveTeki --;
        }
    }

    void Start()
    {
        HPTotal = HP;
        GM = GameObject.Find("GameManager");
    }

    
    void Update()
    {
        
    }
    
}
