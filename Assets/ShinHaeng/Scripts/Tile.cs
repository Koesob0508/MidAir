using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum eType
    {
        none = 0, Creatable, Buildable, Building
    }

    [SerializeField] int id = -1;
    [SerializeField] int x;
    [SerializeField] int z;
    [SerializeField] eType type;

    public int Id => id;

    public eType Type { get => type; private set => type = value; }

    private void Awake()
    {
        Type = eType.none;
    }

    public void Init(int id, int x, int z)
    {
        if (this.id != -1) return;
        SetType(eType.none);
        this.id = id;
        this.x = x;
        this.z = z;
    }

    public void SetType(eType type)
    {
        this.Type = type;

        switch (type)
        {
            case eType.none:
                gameObject.SetActive(false);
                break;
            case eType.Creatable:
                gameObject.SetActive(false);
                break;
            case eType.Buildable:
                gameObject.SetActive(true);
                break;
            case eType.Building:
                gameObject.SetActive(true);
                break;
        }
    }
}