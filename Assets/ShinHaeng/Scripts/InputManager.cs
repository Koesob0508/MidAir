using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    //UnityAction inputAction;
    [SerializeField] Camera _camera;
    [SerializeField] Island Island;
    [SerializeField] int skyLayerMask;
    [SerializeField] int objectLayerMask;

    private void Awake()
    {
        this._camera = Camera.main;
        Island = GetComponent<Island>();
        skyLayerMask = 1 << LayerMask.NameToLayer("Sky");
        objectLayerMask = 1 << LayerMask.NameToLayer("Build");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, skyLayerMask)) ;
                //Island.Move(hit);
        }

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, objectLayerMask))
                Debug.Log(hit.collider.GetComponent<Building>().name);
        }
    }
}