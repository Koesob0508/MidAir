using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWall : Building
{
    private void Awake()
    {
        this.health = 500f;
    }

    public override void Activate(TestIsland _island)
    {
        base.Activate(_island);

        Debug.Log("Build Wall");
    }
}
