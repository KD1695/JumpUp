using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] LedgeSpawner LedgeSpawner;

    //Game state variables
    float distanceSinceLastFloor = 0;
    int currentFloorCount = 0;
    PlayerState playerState = new PlayerState();
    
    [SerializeField] float levelSpeedBase = 5.0f;
    [SerializeField] float distanceBetweenFloors = 10.0f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject gameOver;

    float levelSpeedMain = 5;


    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        levelSpeedMain = levelSpeedBase + (currentFloorCount / 30);
        float step = levelSpeedMain * Time.deltaTime;
        distanceSinceLastFloor += step;
        if(distanceSinceLastFloor >= distanceBetweenFloors || currentFloorCount == 0)
        {
            distanceSinceLastFloor = 0;
            IncrementCurrentFloor();
        }

        if(playerState.playerHealth <= 0 && gameOver.activeSelf == false)
        {
            gameOver.SetActive(true);
        }
    }

    public float GetSpeed()
    {
        return levelSpeedMain;
    }

    private void IncrementCurrentFloor()
    {
        LedgeSpawner.GenerateLedge(currentFloorCount);
        currentFloorCount++;
        scoreText.text = "Floor : " + currentFloorCount;
    }

    public void ModifyPlayerHealth(float valueChange)
    {
        playerState.playerHealth += valueChange;
        playerState.playerHealth = playerState.playerHealth <= 0 ? 0 : playerState.playerHealth;
        playerState.playerHealth = playerState.playerHealth > 400 ? 400 : playerState.playerHealth;
        healthBar.rectTransform.sizeDelta = new Vector2(playerState.playerHealth * 4, healthBar.rectTransform.rect.size.y);
    }

    public void UpdatePlayerState(PlayerState _playerState)
    {
        playerState.jumpForceMultiplier += _playerState.jumpForceMultiplier;
        if (playerState.jumpForceMultiplier < 1)
            playerState.jumpForceMultiplier = 1;
        if (_playerState.replaceHealth)
            playerState.playerHealth = _playerState.playerHealth;
    }

    public float JumpForceMultiplier()
    {
        return playerState.jumpForceMultiplier;
    }
}
