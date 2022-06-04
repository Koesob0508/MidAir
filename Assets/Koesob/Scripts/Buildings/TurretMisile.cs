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
        this.time = 0;
    }

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    private void Update()
    {
        // time += Time.deltaTime;

        //if (time >= delayTime)
        //{
        //    time = 0f;
        //    if (target)
        //    {
        //        Vector3 dir = target.transform.position - this.transform.position;
        //        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        //    }
        //}

        if (target)
        {
            Vector3 dir = target.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        }



        this.transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + this.transform.forward, speed * Time.deltaTime);
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
}
