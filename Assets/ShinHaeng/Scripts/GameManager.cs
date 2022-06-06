using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject islandPrefab;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject core;
    [SerializeField] GameObject house;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject mast;

    public GameObject Wall { get => wall; private set => wall = value; }
    public GameObject Core { get => core; private set => core = value; }
    public GameObject House { get => house; private set => house = value; }
    public GameObject Turret { get => turret; private set => turret = value; }
    public GameObject Mast { get => mast; private set => mast = value; }

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
        SetIsland(islands);
    }

    private void SetIsland(List<Island> islands)
    {
        int ran = Random.Range(0, islands.Count);

        for (int i = 0; i < islands.Count; i++)
        {
            if (i == ran)
            {
                islands[i].gameObject.AddComponent<Character>();
                islands[i].gameObject.AddComponent<InputManager>();
                islands[i].name = "Island_Player";
                Camera.main.GetComponent<CameraController>().SetPlayer(islands[i].gameObject);
            }
            else
            {
                islands[i].gameObject.AddComponent<NPC>();
                islands[i].name = "Island_NPC_" + i;
            }
        }
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

            float border = 10f;
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