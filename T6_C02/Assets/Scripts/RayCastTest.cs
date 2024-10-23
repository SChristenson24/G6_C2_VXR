using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.InputSystem;
using JetBrains.Annotations;
using UnityEngine.InputSystem.HID;

public class RayCastTest : MonoBehaviour
{
    // Ray
    Ray ray;

    // Reference to Action
    public InputActionReference TeleportAction;
    // Camera
    private Camera m_MainCamera;

    private void Awake()
    {
        // Enables Action
        //TeleportAction.action.Enable();

        TeleportAction.action.started += CheckForColliders;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ray Initialization
        ray = new Ray(transform.position, transform.forward);

        // Initial Camera Position
        m_MainCamera = Camera.main;
        
        // Enables Action
        //TeleportAction.action.Enable();
    }

    private void OnDestroy()
    {
        TeleportAction.action.started -= CheckForColliders;
    }


    void CheckForColliders(InputAction.CallbackContext context)
    {
        ray = new Ray(transform.position, transform.forward);

        // Deploy Ray
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Check For Hit
            Debug.Log("Hit: " + hit.collider.name);

            // Display Ray
            Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

            // Get Camera Y-Coords
            float cameraposY = m_MainCamera.transform.position.y;

            // Teleport Camera With Adjusted Y
            m_MainCamera.transform.position = new Vector3(hit.point.x, cameraposY, hit.point.z);
        }

        else
        {
            Debug.Log("Raycast did not hit anything");
        }
    }
}
