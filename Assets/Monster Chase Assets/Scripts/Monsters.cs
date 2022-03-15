using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class Monsters : MonoBehaviour
    {
        public GameObject killed;
        public float speed;
        
        private Rigidbody2D myBody;


        private void Awake()
        {
            myBody = GetComponent<Rigidbody2D>();
            speed = MetaData.Instance.scriptableInstance.monsterSpeed;
        }


        void FixedUpdate() => myBody.velocity = new Vector2(speed, myBody.velocity.y);
        
        public void Die()
        {
            var deathAnim = Instantiate(killed, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}