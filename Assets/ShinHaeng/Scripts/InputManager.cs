using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    //UnityAction inputAction;
    [SerializeField] Camera _camera;
    [SerializeField] Island island;
    [SerializeField] int skyLayerMask;
    [SerializeField] int objectLayerMask;


    private void Awake()
    {
        this._camera = Camera.main;
        island = GetComponent<Island>();
        skyLayerMask = LayerMask.NameToLayer("Sky");
        objectLayerMask = LayerMask.NameToLayer("Build");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Shoot");
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))//, skyLayerMask))
            {
                Debug.Log(hit.point);
                var pos = hit.point;
                pos.y = 0f;
                island.PurposePosition = pos;
                //var marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                //marker.transform.position = hit.point;
                //Destroy(marker, 2f);
            }
        }

        //if (Input.GetMouseButton(0))
        //{
        //    if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, objectLayerMask))
        //    {
        //        Debug.Log(hit.point);
        //        //Debug.Log(hit.collider.GetComponent<Building>().name);
        //    }
        //}
    }
}