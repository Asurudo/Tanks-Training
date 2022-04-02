using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    
    public Transform player1;
    public Transform player2;

    private Vector3 offset;
    private Camera camera;

    void Start()
    {
        offset = transform.position - (player1.position + player2.position)/2;
        camera = this.GetComponent<Camera>();
    }

    
    void Update()
    {
        //一方被销毁
        if(player1 == null || player2 == null)
            return ;
        transform.position = (player1.position + player2.position) / 2 + offset;
        float distance = Vector3.Distance(player1.position, player2.position);
        float size = distance*0.88f;
        camera.orthographicSize = size;
    }
}
