using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class FireColliderLeft : MonoBehaviour
    {
        [SerializeField] private CameraFollower _cameraFollower;
        private void Update()
        {
            transform.position = new Vector3(_cameraFollower.leftPos , _cameraFollower.position.y,0);
            Debug.Log("LEft: " + transform.position);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Fire"))
                Destroy(collision.gameObject);
        }
    }
}
