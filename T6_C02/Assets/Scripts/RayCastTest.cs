using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class RayCastTest : MonoBehaviour
{
    // Ray
    Ray ray;

    // Sphere For Testing
    public GameObject AreaPrefab;

    // Camera
    private Camera m_MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Ray Initialization
        ray = new Ray(transform.position, transform.forward);

        // Function Call to Further Deploy Ray
        CheckForColliders();

        // Initial Camera Position
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void CheckForColliders()
    {
        // Check For Trigger Hold
        //if (Input.GetMouseButtonDown(0))
        //{
            // Deploy Ray
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
            // Create Sphere
            GameObject Area = Instantiate(AreaPrefab, hit.point, Quaternion.identity);

                // Get Camera Y-Coords
                float cameraposY = m_MainCamera.transform.position.y;

                // Teleport Camera With Adjusted Y
                m_MainCamera.transform.position = new Vector3(hit.point.x, cameraposY, hit.point.z);
            }
        //}
    }
}
