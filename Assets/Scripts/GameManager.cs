using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPickups;
    [SerializeField] private TextMeshProUGUI textVictory;
    [HideInInspector] public List<string> objectsToDestroy = new List<string>();

    private void Awake() 
    {
        if (textVictory != null)
            textVictory.enabled = false;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if (objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update() 
    {
        Restart();
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

    public void SetPickupText(int numberOfPickups)
    {
        if (textPickups != null)
            textPickups.text = $"ID Cards: {numberOfPickups}";
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetPickupText(0);
            textVictory.enabled = false;
            Time.timeScale = 1f;
            Destroy(GameObject.Find("Player"));
            objectsToDestroy.Clear();
            SceneManager.LoadScene(0);
        }
    }

    public void Victory()
    {
        if (textVictory != null)
            textVictory.enabled = true;
        
        Time.timeScale = 0f;
    }
}
