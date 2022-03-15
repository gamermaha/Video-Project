using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class Fire : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;
    
        private Rigidbody2D _rb;
        private bool _checkForFlip;
        private Weapon myWeapon;


        void Start() => _rb = GetComponent<Rigidbody2D>();

        void Update()
        {
            if (_checkForFlip) 
                _rb.velocity = new Vector2((-1 * speed), _rb.velocity.y);
            else 
                _rb.velocity = new Vector2(speed, _rb.velocity.y);
        
        } 
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Monsters>(out var monsters))
            {
                Weapon.BulletsOnScreen--;
                monsters.Die();
                Destroy(gameObject); 
            }
        }
        public void Shoot(bool flippedCheck) => _checkForFlip = flippedCheck;
    
    }
}
