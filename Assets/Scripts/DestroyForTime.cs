using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForTime : MonoBehaviour
{
    public float livetime;    

    void Start()
    {
        Destroy(this.gameObject, livetime);
    }

    
    void Update()
    {
        
    }
}
