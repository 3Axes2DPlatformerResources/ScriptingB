using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {
    [SerializeField] private GameObject pauseObject;
    
    public void HandleContinueButtonPress() {
        pauseObject.SetActive(false);
        Time.timeScale = 1f;
    }
    
    public void HandleBackToMenuButtonPress() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    
    public void HandleQuitButtonPress() {
        Application.Quit();
    }
}
