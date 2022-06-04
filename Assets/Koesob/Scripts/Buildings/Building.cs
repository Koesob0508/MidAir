using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] private Island mainIsland;
    [SerializeField] private int mainId;

    public virtual void Activate(Island _island)
    {
        mainIsland = _island;
        mainId = mainIsland.Id;
    }

    public virtual void Deactivate()
    {
        Destroy(this.gameObject);
    }

    public virtual void GetDamage(Building _attackBuilding, float _damage)
    {
        if (this.health > _damage)
        {
            this.health -= _damage;
        }
        else
        {
            Deactivate();
        }
    }

    public int GetId()
    {
        return mainId;
    }
}
