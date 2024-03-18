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

        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

        switch (doorPosition)
        {
            case DoorPosition.Left:
                playerController.RepositionPlayer(PlayerController.SpawnPosition.Right);
                break;
            case DoorPosition.Right:
                playerController.RepositionPlayer(PlayerController.SpawnPosition.Left);
                break;
            case DoorPosition.Top:
                playerController.RepositionPlayer(PlayerController.SpawnPosition.Bottom);
                break;
            case DoorPosition.Bottom:
                playerController.RepositionPlayer(PlayerController.SpawnPosition.Top);
                break;
        }

        playerController.PlaySFXDoor();

        SceneManager.LoadScene(sceneIndexToLoad);
    }
}
