using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack: _TankAttack
{
    public override void tankFire()
    {
        //玩家按下按键开炮
        if (Input.GetKeyDown(tankFireKey))
        {
            AudioSource.PlayClipAtPoint(tankShotAudio, transform.position);
            GameObject shell = GameObject.Instantiate(shellPrefab, tankFirePosition.position, tankFirePosition.rotation) as GameObject;
            shell.GetComponent<Shell>().setFromWhere("player");
            shell.GetComponent<Rigidbody>().velocity = shell.transform.forward * tankshellSpeed;
        }
    }

    void Start()
    {
        tankAttackStart();
    }

    
    void Update()
    {
        tankFire();
    }

    public void OnTriggerEnter(Collider collider)
    {
        tankCollision(collider);
    }
}
