using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosPebbleHandGun : MonoBehaviour
{
    private int animationFrames = 0;
    private int animationSpeed = 9;
    public GameObject shot;
    public GameObject blast;
    public Transform container;
    public float projectileSpeed = .1f;

    public LayerMask boxLayers;
    public Weaponswitch ws;
    private float maximalDistanz = 60;
    private bool isBlasting;
    private GameObject projectile;

    private void Awake()
    {
        isBlasting = false;
        projectile = shot;
        Debug.Log("false");
    }

    private void Update()
    {
        if (animationFrames != 0)animationFrames--;
        else if (Input.GetMouseButton(0))
        {
            animationFrames = Mathf.RoundToInt(animationSpeed);
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
        Projectile pInstance = instance.GetComponent<Projectile>();

        if (pInstance != null)
        {

            //Check for shot direction
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, maximalDistanz, boxLayers))
            {
                pInstance.direction = (hit.point-transform.position).normalized*projectileSpeed;
            } else
            {
                pInstance.direction = (Camera.main.transform.rotation)*Vector3.forward*projectileSpeed;

            }
            pInstance.transform.SetParent(container);
        }
        if (isBlasting)
        {
            ws.Switch(-1f);
            ws.EmptyMana();
        }
    }

    public void Blastin(bool start)
    {
        isBlasting = start;
        if (isBlasting)
        {
            projectile = blast;
            projectileSpeed = .1f;
            animationSpeed = 120;
        }
        else
        {
            projectile = shot;
            projectileSpeed = .2f;
            animationSpeed = 9;
        }
    }

}
