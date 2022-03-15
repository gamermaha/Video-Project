using System;
using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfig", order = 1)]
    public class GameConfig : ScriptableObject
    {
        [Header("Fire Speed")]
        public float fireSpeed = 3f;
        
        [Header("Monster Speed")]
        public float monsterSpeed;
        
        [Header("Gun Dynamics")]
        public int magazineSize;
        public float waitTimeReload;
        
        [Header("Blast Animation Destroy Time")]
        public float _destroyAfterSec = 0.5f;
    }
    
}
