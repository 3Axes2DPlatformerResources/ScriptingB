using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour {
    private static bool wasSetupAlreadyLoaded = false;
    
    private void Awake() {
        if (!wasSetupAlreadyLoaded) {
            SceneManager.LoadScene("Setup", LoadSceneMode.Additive);
            wasSetupAlreadyLoaded = true;
        }
    }
}
