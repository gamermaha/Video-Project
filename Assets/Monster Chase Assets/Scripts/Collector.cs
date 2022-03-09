using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class Collector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
            {
                Debug.Log(collision.gameObject + "have collided aaaaa");
                Destroy(collision.gameObject);
            }
        }
    }
}
