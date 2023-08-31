using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 300;
    public Material defaultMaterial;
    public Material damageMaterial;
    public GameObject target;
    private int damageDuration = 15;
    private int leftoverDuration;

    public float movementSpeed;
    public bool isAgressive = false;
    public bool isFlying = false;
    public bool isShooting = false;
    public GameObject projectile;
    public float shootingSpeed;
    private float shootCooldown;


    private void Start()
    {
        leftoverDuration = 0;
        shootCooldown = shootingSpeed;
    }

    private void Update()
    {
        if( leftoverDuration <= 0 )
        {
            changeMaterial(defaultMaterial);
        }
        else leftoverDuration--;
        if (isAgressive)
        {
            Vector3 dif;
            if (!isFlying)
            {
                dif = target.transform.position - transform.position;
                dif = new Vector3(dif.x, 0, dif.z);
            }
            else
            {
                dif = target.transform.position+Vector3.up*4 - transform.position;
            }
            dif.Normalize();
            transform.position += dif * movementSpeed;
            if (!isShooting) return;
            if (shootCooldown <= 0)
            {
                FireShot();
            }
            else shootCooldown--;
        }
    }



    public void Bleed(float dmg)
    {
        if (HP > 0)
        {
            HP -= Mathf.RoundToInt(dmg);
            Debug.Log($"HP = {HP}");
            changeMaterial(damageMaterial);
        }
        if (HP <= 0)
        {
            Debug.Log("aa i am ded");
            this.gameObject.SetActive(false);
        }
    }

    private void changeMaterial(Material mat)
    {
        if (mat == null) return;
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer == null) return;
        renderer.material = mat;
        leftoverDuration = damageDuration;
    }

    private void FireShot()
    {
        Vector3 shotPosition = transform.position;
        if (isFlying) shotPosition -= Vector3.up * 1.5f;
        else shotPosition += Vector3.up * 1.5f;

        GameObject instance = Instantiate(projectile, shotPosition, Quaternion.identity);
        Projectile pInstance = instance.GetComponent<Projectile>();
        if (pInstance != null)
        {
            pInstance.direction = ((target.transform.position + Vector3.up*.3f)- shotPosition).normalized / 10;
        }
        shootCooldown = shootingSpeed;
    }
}
