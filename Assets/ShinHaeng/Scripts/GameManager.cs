using System.Collections;
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
        InstantiateIsland(4);
    }

    /// <summary>
    /// 최초 게임 시작 시 섬 생성
    /// </summary>
    /// <param name="count">섬 갯수</param>
    void InstantiateIsland(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var island = Instantiate(islandPrefab);
            island.GetComponent<Island>().Init(i);

            float border = 100f;
            float ranX = Random.Range(-border, border);
            float ranZ = Random.Range(-border, border);
            Vector3 ranPos = new Vector3(ranX, 0, ranZ);

            island.transform.position = ranPos;
        }
    }
}