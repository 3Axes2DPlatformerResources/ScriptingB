using UnityEngine;

public class EnemySpawning : MonoBehaviour {
    private GameObject prefab;

    void Start() {
        prefab = Resources.Load<GameObject>("Enemy");
        for (int i = 0; i < 5; i++)
            Instantiate(prefab);
    }
}
