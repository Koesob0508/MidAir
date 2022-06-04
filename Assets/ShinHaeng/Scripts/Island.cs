using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Island : MonoBehaviour
{
    [SerializeField] int id = -1;
    [SerializeField] List<List<Tile>> tiles = new List<List<Tile>>();
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int population = 10;
    [SerializeField] float speed = 10;
    [SerializeField] Vector3 purposePosition;

    public int Id => id;

    public Vector3 PurposePosition { get => purposePosition; set => purposePosition = value; }
    public List<List<Tile>> Tiles { get => tiles; private set => tiles = value; }


    //public int Population { get => population; set => population = value; }
    //public float Speed { get => speed; set => speed = value; }


    private void Awake()
    {


        
    }

    // Start is called before the first frame update
    void Start()
    {
        int count = 31;
        int center = count / 2;

        Tiles = InstantiateTiles(count);
        SetCenterTile(Tiles, center);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Look();
    }

    public void Init(int id)
    {
        if (this.id != -1) return;
        this.id = id;
        speed = 10;
        population = 10;
    }

    /// <summary>
    /// 섬 하나가 가질 모든 타일을 미리 생성함.
    /// </summary>
    /// <param name="count">한 변당 타일 수</param>
    /// <returns>이중 타일 리스트</returns>
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

    void SetCenterTile(List<List<Tile>> tiles, int center, int size = 3)
    {
        for (int i = 0; i < size; i++ )
        {
            for (int j = 0; j < size; j++)
            {
                tiles[center + i - (size / 2)][center + j - (size / 2)].SetType(Tile.eType.Buildable);
            }
        }

        //tiles[center][center].SetType(Tile.eType.Building);
    }

    void CreateTile()
    {

    }

    void Move()
    {
        if (Vector3.Distance(transform.position, PurposePosition) > 0.1f)
        {
            Debug.Log("Moving " + purposePosition);
            transform.position = Vector3.MoveTowards(transform.position, purposePosition, speed * Time.deltaTime);
            
        }
        else
        {

        }
    }

    void Look()
    {
        //transform.LookAt()
        //Vector3.RotateTowards(PurposePosition)
    }

    public void Build(Tile tile, GameObject buildingPrefab)
    {
        if (buildingPrefab == null) return;
        if (tile.Id != id) return;
        if (tile.Type != Tile.eType.Buildable) return;

        var building = Instantiate(buildingPrefab, tile.transform);

        var pos = building.transform.localPosition;
        pos.y += building.transform.localScale.y;
        building.transform.localPosition = pos;

        building.GetComponent<Building>().Activate(this, tile);
        building.GetComponent<Building>().destroyAction += OnDestroyBuilding;

        tile.SetType(Tile.eType.Building);
    }

    private void OnInstantiateBuilding(Building building)
    {

    }

    private void OnDestroyBuilding(Building building)
    {
        building.Tile.SetType(Tile.eType.Buildable);

        if (building is BuildingTurret)
        {
            
        }    
        else if (building is BuildingHouse)
        {

        }
        else if (building is BuildingCore)
        {
            Destroy(this.gameObject);
        }
        else if (building is BuildingWall)
        {

        }
        else if (building is BuildingMast)
        {

        }
    }
}