using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttackTeki2 : _TankAttackTeki
{
    private float tankAttackLastTime;
    public float tankAttackGapTime;

    public override void tankFire()
    {
        if (Time.time - tankAttackLastTime < tankAttackGapTime)
            return;

        tankAttackLastTime = Time.time;

        AudioSource.PlayClipAtPoint(tankShotAudio, this.transform.position);
        GameObject go = GameObject.Instantiate(shellPrefab, tankFirePosition.position, tankFirePosition.rotation) as GameObject;
        go.GetComponent<Shell>().fromwhere = 2;
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * tankshellSpeed;
    }
    void Start()
    {
        tankAttackStart();
        tankAttackLastTime = Time.time;
    }

    
    void Update()
    {
        
    }

    //´¥·¢¼ì²â
    public void OnTriggerEnter(Collider collider)
    {
        tankCollision(collider);
    }
}
