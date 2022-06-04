using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC : Character
{
    private void Start()
    {
        BuildCore();

        BuildTurret();
        BuildTurret();
        BuildTurret();
    }

    private void BuildTurret()
    {
        Tile purTile = null;

        foreach (var list in island.Tiles)
        {
            foreach (var tile in list)
            {
                if (tile.Type == Tile.eType.Buildable)
                {
                    purTile = tile;
                    break;
                }
            }
        }

        if (purTile)
        {
            island.Build(purTile, GameManager.Turret);
        }
    }
}