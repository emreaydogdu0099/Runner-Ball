

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager gameManager;
    public int coinValue;
    public AudioSource coinSound;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AddCoins(coinValue);
            coinSound.Play();
            Destroy(gameObject);
        }
    }
}


