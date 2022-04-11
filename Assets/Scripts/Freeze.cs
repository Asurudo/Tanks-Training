using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : _dropMono
{
    void Start()
    {
        dropMonoStart();
    }

    public void OnTriggerEnter(Collider collider)
    {
        pickUp(collider, "freezeFunc");
    }
}
