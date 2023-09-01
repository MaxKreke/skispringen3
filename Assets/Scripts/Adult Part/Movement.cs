using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private static float maxSpeed = 25;
    private Rigidbody body;
    public bool grounded = false;
    public float jumpforce = 10;
    public float speed = 1;
    public LayerMask GroundLayers;
    public Camera ownCamera;
    public Vector3 respawn;
    public float HP = 150;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        JumpAndGravity();
        GroundedCheck();
        if (grounded)Move();
        else Move(true);
        ClampSpeed();
        DeathCheck();
        
    }

    private void JumpAndGravity()
    {
        if (grounded && Input.GetKeyDown("space"))
        {
            body.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    private void GroundedCheck()
    {
        grounded = Physics.CheckSphere(transform.position, .6f, GroundLayers);
    }

    private void Move(bool air = false)
    {
        float horizontalRotation = ownCamera.GetComponent<CameraRotation>().horizontalRotation;
        Vector3 force = Vector3.zero;
        switch (Direction())
        {
            case 0:
                force = Vector3.forward * speed;
                break;
            case 1:
                force = (Vector3.forward + Vector3.right).normalized * speed;
                break;
            case 2:
                force = Vector3.right * speed;
                break;
            case 3:
                force = (Vector3.right + Vector3.back).normalized * speed;
                break;
            case 4:
                force = Vector3.back * speed;
                break;
            case 5:
                force = (Vector3.back + Vector3.left).normalized * speed;
                break;
            case 6:
                force = Vector3.left * speed;
                break;
            case 7:
                force = (Vector3.left + Vector3.forward).normalized * speed;
                break;
            default:
                if(!air)body.velocity /= 1.1f;
                break;
        }
        Vector3 dir = Quaternion.AngleAxis(horizontalRotation, Vector3.up) * Vector3.forward;
        Vector3 rotatedForce = Quaternion.AngleAxis(horizontalRotation, Vector3.up) * force;

        float horizontalVelocity = new Vector2(body.velocity.x, body.velocity.z).magnitude;
        if (horizontalVelocity < 10) horizontalVelocity *= 2.5f;

        float currentSpeed = Vector3.ProjectOnPlane(body.velocity, Vector3.up).magnitude;
        float relativeSpeed = Vector3.Dot(rotatedForce, body.velocity);
        if (force != Vector3.zero)
        {
            body.velocity = Vector3.ClampMagnitude(rotatedForce.normalized * (currentSpeed + relativeSpeed) / 2, 150) + body.velocity.y * Vector3.up;
            if(!air) ApplyForce(rotatedForce * 8);
            else ApplyForce(rotatedForce * .5f);

        }
    }

    /*  
     *  -1: none
     *  0: forward
     *  1: diagonal
     *  2: right
     *  3: diagonal
     *  4: back
     *  5: diagonal
     *  6: left
     *  7: diagonal
    */
    private int Direction()
    {
        bool forward = (Input.GetKey("w") || Input.GetKey("u") || Input.GetKey("up"));
        bool right = (Input.GetKey("d") || Input.GetKey("k") || Input.GetKey("right"));
        bool back = (Input.GetKey("s") || Input.GetKey("j") || Input.GetKey("down"));
        bool left = (Input.GetKey("a") || Input.GetKey("h") || Input.GetKey("left"));

        if (forward)
        {
            if (right && !left) return 1;
            if (!right && left) return 7;
            if (!back) return 0;
        }
        if (back)
        {
            if (right && !left) return 3;
            if (!right && left) return 5;
            if (!forward) return 4;
        }
        if (right && !left) return 2;
        if (!right && left) return 6;
        return -1;
    }

    private void ClampSpeed()
    {
        Vector3 velocity = body.velocity;
        Vector3 modifiedVelocity = Vector3.ProjectOnPlane(velocity, Vector3.up);
        float ratio = modifiedVelocity.magnitude / maxSpeed;
        if (ratio > 1) modifiedVelocity /= ratio;
        modifiedVelocity = new Vector3(modifiedVelocity.x, velocity.y, modifiedVelocity.z);
        body.velocity = modifiedVelocity;
    }

    private void DeathCheck()
    {
        if (transform.position.y < -100)
        {
            HP -= 10;
            transform.position = respawn;
            Debug.Log(HP);
        }
        if (HP <= 0) Death();
    }

    private void Death()
    {
        Debug.LogError("DEATH");
        Application.Quit();
    }

    public void ApplyForce(Vector3 force)
    {
        body.AddForce(force);
    }

}
