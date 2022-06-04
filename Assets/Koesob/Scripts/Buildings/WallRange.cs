using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRange : MonoBehaviour
{
    private BuildingWall parentBuilding;

    public void SetParentBuilding(BuildingWall _building)
    {
        parentBuilding = _building;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TurretMisile")
        {
            if (other.GetComponent<TurretMisile>().GetId() != parentBuilding.GetId())
            {
                parentBuilding.AddEnemyBuilding(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        parentBuilding.RemoveEnemyBuilding(other.gameObject);
    }
}
