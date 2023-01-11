using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Spawner spawner;

    void Start() => spawner = GetComponentInParent<Spawner>();

    void Update() => transform.Rotate(0, 2, 0);

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Egg>())
        {
            spawner.spawned = false;
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            Destroy(gameObject);
        }
    }
}
