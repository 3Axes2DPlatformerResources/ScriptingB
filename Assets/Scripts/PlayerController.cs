using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 1000f;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private Animator playerAnimator;
    private Transform respawnPointTransform;
    [SerializeField] private TextMeshProUGUI coinCounterComponent;
    [SerializeField] private TextMeshProUGUI livesCounterComponent;
    [SerializeField] private GameObject gameOverGameObject;
    [SerializeField] private ParticleSystem jumpParticleSystem;
    [SerializeField] private AudioSource audioSource;

    private int numberOfJumps;
    public int numberOfCoinsCollected { get; private set; }
    public int numberOfLives { get; private set; }

    private bool isAllowedToMove;
    private bool isMoving;

    private Coroutine particleCoroutine;

    private void Awake() {
        FindRespawnPoint();
    }

    public void UseSaveData() {
        if (SaveManager.LoadedSaveData != null) {
            numberOfCoinsCollected = SaveManager.LoadedSaveData.numberOfCoins;
            UpdateCoinsCounter();
            
            numberOfLives = SaveManager.LoadedSaveData.numberOfLives;
            UpdateLivesCounter();
        }
    }

    private void Start() {
        isMoving = false;
        numberOfJumps = 0;
        numberOfCoinsCollected = 0;
        numberOfLives = 3;
        playerAnimator.SetBool("IsMoving", false);
        isAllowedToMove = false;
        Respawn();
    }

    public void FindRespawnPoint() {
        respawnPointTransform = GameObject.Find("RespawnPoint").transform;
        Debug.Log(respawnPointTransform);
    }

    // Update is called once per frame
    private void Update() {
        if (isAllowedToMove) {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.3f) {
                playerRigidbody.AddForce(speed * Input.GetAxis("Horizontal")
                                               * new Vector2(Time.deltaTime, 0f));
                if (!isMoving) {
                    playerAnimator.SetBool("IsMoving", true);
                    isMoving = true;
                }
            } else if (isMoving) {
                playerAnimator.SetBool("IsMoving", false);
                isMoving = false;
            }

            if (Input.GetButtonUp("Jump") && numberOfJumps < 2) {
                playerRigidbody.AddForce(jumpForce * new Vector2(0f, 1f));
                particleCoroutine = StartCoroutine(DoParticleStart());
                numberOfJumps++;
            }
        } else if (isMoving) {
            playerAnimator.SetBool("IsMoving", false);
            isMoving = false;
        }
    }

    public void AllowMovement() {
        isAllowedToMove = true;
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

    private void UpdateCoinsCounter() {
        coinCounterComponent.text = $"Pièces : {numberOfCoinsCollected}";
    }

    private void UpdateLivesCounter() {
        livesCounterComponent.text = $"Vies : {numberOfLives}";
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Static")) {
            if (Vector3.Dot(other.contacts[0].normal, new Vector2(0f, 1f)) > 0.8f)
                numberOfJumps = 0;
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Enemy")) {
            numberOfLives--;
            if (numberOfLives <= 0)
                gameOverGameObject.SetActive(true);
            UpdateLivesCounter();
            audioSource.Play();
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin")) {
            numberOfCoinsCollected++;
            other.gameObject.GetComponent<CoinController>().HandleCoinCollection();
            UpdateCoinsCounter();
        }
    }
}
