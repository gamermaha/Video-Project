

using UnityEngine;


namespace Monster_Chase_Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        private int magazineSize;
        private float waitTimeReload;
        
        [Header("GameObjects Imported")]
        [SerializeField] private Fire fireReference;

        //Booleans
        private static int _bulletsOnScreen = 0;
        public static int BulletsOnScreen
        {
            get { return _bulletsOnScreen; }
            set
            {
                if (value < 0)
                {
                    _bulletsOnScreen = 0;
                }
                else
                {
                    _bulletsOnScreen = value;
                }
                Debug.Log(BulletsOnScreen);
            }
        }

        private bool canShoot = true;
        private bool playerFlipped;
        private Fire _spawnedFire;


        private void OnEnable()
        {
            BulletsOnScreen = 0;
            magazineSize = MetaData.Instance.scriptableInstance.magazineSize;
            waitTimeReload = MetaData.Instance.scriptableInstance.waitTimeReload;
        }

        public void FireBullet()
        {
            //if(canShoot == false) return;
            
            if (BulletsOnScreen < magazineSize)
            {
                
                _spawnedFire = Instantiate(fireReference, transform.position, Quaternion.identity);
                BulletsOnScreen++;
                AudioManager.instance.fireAudio.Play();
                _spawnedFire.Shoot(playerFlipped);
                return;
            }
        }
        public void PlayerDirection(bool playerdir) => playerFlipped = playerdir;
    }
}
