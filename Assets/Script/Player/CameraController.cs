using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables:
    [Header("Player")]
    //Referense player object
    public Transform playerTransform;
    public bool LookAtPlayer = true;

    [Header("Camera")]
    //the camera's distance from player
    private Vector3 camoffset;
    public bool RotateAroundPlayer = true;
    public float RotationSpeed = 2.0f;
    public float smoothTime = 0.1f;


    // Start is called before the first frame update
    public void Start()
    {
        camoffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    // LateUpdate is called after Update methods
    void LateUpdate()
    {

        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngleX = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            camoffset = camTurnAngleX * camoffset;
        }
        Vector3 newPos = playerTransform.position + camoffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothTime);

        if(LookAtPlayer || RotateAroundPlayer)
        {
            transform.LookAt(playerTransform);
        }
    }
}






