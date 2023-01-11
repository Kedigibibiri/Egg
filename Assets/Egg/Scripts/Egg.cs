using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Egg : MonoBehaviour
{
    Rigidbody rBody;
    [SerializeField] float forceUp;
    [SerializeField] int gravityMultiply;

    void Start() => rBody = GetComponent<Rigidbody>();

    void Update()
    {
        float forceDown = PlayerPrefs.GetInt("score") * gravityMultiply;
        if (forceDown > 100) forceDown = 100;

        if (Mathf.Abs(rBody.velocity.y) < .1f)
        {
            rBody.AddForce(Vector3.down * forceDown);
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            float angle = Random.Range(-45f, 45f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            rBody.AddForce(Vector3.up * forceUp);
            rBody.AddForce(10f * angle * Vector3.left);

            //Eski random angle
            //float angle = (float)new Random().NextDouble() * (45 - 0) + 0;
            //float dist = (float)new Random().NextDouble() * (300 - 0) + 0;
            //Quaternion rotation = Quaternion.Euler(angle, dist, 0.0f);
            //rBody.AddForce(rotation * Vector3.up * forceUp);
            //transform.rotation = rotation;
        }
    }
}
