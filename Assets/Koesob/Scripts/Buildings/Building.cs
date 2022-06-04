using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Building : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] private Island island;
    [SerializeField] private Tile tile;
    [SerializeField] private int mainId;
    [SerializeField] public UnityAction<Building> destroyAction;

    public Tile Tile { get => tile; private set => tile = value; }

    public virtual void Activate(Island _island, Tile tile)
    {
        island = _island;
        this.tile = tile;
        mainId = island.Id;
    }

    public virtual void Deactivate()
    {
        destroyAction?.Invoke(this);
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
