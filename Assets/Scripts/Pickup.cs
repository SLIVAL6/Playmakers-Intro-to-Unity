using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Player"))
            return;
        
        other.gameObject.GetComponent<PlayerController>().Pickups++;

        GameObject.FindWithTag("Manager").GetComponent<GameManager>().objectsToDestroy.Add(gameObject.name);

        Destroy(gameObject);
    }
}
