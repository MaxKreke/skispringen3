using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosPebbleHandGun : MonoBehaviour
{
    private int animationFrames = 0;
    private int animationSpeed = 9;
    public GameObject projectile;
    public Transform container;
    public float projectileSpeed = .2f;

    public LayerMask boxLayers;
    private float maximalDistanz = 60;

    private void Update()
    {
        if (animationFrames != 0)animationFrames--;
        else if (Input.GetMouseButton(0))
        {
            Shoot();
            animationFrames = Mathf.RoundToInt(animationSpeed);
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
                Debug.Log(hit.point);
                pInstance.direction = (hit.point-transform.position).normalized*projectileSpeed;
            } else
            {
                pInstance.direction = (Camera.main.transform.rotation)*Vector3.forward*projectileSpeed;

            }
            pInstance.transform.SetParent(container);
        }
    }

}
