using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponColider : MonoBehaviour
{
    [SerializeField]
    private int weaponDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageReceiver target = GetComponent<DamageReceiver>();
        if (target != null)
        {
            target.SendDamage(weaponDamage);
        }
    }

}
