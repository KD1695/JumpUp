using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperStar : PowerUp
{
    public override void Activate()
    {
        PlayClip();
        PlayerState playerState = new PlayerState();
        playerState.isInvincible = true;
        playerState.playerHealth = 400;
        playerState.replaceHealth = true;
        playerState.resetTimer = Duration;
        UpdatePlayerState(playerState);
    }
}
