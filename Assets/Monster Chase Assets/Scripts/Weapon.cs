
using System.Collections;
using UnityEditor.MemoryProfiler;
using UnityEngine;


namespace Monster_Chase_Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [Header("Gun Dynamics")]
        [SerializeField] private int magazineSize;
        [SerializeField] private float waitTimeReload;
        
        [Header("GameObjects Imported")]
        [SerializeField] private Fire fireReference;
        [SerializeField] private AudioSource fireAudio;
        
        //Booleans
        private static int _bulletsOnScreen = 0;
        public static int BulletsOnScreen
        {
            get { return _bulletsOnScreen; }
            set
            {
                if (value < 0) 
                    _bulletsOnScreen = 0;
                
                _bulletsOnScreen = value;
            }
        }

        private bool canShoot = true;
        private bool playerFlipped;
        private Fire _spawnedFire;
        

        private void OnEnable()
        {
            BulletsOnScreen = 0;
            Debug.Log("Should reset: " + BulletsOnScreen);
        }
        public void FireBullet()
        {
            if(canShoot == false) return;
            
            if (BulletsOnScreen < magazineSize)
            {
                _spawnedFire = Instantiate(fireReference, transform.position, Quaternion.identity);
                BulletsOnScreen++;
                fireAudio.Play();
                _spawnedFire.Shoot(playerFlipped);
                return;
            }
            SetWeaponShooting(false);
        }
        private void SetWeaponShooting(bool canShoot) => this.canShoot = canShoot;
        public void PlayerDirection(bool playerdir) => playerFlipped = playerdir;
    }
}
