using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapplendix : MonoBehaviour
{
    private LineRenderer lr;
    private Rigidbody body;
    private SpringJoint joint;
    private Vector3 target;

    public GameObject parentAdult;
    public Camera ownCamera;
    public LayerMask boxLayers;
    private float maximalDistanz = 100f;

    void Start()
    {
        body = parentAdult.GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CutLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, ownCamera.transform.TransformDirection(Vector3.forward), out hit, maximalDistanz, boxLayers))
            {
                target = hit.point;
                joint = parentAdult.AddComponent<SpringJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = target;

                float distanceFromPoint = Vector3.Distance(parentAdult.transform.position, target);

                joint.maxDistance = distanceFromPoint * 0.8f;
                joint.minDistance = 0.25f;
                joint.spring = 4.5f;
                joint.damper = 7.0f;
                joint.massScale = 4.5f;
                lr.positionCount = 2;
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            CutLine();
        }
    }

    public void CutLine()
    {
        lr.positionCount = 0;
        Destroy(joint);
        target = Vector3.zero;
    }

    private void LateUpdate()
    {
        drawRope();

    }

    private void drawRope()
    {
        if (!joint) return;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, target);
    }
}
