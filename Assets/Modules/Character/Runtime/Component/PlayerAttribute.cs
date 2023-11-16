using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttribute : MonoBehaviour,DamageReceiver
{
    //Health
    [SerializeField]
    private float healthValue;

    private float maxHealthValue;

    public float CurrentHealth => healthValue;
    public float MaxHealth => maxHealthValue;

    public void SendDamage(int damage)
    {
        IncreaseHealthValue(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseHealthValue(float value)
    {
        healthValue += value;
        healthValue = Mathf.Clamp(healthValue, 0.0f, maxHealthValue);

    }

    public void DecreaseHealthValue(float value)
    {
        healthValue -= value;
        healthValue = Mathf.Clamp(healthValue, 0.0f, maxHealthValue);
    }
}
