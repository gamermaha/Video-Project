using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class FireCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Fire"))
            {
                Weapon.BulletsOnScreen--;
                Destroy(collision.gameObject);
            }
                
            
        }
    }
}
