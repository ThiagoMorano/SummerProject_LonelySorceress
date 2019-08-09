using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public int maxCharges;
    public float damage;


    public abstract void CastAbility(Transform _playerTransform);
}
