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
        island.Build(findTile, GameManager.Wall);
    }
}