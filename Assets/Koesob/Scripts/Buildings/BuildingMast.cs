using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMast : Building
{
    private float speed;
    [SerializeField] private GameObject modeling;
    public override void Activate()
    {
        Debug.Log("Build Mast");
        modeling.SetActive(true);
    }
}
