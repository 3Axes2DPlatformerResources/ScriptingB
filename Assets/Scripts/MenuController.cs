using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void HandleStartButtonPress() {
        Debug.Log("coucou");
        Debug.LogError("ceci est une erreur");
        SaveManager.ReadSave();
        if (SaveManager.LoadedSaveData == null)
            SceneManager.LoadScene("Niveau1");
        else
            SceneManager.LoadScene(SaveManager.LoadedSaveData.sceneName);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            SaveManager.DeleteSave();
        }
    }

    public void HandleQuitButtonPress() {
        Application.Quit();
    }
}
