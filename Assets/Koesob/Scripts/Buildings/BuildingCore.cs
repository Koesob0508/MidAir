using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCore : Building
{
    private void Awake()
    {
        this.health = 1000f;
    }

    public override void Activate(Island _island)
    {
        base.Activate(_island);

        Debug.Log("Build Core");
    }
}
