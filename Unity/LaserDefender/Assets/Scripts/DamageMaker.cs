using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMaker : MonoBehaviour
{
   [SerializeField] private float damage = 10;

    public float GetDamage()
    {
        return damage;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
