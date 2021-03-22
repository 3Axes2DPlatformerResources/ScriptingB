using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator playerAnimator;
    
    // True si direction = droite, False si direction = gauche
    private bool isGoingRight;
    private Vector3 movementVector;
    
    // Start is called before the first frame update
    private void Start() {
        playerTransform.position = new Vector3(0, 0, 0);
        movementVector = new Vector3(0.1f * speed, 0, 0);
        isGoingRight = true;
        playerAnimator.SetTrigger("StartMovement");
    }

    // Update is called once per frame
    private void Update()
    {
        // Déplacement
        if (isGoingRight)
            playerTransform.position += movementVector * Time.deltaTime;
        else
            playerTransform.position -= movementVector * Time.deltaTime;

        // Check position
        if (playerTransform.position.x > 5f)
            isGoingRight = false;
        else if (playerTransform.position.x < -5f)
            isGoingRight = true;
    }
}
