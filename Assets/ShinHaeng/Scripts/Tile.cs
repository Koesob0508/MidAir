using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum eType
    {
        none = 0, Creatable, Buildable, Building
    }

    int id = -1;
    int x;
    int z;
    eType type;

    public int Id => id;

    private void Awake()
    {
        type = eType.none;
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
        this.type = type;

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