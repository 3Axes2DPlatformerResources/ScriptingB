using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private List<GameObject> gameObjectsNotToDestroy;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject pauseObject;
    public static PlayerController PlayerController { get; private set; }
    public static GameManager MonGameManager { get; private set; }

    private void Awake() {
        MonGameManager = this;
        PlayerController = playerController;
        playerController.UseSaveData();
        foreach (GameObject go in gameObjectsNotToDestroy)
            DontDestroyOnLoad(go);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseObject.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneRoutine(sceneName));
        SaveManager.DoSave(sceneName, playerController.numberOfCoinsCollected, playerController.numberOfLives);
    }
    
    private IEnumerator LoadSceneRoutine(string sceneName) {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
            yield return null;
        
        PlayerController.FindRespawnPoint();
        PlayerController.Respawn();
    }
}
