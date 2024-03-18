using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField] private int pickupsRequired = 1;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

        if (playerController.Pickups < pickupsRequired)
        {
            Debug.Log($"Not enough IDs! You need {pickupsRequired - playerController.Pickups} more IDs");
        }
        else if (playerController.Pickups >= pickupsRequired)
        {
            GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>().Victory();
        }
    }
}
