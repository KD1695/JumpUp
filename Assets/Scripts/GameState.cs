using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    [SerializeField] LedgeSpawner LedgeSpawner;

    //Game state variables
    float distanceSinceLastFloor = 0;
    int currentFloorCount = 0;
    float playerHealth = 100;
    
    [SerializeField] float levelSpeedBase = 5.0f;
    [SerializeField] float distanceBetweenFloors = 10.0f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image healthBar;
    [SerializeField] GameObject gameOver;

    float levelSpeedMain = 5;


    void Start()
    {
        Instance = this;
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

        if(playerHealth <= 0 && gameOver.activeSelf == false)
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
        playerHealth += valueChange;
        playerHealth = playerHealth <= 0 ? 0 : playerHealth;
        playerHealth = playerHealth > 400 ? 400 : playerHealth;
        healthBar.rectTransform.sizeDelta = new Vector2(playerHealth * 4, healthBar.rectTransform.rect.size.y);
    }
}
