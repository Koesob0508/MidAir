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
        if (id != -1) return;
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
                
                break;
            case eType.Creatable:
                break;
            case eType.Buildable:
                break;
            case eType.Building:
                break;
        }
    }


=======
>>>>>>> f6f86a88375b783a32cc82ea4b2031975662e2d6
}