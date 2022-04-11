using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForTime : MonoBehaviour
{
    public float liveTime;    

    void Start()
    {
        Destroy(this.gameObject, liveTime);
    }

    
    void Update()
    {
        
    }
}
