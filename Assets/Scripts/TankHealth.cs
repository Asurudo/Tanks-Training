using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    
    public float HP;
    public GameObject tankExplosion;
    public AudioClip tankExplosionAudio;

    //ÑªÌõ
    public Slider HPSlider;
    private float HPTotal;

    void Start()
    {
        HPTotal = HP;
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
            GameObject.Destroy(this.gameObject);
        }
    }
}
