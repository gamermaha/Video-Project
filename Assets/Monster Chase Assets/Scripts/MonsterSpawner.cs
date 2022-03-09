using System.Collections;
using UnityEngine;

namespace Monster_Chase_Assets.Scripts
{
    public class MonsterSpawner : MonoBehaviour
    {

        [SerializeField] 
        private GameObject[] monsterReference;
        
        private GameObject spawnedMonster;
        

        [SerializeField] 
        private Transform leftPos, rightPos;

        private int randomIndex;
        private int randomSide;
    
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(SpawnMonsters());
        }

        IEnumerator SpawnMonsters()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1, 5));
                randomIndex = Random.Range(0, monsterReference.Length);
                randomSide = Random.Range(0, 2);

                spawnedMonster = Instantiate(monsterReference[randomIndex]);
                
                


                if (randomSide == 0)
                {
                    spawnedMonster.transform.position = leftPos.position;
                    spawnedMonster.GetComponent<Monsters>().speed = Random.Range(4, 10);
                }
                else
                {
                    spawnedMonster.transform.position = rightPos.position;
                    spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(4, 10);
                    spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 0f);
                }
            }
        
        }

    
    }
}
