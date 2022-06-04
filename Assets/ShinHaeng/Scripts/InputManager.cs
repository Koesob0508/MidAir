using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    //UnityAction inputAction;
    [SerializeField] Camera _camera;
    [SerializeField] Island Island;
    [SerializeField] int skyMask = 10;

    private void Awake()
    {
        this._camera = Camera.main;
        Island = GetComponent<Island>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(-1))
        {
            //RaycastHit raycastHit = Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition),
            //    out RaycastHit hit, skyMask);
            //Island.Move(Input.mousePosition);
        }
    }
}