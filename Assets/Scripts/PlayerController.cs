using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Animator playerAnimator;

    private bool hasJumped;

    // Start is called before the first frame update
    private void Start() {
        hasJumped = false;
        playerAnimator.SetTrigger("StartMovement");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f)
            playerRigidbody.AddForce(speed * Input.GetAxis("Horizontal")
                                           * new Vector2(Time.deltaTime, 0f));

        if (Input.GetButtonUp("Jump") && hasJumped == false) {
            playerRigidbody.AddForce(jumpForce * new Vector2(0f, 1f));
            hasJumped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (Vector3.Dot(other.contacts[0].normal, new Vector2(0f, 1f)) > 0.8f)
            hasJumped = false;
    }
}
