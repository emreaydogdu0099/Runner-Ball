using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private PlayerController playerController;
    [SerializeField] 
    private float respawnTime = 2f;
    private bool isRespawning = false;
    private int coins;
    public Text coinText;
    public GameObject WinnerPanel;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void RespawnPlayer()
    {
        if (!isRespawning)
        {
            isRespawning = true;
            StartCoroutine(RespawnCoroutine());
        }
    }
    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isRespawning = false;
    }
    public void AddCoins(int coinValue)
    {
        coins += coinValue;
        coinText.text = coins.ToString();
    }
    public void LevelUp()
    {
        WinnerPanel.SetActive(true);
        Invoke("NextLevel", respawnTime);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
