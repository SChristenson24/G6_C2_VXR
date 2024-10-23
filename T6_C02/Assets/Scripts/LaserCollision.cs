using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    // Laser Beam
    //public GameObject TestLaser;

    public InputAction AimBeam;

    // Camera
    private Camera m_MainCamera;

    public Collider coll;
    void Start()
    {
        coll = GetComponent<Collider>();

        // Initial Camera Position
        m_MainCamera = Camera.main;
    }

    void Update()
    {
        // Get Camera Y-Coords
        float cameraposY = m_MainCamera.transform.position.y;

        // Wait for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (coll.Raycast(ray, out hit, 100.0f))
            {
                // Teleport Camera With Adjusted Y
                m_MainCamera.transform.position = new Vector3(hit.point.x, cameraposY, hit.point.z);
            }
        }
    }

    //// On Start
    //private void Start()
    //{
    //    // Initial Camera Popsotion
    //    m_MainCamera = Camera.main;
    //}

    //// On Update
    //private void Update()
    //{
    //    // Get Camera Y-Coords
    //    float prevcamerapos = m_MainCamera.transform.position.y;
    //}

    //// On Collision
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // Waits for Signal
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        // Get Coords of Collision
    //        ContactPoint contact = collision.contacts[0];
    //        Vector3 position = contact.point;

    //        // Teleport Camera
    //        m_MainCamera.transform.position = position;
    //    }
    //}
}
