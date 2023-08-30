using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 300;
    public Material defaultMaterial;
    public Material damageMaterial;
    private int damageDuration = 15;
    private int leftoverDuration;


    private void Start()
    {
        leftoverDuration = 0;
    }

    private void Update()
    {
        if( leftoverDuration <= 0 )
        {
            changeMaterial(defaultMaterial);
        }
        else leftoverDuration--;
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
}
