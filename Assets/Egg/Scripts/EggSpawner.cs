using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    Spawner spawner;
    [SerializeField] GameObject egg;

    void Start() => spawner = GetComponentInParent<Spawner>();

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Egg>())
        {
            spawner.spawned = false;
            GameObject newegg =  Instantiate(egg, transform.position, Quaternion.identity);
            newegg.transform.SetParent(other.transform.parent);
            Destroy(this.gameObject);
        }
    }
}
