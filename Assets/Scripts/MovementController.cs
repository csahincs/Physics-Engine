using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private cyclone.Vector3 leftVector;
    private cyclone.Vector3 rightVector;
    private cyclone.Vector3 downVector;
    private cyclone.Vector3 upVector;



    // Start is called before the first frame update
    void Start()
    {
        leftVector = new cyclone.Vector3(-1f, 0f, 0f);
        rightVector = new cyclone.Vector3(1f, 0f, 0f);
        downVector = new cyclone.Vector3(0f, -1f, 0f);
        upVector = new cyclone.Vector3(0f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.A))
            transform.position += new Vector3(leftVector.x, leftVector.y, leftVector.z);
        if (Input.GetKeyDown(KeyCode.D))
            transform.position += new Vector3(rightVector.x, rightVector.y, rightVector.z);
        if (Input.GetKeyDown(KeyCode.S))
            transform.position += new Vector3(downVector.x, downVector.y, downVector.z);
        if (Input.GetKeyDown(KeyCode.W))
            transform.position += new Vector3(upVector.x, upVector.y, upVector.z);
    }
}
