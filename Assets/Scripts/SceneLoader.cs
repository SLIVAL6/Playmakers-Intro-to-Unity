using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad;
    private enum DoorPosition { Left, Right, Top, Bottom }
    [SerializeField] private DoorPosition doorPosition;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player"))
            return;

        switch (doorPosition)
        {
            case DoorPosition.Left:
                other.gameObject.GetComponent<PlayerController>().RepositionPlayer(PlayerController.SpawnPosition.Right);
                break;
            case DoorPosition.Right:
                other.gameObject.GetComponent<PlayerController>().RepositionPlayer(PlayerController.SpawnPosition.Left);
                break;
            case DoorPosition.Top:
                other.gameObject.GetComponent<PlayerController>().RepositionPlayer(PlayerController.SpawnPosition.Bottom);
                break;
            case DoorPosition.Bottom:
                other.gameObject.GetComponent<PlayerController>().RepositionPlayer(PlayerController.SpawnPosition.Top);
                break;
        }
        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
