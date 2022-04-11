using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttackTeki1: _TankAttackTeki
{
    //一类敌人不开炮
    public override void tankFire()
    {
        ;
    }
    void Start()
    {
        tankAttackStart();
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        tankCollision(collider);
    }
}
