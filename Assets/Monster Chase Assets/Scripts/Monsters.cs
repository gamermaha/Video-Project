using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class Monsters : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] public float speed;
        private Rigidbody2D myBody;

        //private string FIRE_TAG = "Fire";
        public GameObject killed;


        private void Awake()
        {
            myBody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
        }

        public void Die()
        {
            var deathAnim = Instantiate(killed, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}