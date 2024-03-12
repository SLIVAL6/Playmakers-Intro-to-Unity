using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<string> objectsToDestroy = new List<string>();

    private void Awake() 
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if (objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach (string obj in objectsToDestroy)
        {
            GameObject destroyObject = GameObject.Find(obj);
            if (destroyObject != null)
                Destroy(destroyObject);
        }

        Debug.Log("OnSceneLoaded: " + scene.name);
    }
}
