using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWall : Building
{
    private void Awake()
    {
        this.health = 500f;
    }

    public override void Activate(Island _island, Tile _tile)
    {
        base.Activate(_island, _tile);

        Debug.Log("Build Wall");
    }
}
