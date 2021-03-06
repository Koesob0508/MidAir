using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMisile : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Building building;
    private float attackDamage;
    public float speed;
    public float delayTime;
    private int id;


    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        if (target)
        {
            Vector3 dir = target.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        }



        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + this.transform.forward, speed * Time.deltaTime);
    }
    public void SetId(int _id)
    {
        this.id = _id;
    }

    public void SetParent(Building _building)
    {
        building = _building;
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
        this.transform.LookAt(target.transform);
    }

    public void SetAttackDamage(float _attackDamage)
    {
        attackDamage = _attackDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            other.gameObject.GetComponent<Building>().GetDamage(building, this.attackDamage);
            Destroy(this.gameObject);
        }
    }

    public int GetId()
    {
        return this.id;
    }
}
