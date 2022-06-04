using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWall : Building
{
    [SerializeField] private GameObject modeling;
    public override void Activate()
    {
        Debug.Log("Build Wall");
        modeling.SetActive(true);
    }
}
