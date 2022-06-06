using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float panSpeed = 10f;
    [SerializeField] float panBorder = 10f;
    [SerializeField] float height = 20f;
    [SerializeField] float zDistance = -12f;

    // Use this for initialization
    void Start()
    {

    }

    
    // Update is called once per frame
    void LateUpdate()
    {
        var cameraPos = transform.position;
        var mousePos = Input.mousePosition;

        if (Input.GetKey(KeyCode.Space) && player)
        {
            var playerPos = player.transform.position;

            cameraPos.x = playerPos.x;
            cameraPos.y = height;
            cameraPos.z = playerPos.z + zDistance;
        }
        else
        {
            if (mousePos.x > (Screen.width - panBorder))
            {
                cameraPos.x += panSpeed * Time.deltaTime;
            }
            else if (mousePos.x < panBorder)
            {
                cameraPos.x -= panSpeed * Time.deltaTime;
            }

            if (mousePos.y > (Screen.height - panBorder))
            {
                cameraPos.z += panSpeed * Time.deltaTime;
            }
            else if (mousePos.y < panBorder)
            {
                cameraPos.z -= panSpeed * Time.deltaTime;
            }
        }

        transform.position = cameraPos;
    }

    public void SetPlayer(GameObject gameObject)
    {
        this.player = gameObject;
    }
}