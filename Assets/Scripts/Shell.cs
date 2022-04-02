using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
        
    public GameObject shellExplositionPrefab;

    public AudioClip shellExplositionAudio;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    //´¥·¢¼ì²â
    public void OnTriggerEnter(Collider collider)
    {
        AudioSource.PlayClipAtPoint(shellExplositionAudio, transform.position);
        GameObject.Instantiate(shellExplositionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);

        if(collider.tag == "tank")
        {
            collider.SendMessage("TakeDamage");
        }
    }
}
