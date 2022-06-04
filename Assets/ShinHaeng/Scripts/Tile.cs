using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum eType
    {
        none = 0, Creatable, Buildable, Building
    }

    [SerializeField] Island island;
    [SerializeField] int id = -1;
    [SerializeField] int x;
    [SerializeField] int z;
    [SerializeField] eType type;

    public int Id => id;

    public eType Type { get => type; private set => type = value; }

    private void Awake()
    {
        Type = eType.none;
    }

    public void Init(Island island, int z, int x)
    {
        if (this.id != -1) return;
        this.island = island;
        this.id = island.Id;
        this.x = x;
        this.z = z;
        SetType(eType.none);
    }

    public void SetType(eType type)
    {
        this.Type = type;

        switch (type)
        {
            case eType.none:
                gameObject.SetActive(false);
                break;
            case eType.Creatable:
                gameObject.SetActive(false);
                break;
            case eType.Buildable:
                gameObject.SetActive(true);
                foreach(var tile in GetNearTiles())
                {
                    if (tile.Type == eType.none)
                    {
                        tile.SetType(eType.Creatable);
                    }
                }
                break;
            case eType.Building:
                gameObject.SetActive(true);
                break;
        }
    }

    private List<Tile> GetNearTiles()
    {
        List<Tile> tiles = new List<Tile>();
        if (island.GetTileable(z + 0, x - 1)) tiles.Add(island.GetTile(z + 0, x - 1));
        if (island.GetTileable(z + 0, x + 1)) tiles.Add(island.GetTile(z + 0, x + 1));
        if (island.GetTileable(z - 1, x + 0)) tiles.Add(island.GetTile(z - 1, x + 0));
        if (island.GetTileable(z + 1, x + 0)) tiles.Add(island.GetTile(z + 1, x + 0));
        return tiles;
    }
}