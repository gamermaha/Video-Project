using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class CameraFollower : MonoBehaviour
    {
    
        public MyScriptableScript spawnManagerValues;

        private Transform player;
        private Vector3 tempPos;
        public Vector3 position;
        public float horzExtent;
        public float rightPos;
        public float leftPos;
        void Start()
        { 
            horzExtent = Camera.main.orthographicSize * Screen.width / Screen.height;
            player = GameObject.FindWithTag("Player").transform;
        }

        void LateUpdate()
        {
            if (!player)
                return;
            
            tempPos = transform.position;
            tempPos.x = player.position.x;
        
            if (tempPos.x < spawnManagerValues.minX)
                tempPos.x = spawnManagerValues.minX;
            if (tempPos.x > spawnManagerValues.maxX)
                tempPos.x = spawnManagerValues.maxX;

            transform.position = tempPos;
            rightPos = transform.position.x + horzExtent/2;
            rightPos = transform.position.x - horzExtent/2;
        }
    }
}
