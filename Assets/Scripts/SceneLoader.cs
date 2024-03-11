using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player"))
            return;

        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
