using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    // ref to the enemy object
    [SerializeField] public GameObject enemyPreFab1;
    [SerializeField] public GameObject enemyPreFab2;
    [SerializeField] public GameObject enemyPreFab3;
    [SerializeField] public GameObject enemyPreFab4;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPreFab1, new Vector3(-14, -0.8f, 12), Quaternion.identity);
        Instantiate(enemyPreFab2, new Vector3(-4, -2.06f, 12), Quaternion.identity);
        Instantiate(enemyPreFab3, new Vector3(5.6f, 0.9f, 12), Quaternion.identity);
        Instantiate(enemyPreFab4, new Vector3(16.5f, 0.3f, 12), Quaternion.identity);
    }
}
