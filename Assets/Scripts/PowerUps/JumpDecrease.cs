using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDecrease : PowerUp
{
    public override void Activate()
    {
        PlayClip();
        PlayerState playerState = new PlayerState();
        playerState.jumpForceMultiplier = -2;
        playerState.playerHealth = 0;
        playerState.resetTimer = Duration;
        UpdatePlayerState(playerState);
    }
}
