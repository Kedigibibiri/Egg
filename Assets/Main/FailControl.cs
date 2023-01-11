using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailControl : MonoBehaviour
{
    [SerializeField] Transform health;
    [SerializeField] Transform eggsParrent;
    [SerializeField] GameObject egg;
    [SerializeField] UiScript ui;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Egg>())
        {
            GameObject lastChild = health.GetChild(health.childCount - 1).gameObject;

            if (health.childCount > 1)
            {
                Destroy(lastChild);
                Destroy(collision.gameObject);
            }

            if (health.childCount == 1)
            {
                Destroy(lastChild);
                Destroy(collision.gameObject);
                ui.Ending();
            }

            if (eggsParrent.childCount == 1)
            {
                Destroy(lastChild);
                Destroy(collision.gameObject);
                GameObject newegg = Instantiate(egg, eggsParrent.position, Quaternion.identity);
                newegg.transform.SetParent(eggsParrent);
            }
        } 
    }
}
