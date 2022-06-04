using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] Island island;

    private void Awake()
    {
        GameManager = GameManager.instance;
        island = GetComponent<Island>();
        island.PurposePosition = island.transform.position;
    }

    private void Start()
    {
        Tile findTile = null;
        Tile coreTile = null;

        foreach (var list in island.Tiles)
        {
            foreach( var tile in list)
            {
                if (tile.Type == Tile.eType.Buildable)
                {
                    findTile = tile;
                    break;
                }
            }
        }

        int center = island.Tiles.Count / 2;

        coreTile = island.Tiles[center][center];

        island.Build(findTile, GameManager.Turret);
        island.Build(coreTile, GameManager.Core);

    }
}