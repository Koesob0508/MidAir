using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTurret : Building
{
    private float attackDamage;

    [SerializeField] private TurretRange rangeSphere;
    [SerializeField] private GameObject bullet;
    [SerializeField] private List<GameObject> enemyList;

    private GameObject target;

    private void Awake()
    {
        this.health = 200f;
        this.attackDamage = 10f;
        this.enemyList = new List<GameObject>();
    }

    private void Start()
    {
        rangeSphere.SetParentBuilding(this);
    }

    private void Update()
    {
        target = GetNearestEnemy();
    }

    public override void Activate(TestIsland _island)
    {
        base.Activate(_island);

        Debug.Log("Build Turret");
    }

    public void AddEnemyBuilding(GameObject _enemyBuilding)
    {
        enemyList.Add(_enemyBuilding);
    }

    public void RemoveEnemyBuilding(GameObject _enemyBuilding)
    {
        if (enemyList.Contains(_enemyBuilding))
        {
            enemyList.Remove(_enemyBuilding);
        }
    }

    private GameObject GetNearestEnemy()
    {
        GameObject resultEnemy = null;
        float nearestDistance = float.PositiveInfinity;
        foreach(GameObject enemy in enemyList)
        {
            float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if(nearestDistance > distance)
            {
                nearestDistance = distance;
                resultEnemy = enemy;
            }
        }

        return resultEnemy;
    }
}
