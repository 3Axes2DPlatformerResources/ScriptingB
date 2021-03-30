using UnityEngine;

public class EndLevelController : MonoBehaviour {
    [SerializeField] private string sceneNameToLoad;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            GameManager.MonGameManager.LoadScene(sceneNameToLoad);
        }
    }

    
}
