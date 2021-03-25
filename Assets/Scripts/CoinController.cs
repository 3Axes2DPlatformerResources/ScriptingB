using UnityEngine;

public class CoinController : MonoBehaviour
{
    public void HandleCoinCollection() {
        Destroy(gameObject);
        Debug.Log("la pièce a été collectée");
    }
}
