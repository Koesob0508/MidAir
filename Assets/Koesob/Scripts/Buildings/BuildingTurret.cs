using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTurret : Building
{
    private float attackDamage;
    private float time;
    public float delayTime;

    [SerializeField] private TurretRange rangeSphere;
    [SerializeField] private TurretMisile misile;
    [SerializeField] private List<GameObject> enemyList;

    private GameObject target;

    private void Awake()
    {
        this.health = 200f;
        this.time = 0f;
        this.attackDamage = 50f;
        this.enemyList = new List<GameObject>();
    }

    private void Start()
    {
        rangeSphere.SetParentBuilding(this);
    }

    private void Update()
    {
        target = GetNearestEnemy();

        time += Time.deltaTime;

        if(time >= delayTime)
        {
            time = 0f;
            if(GetNearestEnemy())
            {
                target = GetNearestEnemy();
                LaunchMisile(target, attackDamage);
            }
        }
    }

    public override void Activate(Island _island, Tile _tile)
    {
        base.Activate(_island, _tile);

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
            if(enemy)
            {
                float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
                if (nearestDistance > distance)
                {
                    nearestDistance = distance;
                    resultEnemy = enemy;
                }
            }
        }

        return resultEnemy;
    }

    private void LaunchMisile(GameObject _target, float _attackDamage)
    {
        TurretMisile tempMisilie = Instantiate<TurretMisile>(misile, this.transform.position, this.transform.rotation);
        tempMisilie.SetId(this.mainId);
        tempMisilie.SetParent(this);
        tempMisilie.SetTarget(_target);
        tempMisilie.SetAttackDamage(_attackDamage);
    }
}
