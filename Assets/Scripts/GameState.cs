using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;

    [SerializeField] LedgeSpawner LedgeSpawner;

    //Game state variables
    float distance = 0.0f;
    float distanceSinceLastFloor = 0;
    int currentFloorCount = 0;
    public float playerSpeed = 0.0f;
    
    [SerializeField] float levelSpeed = 5.0f;
    [SerializeField] float distanceBetweenFloors = 10.0f;
    
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        float step = Mathf.Max(playerSpeed, levelSpeed) * Time.deltaTime;
        distance += step;
        distanceSinceLastFloor += step;
        if(distanceSinceLastFloor >= distanceBetweenFloors || currentFloorCount == 0)
        {
            distanceSinceLastFloor = 0;
            LedgeSpawner.GenerateLedge(currentFloorCount);
            currentFloorCount++;
        }
    }

    public float GetDistance()
    {
        return distance;
    }
    public float GetSpeed()
    {
        return Mathf.Max(levelSpeed, playerSpeed);
    }
}
