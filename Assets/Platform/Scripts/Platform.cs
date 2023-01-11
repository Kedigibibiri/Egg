using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Platform : MonoBehaviour
{
    [Header("UiElements")]
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text coin;
    [SerializeField] Slider slider; //TODO
    [SerializeField] Camera cam;
    Vector3 position;

    [Space]
    public bool gameStarted = false;

    void Start() => Score();
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (gameStarted)
        {
            Time.timeScale = 1f;
            Vector3 mousePosition = Input.mousePosition;
            position = cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 20f));
            transform.position = new Vector3(position.x, transform.position.y, transform.position.z);
        }
        if (!gameStarted) Time.timeScale = 0f; 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Egg>())
        {
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
            score.text = PlayerPrefs.GetInt("score").ToString();
        }
    }

    void Score()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        coin.text = PlayerPrefs.GetInt("coin").ToString();
    }

    void OnApplicationQuit() => PlayerPrefs.SetInt("score", 0);
    void OnDrawGizmos() => Gizmos.DrawLine(cam.transform.position, position);
}
