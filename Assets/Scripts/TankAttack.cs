using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack: _TankAttack
{
    public override void tankFire()
    {
        if (Input.GetKeyDown(tankFireKey))
        {
            AudioSource.PlayClipAtPoint(tankShotAudio, transform.position);
            GameObject go = GameObject.Instantiate(shellPrefab, tankFirePosition.position, tankFirePosition.rotation) as GameObject;
            go.GetComponent<Shell>().fromwhere = 1;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * tankshellSpeed;
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
