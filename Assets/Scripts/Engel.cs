using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Engel : MonoBehaviour
{
    Scene _scene;

    void Awake()
    {
       _scene= SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score.lives--;
            SceneManager.LoadScene(_scene.name);
        }
    }
}