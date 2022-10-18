using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : PowerUp
{
    public override void Activate()
    {
        PlayClip();
        ModifyPlayerHealth(15);
    }

    void Update()
    {
        
    }
}