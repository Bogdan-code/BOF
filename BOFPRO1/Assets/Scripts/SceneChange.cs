using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shopIngång : MonoBehaviour
{

    [SerializeField] private int sceneId;
    float waitTime = 0.2f;
    float whenOpen = 0;
    bool changed=false;
    
    void Update()
    {
        Debug.Log(Time.time);
        if(Time.time > whenOpen && changed) { ChangeScene(); }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        whenOpen = Time.time + waitTime;
        changed = true;
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneId);
        changed = false;
    }
}
