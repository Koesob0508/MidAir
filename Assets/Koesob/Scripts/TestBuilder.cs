using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuilder : Island
{
    public List<Tile> testTileList;
    public Building testTurret;
    public Building testHouse;
    public Building testWall;
    public Building testMast;
    public Building testCore;

    public int tileNumber;

    public void BuildTurret(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testTurret, testTileList[_tileNumber].transform);
        tempBuilding.Activate(this);
    }

    public void BuildHouse(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testHouse, testTileList[_tileNumber].transform);
        tempBuilding.Activate(this);
    }
    public void BuildWall(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testWall, testTileList[_tileNumber].transform);
        tempBuilding.Activate(this);
    }
    public void BuildMast(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testMast, testTileList[_tileNumber].transform);
        tempBuilding.Activate(this);
    }

    public void BuildCore(int _tileNumber)
    {
        Debug.Log("Build");
        Building tempBuilding = Instantiate<Building>(testCore, testTileList[_tileNumber].transform);
        tempBuilding.Activate(this);
    }
}
