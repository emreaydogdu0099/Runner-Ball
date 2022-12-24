using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField]
    private float pushForce = 1000f;
    private float movementX;
    private float movementY;
    [SerializeField]
    private float speed = 5f;
    public Vector3 respawnPoint;
    private GameManager gameManager;
    public AudioSource crashSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        movementX = Input.GetAxis("Horizontal");
        movementY = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        rb.AddForce(movementX * pushForce * Time.deltaTime, 0, movementY * pushForce * Time.deltaTime);
        rb.velocity = new Vector3(movementX * speed, rb.velocity.y, rb.velocity.z);
        FallDetector();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            gameManager.RespawnPlayer();
            crashSound.Play();
        }
    }
    private void FallDetector()
    {
        if (rb.position.y < -2f)
        {
            gameManager.RespawnPlayer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            gameManager.LevelUp();
        }
    }
}
