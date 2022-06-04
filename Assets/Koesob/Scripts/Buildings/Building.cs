using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    private float health;

    public abstract void Activate();

    public virtual void Deactivate()
    {
        Destroy(this.gameObject);
    }

    public virtual void GetDamage(Building _attackBuilding, float _damage)
    {
        if (health > _damage)
        {
            health -= _damage;
        }
        else
        {
            Deactivate();
        }
    }
}
