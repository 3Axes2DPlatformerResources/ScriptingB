using UnityEngine;

public class RespawnButtonController : MonoBehaviour {
    [SerializeField] private PlayerController playerController;
    
    public void HandleClick() {
        playerController.Respawn();
    }
}