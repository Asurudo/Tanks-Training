using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform playerTransform;

    private Vector3 cameraOffset;
    private Camera mainCamera;

    void Start()
    {
        //获取一开始摄像机的偏移量
        cameraOffset = transform.position - playerTransform.position;
        mainCamera = this.GetComponent<Camera>();
    }

    
    void Update()
    {
        //玩家被销毁
        if(playerTransform == null)
            return ;
        transform.position = playerTransform.position + cameraOffset;
        mainCamera.orthographicSize = 15.0F;
    }
}
