using System;
using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class Blast : MonoBehaviour
    {
        private float _destroyAfterSec;

        private void Start()
        {
            _destroyAfterSec = MetaData.Instance.scriptableInstance._destroyAfterSec;
            Destroy(this.gameObject, _destroyAfterSec);
            
        }
    }
}
