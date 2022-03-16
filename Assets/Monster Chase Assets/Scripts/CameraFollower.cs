using System;
using UnityEngine;
using static UnityEngine.Screen;

namespace Monster_Chase_Assets.Scripts
{
    public class CameraFollower : MonoBehaviour
    {

        [SerializeField] private GameObject rightCollider;
        [SerializeField] private GameObject leftCollider;
        [SerializeField] private float minX, maxX;
    
        private Transform player;
        private Vector3 tempPos;
        private float horzExtent;

        void Start()
        {
            player = GameObject.FindWithTag("Player").transform;
            horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
            
            rightCollider.transform.position = new Vector3(transform.position.x + horzExtent + 1.5f, transform.position.y);
            leftCollider.transform.position = new Vector3(transform.position.x - horzExtent - 1.5f, transform.position.y);
            Debug.Log(rightCollider.transform.position.x);
        }
        
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
            rightCollider.transform.position = new Vector3(transform.position.x + horzExtent + 1.5f, transform.position.y);
            leftCollider.transform.position = new Vector3(transform.position.x - horzExtent - 1.5f, transform.position.y);
        }
    }
}
