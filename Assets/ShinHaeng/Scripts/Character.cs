using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected GameManager GameManager;
    [SerializeField] protected Island island;

    private void Awake()
    {
        GameManager = GameManager.instance;
        island = GetComponent<Island>();
        island.PurposePosition = island.transform.position;
    }

    private void Start()
    {
        BuildCore();
    }

    protected void BuildCore()
    {
        int center = island.Tiles.Count / 2;
        Tile coreTile = island.Tiles[center][center];

        island.Build(coreTile, GameManager.Core);
    }
}