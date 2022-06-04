using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    //UnityAction inputAction;
    [SerializeField] GameManager GameManager;
    [SerializeField] Camera _camera;
    [SerializeField] Island island;
    [SerializeField] int skyLayerMask;
    [SerializeField] int tileLayerMask;
    [SerializeField] GameObject currentBuilding;

    private void Awake()
    {
        this._camera = Camera.main;
        GameManager = GameManager.instance;
        island = GetComponent<Island>();
        skyLayerMask = 1 << LayerMask.NameToLayer("Sky");
        tileLayerMask = 1 << LayerMask.NameToLayer("Tile");
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Shoot");
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, skyLayerMask))
            {
                Debug.Log(hit.collider.name);
                var pos = hit.point;
                pos.y = 0f;
                island.PurposePosition = pos;
                //var marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //marker.transform.position = hit.point;
                //Destroy(marker, 2f);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentBuilding)
            {
                Debug.Log(currentBuilding);
                if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, Mathf.Infinity, tileLayerMask))
                {
                    Debug.Log(hit.collider.name);
                    island.Build(hit.collider.GetComponent<Tile>(), currentBuilding);
                    //Debug.Log(hit.collider.GetComponent<Building>().name);
                    currentBuilding = null;
                }
            }
            
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            currentBuilding = GameManager.Wall;
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            currentBuilding = GameManager.House;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            currentBuilding = GameManager.Turret;
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            currentBuilding = GameManager.Mast;
        }

    }
}