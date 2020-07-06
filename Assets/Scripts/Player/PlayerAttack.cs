using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public GameObject prefabBullet;
    private bool _canShoot;
    private Transform _firePoint;


    private void Awake() 
    {
        _firePoint = GameObject.Find( "Fire Point" ).transform;
    }

    private void Start() 
    {
        _canShoot = true;    
    }

    private void Update()
    {
        // Can Shoot?
        if( Input.GetButtonDown("Fire1") && _canShoot ){
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate( prefabBullet, _firePoint.position, Quaternion.identity );
        Destroy( bullet, 1f );
    }
    
}
