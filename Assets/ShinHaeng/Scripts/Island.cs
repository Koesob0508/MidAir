using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField] List<List<Tile>> tiles = new List<List<Tile>>();
    [SerializeField] GameObject tilePrefab;

    private void Awake()
    {
        tiles = InstantiateTiles(63);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    List<List<Tile>> InstantiateTiles(int count)
    {
        int startX = -(count / 2);
        int startZ = -(count / 2);

        List<List<Tile>> tileList = new List<List<Tile>>(count);
        for (int z = 0; z < count; z++)
        {
            List<Tile> listX = new List<Tile>(count);
            for (int x = 0; x < count; x++)
            {
                var tile = Instantiate(tilePrefab, transform).GetComponent<Tile>();
                tile.name = "Tile_" + z + x;

                Vector3 localPosition;
                localPosition.x = startX + x;
                localPosition.z = startZ + z;
                localPosition.y = 0;
                tile.transform.localPosition = localPosition;

                listX.Add(tile);
            }
            tileList.Add(listX);
        }

        return tileList;
    }
}