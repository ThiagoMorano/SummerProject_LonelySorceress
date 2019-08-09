using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceLanceProjectile : MonoBehaviour
{
    [HideInInspector] public AbilityIceLance data;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Ability " + data.abilityName + " dealing " + data.damage);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward;
    }
}
