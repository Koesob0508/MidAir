using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHouse : Building
{
    int population;

    [SerializeField] private GameObject modeling;
    public override void Activate(Island island)
    {
        Debug.Log("Build House");
        modeling.SetActive(true);
        modeling.transform.localPosition += new Vector3(0f, modeling.transform.localScale.y / 2, 0f);
    }
}
