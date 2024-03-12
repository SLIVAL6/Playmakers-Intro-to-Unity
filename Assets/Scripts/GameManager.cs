using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPickups;
    [HideInInspector] public List<string> objectsToDestroy = new List<string>();

    private void Awake() 
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Manager");

        if (objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(GameObject.Find("Player"));
            objectsToDestroy.Clear();
            SceneManager.LoadScene(0);
        }
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
        textPickups.text = $"ID Cards: {numberOfPickups}";
    }
}
