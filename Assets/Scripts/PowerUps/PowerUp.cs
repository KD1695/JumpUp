using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Collider))]
public abstract class PowerUp : MonoBehaviour
{
    GameState gameState = null;
    Image image = null;
    [SerializeField] public float SpawnProbability = 0;
    [SerializeField] protected float Duration = 0;
    [SerializeField] protected AudioClip audioClip;

    /// <summary>
    /// Define power effect in this function
    /// </summary>
    public abstract void Activate();
    
    protected void Awake()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void SetGameState(GameState _gameState)
    {
        gameState = _gameState;
    }
    
    protected void ModifyPlayerHealth(float valueChange)
    {
        if(gameState != null)
        {
            gameState.ModifyPlayerHealth(valueChange);
        }
    }

    protected virtual void UpdatePlayerState(PlayerState _playerState)
    {
        ModifyPlayerHealth(_playerState.playerHealth);
        gameState.UpdatePlayerState(_playerState);
    }

    protected void PlayClip()
    {
        AudioManager.Instance.PlayAudioClip(audioClip);
    }
}
