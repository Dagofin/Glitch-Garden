using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileSpawn;

    public void Fire()
    {

        Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);


    }

}
