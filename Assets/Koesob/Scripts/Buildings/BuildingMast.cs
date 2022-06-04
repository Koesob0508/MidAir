using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMast : Building
{
    private float speed;

    private void Awake()
    {
        this.health = 200f;
        this.speed = 10f;
    }

    public override void Activate(Island _island, Tile _tile)
    {
        base.Activate(_island, _tile);

        Debug.Log("Build Mast");
    }
}
