using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject prefab;
    [SerializeField] private int numberOfEnemies = 10;
    [SerializeField] private float radius = 1f;
    
    // Start is called before the first frame update
    private void Start() {
        // Mathf
        for (int i = 0; i < numberOfEnemies; i++) {
            float angle = i * 2 * Mathf.PI / numberOfEnemies;
            
            Instantiate(prefab,
                radius * new Vector3(
                    Mathf.Cos(angle),
                    Mathf.Sin(angle),
                    0),
                Quaternion.identity);
        }
    }
}
