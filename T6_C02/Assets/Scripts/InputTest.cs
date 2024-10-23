using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public GameObject laserPrefab;

    public Collider L_coll;
    public GameObject Hand;
    public void OnAimPose(InputAction.CallbackContext context)
    {
        // CHECK FOR ACTION
        if (context.performed)
        {
            // GRAB VALUE
            var aimPose = context.ReadValue<Pose>();

            // CREATE LASER
            //Ray ray = Hand.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //if (L_coll.Raycast(ray, out hit, 100.0f))
            //{
                // Teleport Camera With Adjusted Y
                //m_MainCamera.transform.position = new Vector3(hit.point.x, cameraposY, hit.point.z);
            //}
        }
    
    }
}
