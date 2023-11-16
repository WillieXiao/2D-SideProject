using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthPresenter
{
    private PlayerHealth playerHealth;

    public PlayerHealthPresenter(PlayerHealth playerHealth)
    {
        this.playerHealth = playerHealth;

    }

    public void Healing(float value)
    {
        playerHealth.IncreaseHealthValue(value);
    }

    public void Hurt(float value)
    {
        playerHealth.DecreaseHealthValue(value);
    }


}
