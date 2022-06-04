using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHouse : Building
{
    [SerializeField] private GameObject modeling;
    public override void Activate()
    {
        Debug.Log("Build House");
        modeling.SetActive(true);
    }
}
