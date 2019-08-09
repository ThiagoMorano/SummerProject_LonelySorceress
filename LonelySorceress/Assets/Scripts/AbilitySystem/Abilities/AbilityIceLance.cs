using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/IceLance")]
public class AbilityIceLance : Ability
{
    public GameObject iceLancePrefab;


    public override void CastAbility(Transform _playerTransform)
    {
        GameObject iceLance = Instantiate(iceLancePrefab);
        iceLance.GetComponent<IceLanceProjectile>().data = this;
        iceLance.transform.position = _playerTransform.position + _playerTransform.forward * 2f;
        iceLance.transform.rotation = _playerTransform.rotation;
    }
}
