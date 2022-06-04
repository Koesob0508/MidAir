﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject islandPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
    }

    private void Start()
    {
        var islands = InstantiateIsland(4);
        PickPlayer(islands);
    }

    private void PickPlayer(List<Island> islands)
    {
        int ran = Random.Range(0, islands.Count);
        islands[ran].gameObject.AddComponent<InputManager>();
    }

    /// <summary>
    /// 최초 게임 시작 시 섬 생성
    /// </summary>
    /// <param name="count">섬 갯수</param>
    List<Island> InstantiateIsland(int count)
    {
        var list = new List<Island>(count);
        for (int i = 0; i < count; i++)
        {
            var island = Instantiate(islandPrefab);

            float border = 100f;
            float ranX = Random.Range(-border, border);
            float ranZ = Random.Range(-border, border);
            Vector3 ranPos = new Vector3(ranX, 0, ranZ);
            island.transform.position = ranPos;

            island.GetComponent<Island>().Init(i);
            list.Add(island.GetComponent<Island>());
        }

        return list;
    }
}