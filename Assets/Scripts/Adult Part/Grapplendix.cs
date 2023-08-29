using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapplendix : MonoBehaviour
{
    //private Vector3 target;
    //private bool grappled = false;
    private LineRenderer lr;
    private Rigidbody body;
    private SpringJoint joint;
    public GameObject parentAdult;
    public Camera ownCamera;
    public LayerMask boxLayers;
    private float maximalDistanz = 150f;

    void Start()
    {
        body = parentAdult.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, ownCamera.transform.TransformDirection(Vector3.forward), out hit, maximalDistanz, boxLayers))
            {

            }
        }
    }

    //private void drawRope()
    //{
    //    if (!joint) return;
    //    lr.SetPosition(0, transform.position);
    //    lr.SetPosition(1, target);
    //}
}
