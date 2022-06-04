using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMisile : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Building building;
    private float attackDamage;
    public float speed;
    private float time;
    public float delayTime;

    private void Awake()
    {
        this.time = 0f;
    }

    private void Start()
    {
        Destroy(this.gameObject, 5f);

        this.transform.LookAt(target.transform);
        this.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void Update()
    {
        time += Time.deltaTime;
        
        if(time >= delayTime)
        {
            this.transform.LookAt(target.transform);
            this.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void SetParent(Building _building)
    {
        building = _building;
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    public void SetAttackDamage(float _attackDamage)
    {
        attackDamage = _attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("´ê¾Ò´Ù");
        if(other.gameObject == target)
        {
            other.gameObject.GetComponent<Building>().GetDamage(building, this.attackDamage);
            Destroy(this.gameObject);
        }
    }
}
