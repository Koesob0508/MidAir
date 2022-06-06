using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GameObject player;
    [SerializeField] bool OnMouseControll = false;
    [SerializeField] float panSpeed = 10f;
    [SerializeField] float panBorderThickness = 10f;
    [SerializeField] float height = 20f;
    [SerializeField] float zDistance = -12f;

    // Use this for initialization
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    
    // Update is called once per frame
    void LateUpdate()
    {
        var cameraPos = transform.position;
        var mousePos = Input.mousePosition;

        Vector2 wheelInput = Input.mouseScrollDelta;
        //if (wheelInput.y > 0)    
        //{        wheelInput
        //         }    
        //else if (wheelInput.y < 0)    
        //{        // 휠을 당겨 올렸을 때의 처리 ↓   
        //         }
        //height -= wheelInput.y;
        _camera.orthographicSize -= wheelInput.y;


        if (Input.GetKey(KeyCode.Space) && player)
        {
            var playerPos = player.transform.position;

            cameraPos.x = playerPos.x;
            cameraPos.y = height;
            cameraPos.z = playerPos.z + zDistance;
        }
        else
        {
            if (OnMouseControll)
            {
                if (mousePos.x > (Screen.width - panBorderThickness))
                {
                    cameraPos.x += panSpeed * Time.deltaTime;
                }
                else if (mousePos.x < panBorderThickness)
                {
                    cameraPos.x -= panSpeed * Time.deltaTime;
                }

                if (mousePos.y > (Screen.height - panBorderThickness))
                {
                    cameraPos.z += panSpeed * Time.deltaTime;
                }
                else if (mousePos.y < panBorderThickness)
                {
                    cameraPos.z -= panSpeed * Time.deltaTime;
                }
            }
        }

        transform.position = cameraPos;
        
    }

    public void SetPlayer(GameObject gameObject)
    {
        this.player = gameObject;
    }
}