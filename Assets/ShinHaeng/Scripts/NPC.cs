using System.Linq;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC : Character
{
    int level = 1;

    public void SetNPCLevel(int level)
    {
        if (level < 1) level = 1;
        if (level > 30) level = 30;

        this.level = level;
    }

    private void Start()
    {
        BuildCore();

        {
            for (int i = 0; i < Random.Range(0, level * 2); i++)
            {
                var tile = FindRandomTileByType(Tile.eType.Creatable);
                if (tile == null) break;

                tile.SetType(Tile.eType.Buildable);
            }

            for (int i = 0; i <Random.Range(0, level); i++)
            {
                var tile = FindRandomTileByType(Tile.eType.Buildable);
                if (tile == null) break;

                BuildTurret(tile);
            }
        }

        StartCoroutine(NPCCoroutine());
    }

    IEnumerator NPCCoroutine()
    {
        while (true)
        {
            island.Move(FindMoveablePosition(transform.position));
            yield return new WaitForSecondsRealtime(level * 2);
        }
    }

    private Tile FindRandomTileByType(Tile.eType type)
    {
        var tiles = new List<Tile>();
        foreach(var list in island.Tiles)
        {
            foreach(var tile in list)
            {
                if (tile.Type == type)
                {
                    tiles.Add(tile);
                }
            }
        }

        if (tiles.Count == 0)
        {
            return null;
        }
        else
        {
            int ran = Random.Range(0, tiles.Count);
            return tiles[ran];
        }
    }
    private void BuildTurret(Tile tile)
    {
        island.Build(tile, GameManager.Turret);
    }

    private Vector3 FindMoveablePosition(Vector3 currentPos)
    {
        bool isValid = false;
        int maxCount = 100;

        float moveRange = level * 10;
        Vector3 ranMovePos = transform.position;

        for (int i = 0; i < maxCount; i++)
        {
            ranMovePos = transform.position;
            ranMovePos.x += Random.Range(-moveRange, moveRange);
            ranMovePos.z += Random.Range(-moveRange, moveRange);

            if (ranMovePos.x < -GameManager.Border && GameManager.Border < ranMovePos.x) isValid = false;
            if (ranMovePos.z < -GameManager.Border && GameManager.Border < ranMovePos.z) isValid = false;
            if (isValid) break;
        }

        return ranMovePos;
    }
}