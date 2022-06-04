using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Island : MonoBehaviour
{
    [SerializeField] int id = -1;
    [SerializeField] List<List<Tile>> tiles = new List<List<Tile>>();
    [SerializeField] GameObject tilePrefab;

    public int Id => id;

    private void Awake()
    {
        int count = 63;
        int center = count / 2;

        tiles = InstantiateTiles(count);

        SetCenterTile(tiles[center][center]);


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int id)
    {
        if (id != -1) return;
        this.id = id;
    }

    /// <summary>
    /// �� �ϳ��� ���� ��� Ÿ���� �̸� ������.
    /// </summary>
    /// <param name="count">�� ���� Ÿ�� ��</param>
    /// <returns>���� Ÿ�� ����Ʈ</returns>
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
                tile.Init(id, x, z);
                

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

    void SetCenterTile(Tile tile)
    {
        tile.SetType(Tile.eType.Building);
    }

    void CreateTile()
    {

    }
}