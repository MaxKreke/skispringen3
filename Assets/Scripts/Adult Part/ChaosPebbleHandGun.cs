using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosPebbleHandGun : MonoBehaviour
{
    private int animationFrames = 0;
    private int animationSpeed = 9;
    public GameObject projectile;
    public Transform container;

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
            pInstance.direction = (Camera.main.gameObject.transform.rotation)*Vector3.forward/5;
            pInstance.transform.SetParent(container);
        }
    }

}
