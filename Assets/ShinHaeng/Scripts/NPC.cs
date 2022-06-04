using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] Island island;

    private void Awake()
    {
        island = GetComponent<Island>();
        island.PurposePosition = island.transform.position;
    }

    private void Start()
    {
    }

}