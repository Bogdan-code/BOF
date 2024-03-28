using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopIngång : MonoBehaviour
{

    [SerializeField] private int sceneId;

    void Update()
    {

    }
    void OnCollisionEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            SceneManager.LoadScene(sceneId);
        }
    }
}
