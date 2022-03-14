using System;
using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class Blast : MonoBehaviour
    {
        [SerializeField] private float _destroyAfterSec = 0.5f; 
        private void Start() => Destroy(this.gameObject , _destroyAfterSec);
    }
}
