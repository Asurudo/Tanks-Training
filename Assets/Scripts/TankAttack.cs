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
}
