﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    

    [SerializeField] 
    private float minX, maxX;
    
    private Transform player;
    private Vector3 tempPos;
    void Start() => player = GameObject.FindWithTag("Player").transform;
    
    void LateUpdate()
    {
        if (!player)
            return;
            
        tempPos = transform.position;
        tempPos.x = player.position.x;
        
        if (tempPos.x < minX)
            tempPos.x = minX;
        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
