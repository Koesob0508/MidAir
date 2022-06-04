using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHouse : Building
{
    int population;

    private void Awake()
    {
        this.health = 200f;
        this.population = 2;
    }

    public override void Activate(Island _island)
    {
        base.Activate(_island);

        Debug.Log("Build House");
    }
}
