using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator playerAnimator;

    // Start is called before the first frame update
    private void Start() {
        playerAnimator.SetTrigger("StartMovement");
    }

    // Update is called once per frame
    private void Update()
    {
        playerTransform.position += speed * Input.GetAxis("Horizontal")
                                          * new Vector3(Time.deltaTime, 0f, 0f);

        if (Input.GetButtonDown("MonNouvelAxe")) {
            Debug.Log("test");
        }
    }
}
