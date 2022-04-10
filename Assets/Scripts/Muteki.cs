using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muteki : _dropMono
{ 
    void Start()
    {
        dropMonoStart();
    }

    public void OnTriggerEnter(Collider collider)
    {
        pickUp(collider, "mutekifunc");
    }
}
