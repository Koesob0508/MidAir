using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Island : MonoBehaviour
{
    [SerializeField] int id = -1;
    [SerializeField] List<List<Tile>> tiles = new List<List<Tile>>();
    [SerializeField] GameObject tilePrefab;
    [SerializeField] int population = 10;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float turnSpeed = 10;
    [SerializeField] Vector3 purposePosition;
    [SerializeField] Vector3 purposeDirection;
    [SerializeField] Rigidbody Rigidbody;
    [SerializeField] bool isAddForceMoveType = false;
    [SerializeField] bool isMoving = false;
    [SerializeField] bool isTurning = false;
    [SerializeField] bool isGroundingMode = false;

    public int Id => id;

    public Vector3 PurposePosition { get => purposePosition; set => purposePosition = value; }
    public List<List<Tile>> Tiles { get => tiles; private set => tiles = value; }
    public bool IsGroundingMode
    {
        get => isGroundingMode; set
        {
            isGroundingMode = value;
            GroundingMode(isGroundingMode);
        }
    }

    //public int Population { get => population; set => population = value; }
    //public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();

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
        moveSpeed = 4;
        turnSpeed = 2;
        population = 10;
    }

    public void Move(Vector3 point)
    {
        if (Vector3.Distance(transform.position, point) <= 0.01f)
        {
            isMoving = false;
            //isTurning = false;
        }
        else
        {
            isMoving = true;
            isTurning = true;

            purposePosition = point;
            purposeDirection = (point - transform.position);
        }
    }

    void Move()
    {
        if (isMoving)
        {
            if (isAddForceMoveType)
            {
                if (Vector3.Distance(transform.position, PurposePosition) > 0.01f)
                {
                    Rigidbody.velocity = (transform.forward * moveSpeed * Time.deltaTime);
                }
                else
                {
                    isMoving = false;
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, PurposePosition) > 0.01f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, purposePosition, moveSpeed * Time.deltaTime);
                }
                else
                {
                    isMoving = false;
                }
            }
        }
    }

    void Look()
    {
        if (isTurning)
        {
            if (Vector3.Distance(transform.eulerAngles, purposeDirection) > 0.01f)
            {
                this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(purposeDirection), Time.deltaTime * turnSpeed);
            }
            else
            {
                isTurning = false;
            }
        }
    }

    #region Tile

    /// <summary>
    /// ?? ?????? ???? ???? ?????? ???? ??????.
    /// </summary>
    /// <param name="count">?? ???? ???? ??</param>
    /// <returns>???? ???? ??????</returns>
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
                tile.Init(this, z, x);
                

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
    public bool IsValidCoordinate(int z, int x)
    {
        if (0 <= z && z < tiles.Count &&
            0 <= x && x < tiles.Count)
            return true;
        else
            return false;
    }
    public Tile GetTile(int z, int x)
    {
        if (0 <= z && z < tiles.Count &&
            0 <= x && x < tiles.Count)
            return tiles[z][x];
        else
            return null;
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

    /// <summary>
    /// ?? ???? ???????? ?????? ??????/????.
    /// </summary>
    /// <param name="isGroundingMode"></param>
    private void GroundingMode(bool isGroundingMode)
    {
        if (isGroundingMode)
        {
            tiles.ForEach(list =>
            {
                list.ForEach(tile =>
                {
                    if (tile.Type == Tile.eType.Creatable)
                        tile.gameObject.SetActive(true);
                });
            });
        }
        else
        {
            tiles.ForEach(list =>
            {
                list.ForEach(tile =>
                {
                    if (tile.Type == Tile.eType.Creatable)
                        tile.gameObject.SetActive(false);
                });
            });
        }
    }

    #endregion

}