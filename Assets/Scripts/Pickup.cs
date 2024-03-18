using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player"))
            return;
        
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        GameManager gameManager = GameObject.FindWithTag("Manager").GetComponent<GameManager>();
        
        playerController.Pickups++;
        playerController.PlaySFXPickup();
        gameManager.SetPickupText(playerController.Pickups);
        gameManager.objectsToDestroy.Add(gameObject.name);

        Destroy(gameObject);
    }
}
