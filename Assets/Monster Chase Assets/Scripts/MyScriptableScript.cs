using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScripatbleObjects/MyScriptableScript", order =1)]
    public class MyScriptableScript : ScriptableObject
    {
        [Header("CameraFollower Min and Max Value")] 
        [SerializeField] public float minX;
        [SerializeField] public float maxX;
       
        [Header("Destroy time for Blast Animation")]
        [SerializeField] public float _destroyAfterSec; 
        
        
        [Header("Gun Dynamics")]
        [SerializeField] public int magazineSize;
        [SerializeField] public float waitTimeReload;
        
        [Header("Movement Settings for the Player")]
        [SerializeField] public float moveForce;
        [SerializeField] public float jumpForce;
        
        [Header("Monster Speed")]
        [SerializeField] public float monsterSpeed;
        
        [Header("Fire Speed")]
        [SerializeField] public float fireSpeed;

        
    }
}
