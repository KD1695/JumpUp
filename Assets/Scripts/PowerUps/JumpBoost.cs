using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : PowerUp
{
    public override void Activate()
    {
        PlayerState playerState = new PlayerState();
        playerState.jumpForceMultiplier = (Random.Range(0,2)==0) ? 2 : -2;
        playerState.playerHealth = 0;
        playerState.resetTimer = Duration;
        UpdatePlayerState(playerState);
    }

    void Update()
    {
        
    }
}