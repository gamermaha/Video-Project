using System;
using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class FireColliderRight : MonoBehaviour
    {
        [SerializeField] private CameraFollower _cameraFollower;
        
        private void Update()
        {
            
            //transform.position = new Vector3(_cameraFollower.rightPos , _cameraFollower.position.y,0);
            Debug.Log("Right: " + transform.position);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Fire"))
                Destroy(collision.gameObject);
        }
    }
}
