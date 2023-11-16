using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float healthValue;

    private float maxHealthValue;

    public float CurrentHealth => healthValue;
    public float MaxHealth => maxHealthValue;

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
