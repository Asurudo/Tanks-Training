using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    
    public float HP;
    public GameObject tankExplosion;
    public GameObject drop1;
    public GameObject drop2;
    public AudioClip tankExplosionAudio;

    //血条
    public Slider HPSlider;
    private float HPTotal;

    //获取主控
    private GameObject GM;

    void Start()
    {
        HPTotal = HP;
        GM = GameObject.Find("GameManager");
    }

    
    void Update()
    {
        
    }
    public void TakeDamage(float[] damageBoundary)
    {
        if(HP <= 0)
            return ;
        HP -= Random.Range(damageBoundary[0], damageBoundary[1]);
        HPSlider.value = HP/HPTotal;
        if(HP <= 0)
        {
            AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);

            int chs = Random.RandomRange(0,100);
            if(chs < 30)
                GameObject.Instantiate(drop1, transform.position + Vector3.up, Quaternion.identity);
            else if(chs > 50)
                GameObject.Instantiate(drop2, transform.position + Vector3.up, Quaternion.identity);
            GameObject.Destroy(this.gameObject);
            GM.GetComponent<StageControl>().liveteki--;
        }
    }
}
