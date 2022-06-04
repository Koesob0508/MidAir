using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRange : MonoBehaviour
{
    private BuildingTurret parentBuilding;
    private SphereCollider rangeSphere;
    
    private void Awake()
    {
        rangeSphere = this.gameObject.GetComponent<SphereCollider>();
        Debug.Log("Turret Range On");
    }

    public void SetParentBuilding(BuildingTurret _building)
    {
        parentBuilding = _building;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Building")
        {
            if(other.GetComponent<Building>().GetId() != parentBuilding.GetId())
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
