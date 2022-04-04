using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    
    public Transform player;

    private Vector3 offset;
    private Camera cam;

    void Start()
    {
        offset = transform.position - player.position;
        cam = this.GetComponent<Camera>();
    }

    
    void Update()
    {
        //一方被销毁
        if(player == null)
            return ;
        transform.position = player.position  + offset;
        cam.orthographicSize = 15.0F;
    }
}
