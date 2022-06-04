using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTurret : Building
{
    private float attackDamage;
    [SerializeField] private GameObject modeling;
    public override void Activate()
    {
        Debug.Log("Build Turret");
        modeling.SetActive(true);
    }
}
