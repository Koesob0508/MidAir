using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCore : Building
{
    [SerializeField] private GameObject modeling;
    public override void Activate()
    {
        Debug.Log("Build Core");
        modeling.SetActive(true);
    }
}
