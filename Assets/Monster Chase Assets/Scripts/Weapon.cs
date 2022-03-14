
using System.Collections;
using UnityEngine;


namespace Monster_Chase_Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private int magazineSize;
        [SerializeField] private float waitTimeReload;
        private int _bulletsInMagazine;
        private bool canShoot = true;
        private bool playerFlipped;
        [SerializeField] private Fire fireReference;
        [SerializeField] private AudioSource fireAudio;
        
        private Fire _spawnedFire;
        

        private void OnEnable()
        {
            _bulletsInMagazine = magazineSize;
        }

        public void PlayerDirection(bool playerdir)
        {
            playerFlipped = playerdir;
        }

        public void FireBullet()
        {
            // 0: Just Fallback If Shooting Is Not Allowed
            if(canShoot == false) return;

            // 1: Shoot If Magazine's Bullet Count > 0 
            if (_bulletsInMagazine > 0)
            {
                _spawnedFire = Instantiate(fireReference, transform.position, Quaternion.identity);
                fireAudio.Play();
                _spawnedFire.Shoot(playerFlipped);
                _bulletsInMagazine--;
                return;
            }
            
            // 2: If Bullet Count Is Zero , Reloading Schedule...
            SetWeaponShooting(false);
            StartCoroutine(ReloadWeapon());
        }


        private IEnumerator ReloadWeapon()
        {
            yield return new WaitForSeconds(waitTimeReload);
            _bulletsInMagazine = magazineSize;
            SetWeaponShooting(true);
        }
        
        private void SetWeaponShooting(bool canShoot)
            => this.canShoot = canShoot;
    }
}
