using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void HandleStartButtonPress() {
        if (PlayerPrefs.HasKey("scene"))
            SceneManager.LoadScene(PlayerPrefs.GetString("scene"));
        else
            SceneManager.LoadScene("Niveau1");
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            PlayerPrefs.DeleteAll();
        }
    }

    public void HandleQuitButtonPress() {
        Application.Quit();
    }
}
