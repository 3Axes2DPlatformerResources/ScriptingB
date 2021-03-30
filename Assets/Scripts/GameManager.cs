using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] private List<GameObject> gameObjectsNotToDestroy;
    [SerializeField] private PlayerController playerController;
    public static PlayerController PlayerController;

    public static GameManager MonGameManager;

    private void Awake() {
        MonGameManager = this;
        PlayerController = playerController;
        foreach (GameObject go in gameObjectsNotToDestroy)
            DontDestroyOnLoad(go);
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(LoadSceneRoutine(sceneName));
        PlayerPrefs.SetString("scene", sceneName);
    }
    
    private IEnumerator LoadSceneRoutine(string sceneName) {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
            yield return null;
        
        PlayerController.FindRespawnPoint();
        PlayerController.Respawn();
    }
}
