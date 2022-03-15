
using System.Collections;
using UnityEngine;


namespace Monster_Chase_Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        public MyScriptableScript spawnManagerValues;
        
        [Header("GameObjects Imported")]
        [SerializeField] private Fire fireReference;
        [SerializeField] private AudioSource fireAudio;
        
        //Booleans
        private int _bulletsInMagazine;
        private bool canShoot = true;
        private bool playerFlipped;
        private Fire _spawnedFire;
        

        private void OnEnable()
        {
            _bulletsInMagazine = spawnManagerValues.magazineSize;
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
            yield return new WaitForSeconds(spawnManagerValues.waitTimeReload);
            _bulletsInMagazine = spawnManagerValues.magazineSize;
            SetWeaponShooting(true);
        }
        private void SetWeaponShooting(bool canShoot)
            => this.canShoot = canShoot;
        public void PlayerDirection(bool playerdir)
            => playerFlipped = playerdir;
    }
}
