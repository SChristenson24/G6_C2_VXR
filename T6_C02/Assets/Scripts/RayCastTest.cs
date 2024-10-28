using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.InputSystem;
using JetBrains.Annotations;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class RayCastTest : MonoBehaviour
{
    // Ray
    Ray ray;

    // Reference to Action
    public InputActionReference TeleportAction;

    // Camera
    private Camera m_MainCamera;

    // GameObject for Rig
    public GameObject teleportPanel;

    private void Awake()
    {
        // Enables Action
        TeleportAction.action.Enable();

        // Function Call to send to next step
        TeleportAction.action.performed += teleportRay;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initial Camera Position
        m_MainCamera = Camera.main;
    }

    private void OnDestroy()
    {
        // Destructor
        TeleportAction.action.Disable();
        TeleportAction.action.performed -= teleportRay;
    }


    void teleportRay(InputAction.CallbackContext context)
    {
        // Ray initialization
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
            //teleportPanel.transform.position = new Vector3(hit.point.x, cameraposY, hit.point.z);
            teleportPanel.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        else
        {
            Debug.Log("Raycast did not hit anything");
        }
    }
}
