using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Transforms")]
    [SerializeField] Transform eggs;
    [SerializeField] Transform collect;
    [Header("GameObject")]
    [SerializeField] GameObject coin;
    [SerializeField] GameObject eggSpawner;

    [Space]
    [SerializeField] Platform platform;

    public bool spawned = false;

    void Update() => Spawn();

    void Spawn()
    {
        if (spawned == false && platform.gameStarted)
        {
            if (Random.Range(0,100) > 50)
            {
                GameObject egg = Instantiate(eggSpawner, new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 7f), 0), Quaternion.identity);
                egg.transform.SetParent(collect);
                spawned = true;
            }

            else
            {
                GameObject coinClone = Instantiate(coin, new Vector3(Random.Range(-5f, 5f), Random.Range(0f, 7f), 0), Quaternion.identity);
                coinClone.transform.SetParent(collect);
                spawned = true;
            }
        }
    }
}
