using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform respawnPointTransform;
    [SerializeField] private TextMeshProUGUI coinCounterComponent;
    [SerializeField] private TextMeshProUGUI livesCounterComponent;
    [SerializeField] private GameObject gameOverGameObject;
    [SerializeField] private ParticleSystem jumpParticleSystem;
    [SerializeField] private AudioSource audioSource;

    private int numberOfJumps;
    private int numberOfCoinsCollected;
    private int numberOfLives;

    private Coroutine particleCoroutine;

    // Start is called before the first frame update
    private void Start() {
        numberOfJumps = 0;
        numberOfCoinsCollected = 0;
        numberOfLives = 3;
        playerAnimator.SetTrigger("StartMovement");
    }

    // Update is called once per frame
    private void Update() {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f)
            playerRigidbody.AddForce(speed * Input.GetAxis("Horizontal")
                                           * new Vector2(Time.deltaTime, 0f));

        if (Input.GetButtonUp("Jump") && numberOfJumps < 2) {
            playerRigidbody.AddForce(jumpForce * new Vector2(0f, 1f));
            particleCoroutine = StartCoroutine(DoParticleStart());
            numberOfJumps++;
        }
    }

    private IEnumerator DoParticleStart() {
        if (particleCoroutine != null) {
            StopCoroutine(particleCoroutine);
            jumpParticleSystem.Play();
        }

        yield return new WaitForSeconds(5f);
        jumpParticleSystem.Stop();
    }

    public void Respawn() {
        playerRigidbody.MovePosition(respawnPointTransform.position);
        playerRigidbody.velocity = new Vector2(0f, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Static")) {
            if (Vector3.Dot(other.contacts[0].normal, new Vector2(0f, 1f)) > 0.8f)
                numberOfJumps = 0;
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            numberOfLives--;
            if (numberOfLives <= 0)
                gameOverGameObject.SetActive(true);
            livesCounterComponent.text = $"Vies : {numberOfLives}";
            audioSource.Play();
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("FinDeNiveau"))
            Debug.Log("Fini!");
        else if (other.gameObject.layer == LayerMask.NameToLayer("Coin")) {
            numberOfCoinsCollected++;
            other.gameObject.GetComponent<CoinController>().HandleCoinCollection();
            coinCounterComponent.text = $"Pièces : {numberOfCoinsCollected}";
        }
    }
}
