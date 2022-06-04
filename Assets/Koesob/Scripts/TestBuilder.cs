using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuilder : MonoBehaviour
{
    public List<Tile> testTileList;
    public Building testTurret;
    public Building testHouse;
    public Building testWall;
    public Building testMast;

    public int tileNumber;

    public void BuildTurret(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testTurret, testTileList[_tileNumber].transform);
        tempBuilding.Activate();
    }

    public void BuildHouse(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testHouse, testTileList[_tileNumber].transform);
        tempBuilding.Activate();
    }
    public void BuildWall(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testWall, testTileList[_tileNumber].transform);
        tempBuilding.Activate();
    }
    public void BuildMast(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testMast, testTileList[_tileNumber].transform);
        tempBuilding.Activate();
    }
}
