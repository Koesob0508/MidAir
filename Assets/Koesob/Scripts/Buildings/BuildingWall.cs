using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingWall : Building
{
    private float time;
    public float delayTime;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private WallRange rangeSphere;
    [SerializeField] private WallMisile misile;

    private GameObject target;

    private void Awake()
    {
        this.time = 0f;
        this.health = 500f;
        this.enemyList = new List<GameObject>();
    }

    private void Start()
    {
        rangeSphere.SetParentBuilding(this);
    }

    //private void Update()
    //{
    //    target = GetNearestEnemy();

    //    time += Time.deltaTime;

    //    if (time >= delayTime)
    //    {
    //        time = 0f;
    //        if (GetNearestEnemy())
    //        {
    //            target = GetNearestEnemy();
    //            LaunchMisile(target);
    //        }
    //    }
    //}

    public override void Activate(Island _island, Tile _tile)
    {
        base.Activate(_island, _tile);

        Debug.Log("Build Wall");
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
        foreach (GameObject enemy in enemyList)
        {
            if (enemy)
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

    private void LaunchMisile(GameObject _target)
    {
        WallMisile tempMisilie = Instantiate<WallMisile>(misile, this.transform.position, this.transform.rotation);
        tempMisilie.SetId(this.mainId);
        tempMisilie.SetParent(this);
        tempMisilie.SetTarget(_target);
    }
}
