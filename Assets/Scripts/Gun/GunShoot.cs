﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunShoot : MonoBehaviour
{
    public GameObject prefabBullet;
    private Transform _firepoint;

    private List<GameObject> _listBullets = new List<GameObject>();

    private int _amountBullets = 5;
    private float _delayShoot = 0.5f;
    private float _livingBullet = 1.5f;

    private bool _canShoot = true;


    public Transform FirePoint{
        get{
            return _firepoint;
        }
        set{
            this._firepoint = value;
        }
    }

    private void Awake() 
    {
        _firepoint = transform.Find( "Fire Point" );
    }

    private void Start() 
    {
        AddBullets();
    }

    private void OnEnable() 
    {
        _canShoot = true;    
    }

    private void Update() 
    {
        // Shoot
        if( Input.GetButtonDown("Fire1") && _canShoot ){
            StartCoroutine( "Shoot" );
            StartCoroutine( "DelayShoot" );
        }
    }

    private void AddBullets()
    {
        // Add Bullets on Gun
        for( int i = 0; i < _amountBullets; i++ ){
            
            GameObject bullet = Instantiate( prefabBullet, _firepoint.position, Quaternion.identity, this.transform );
            bullet.SetActive( false );

            _listBullets.Add( bullet );
        }
    }

    private IEnumerator Shoot()
    {
        GameObject bullet = null;

        for( int i = 0; i < _listBullets.Count; i++ ){

            if( !_listBullets[i].activeSelf ){
                
                bullet = _listBullets[i].gameObject;
                break;
            }
        }

        // Active Bullet
        bullet.transform.parent = null;
        bullet.SetActive( true );  

        /**
        * Temporary
        */
        // Disable Bullet after one time
        yield return new WaitForSeconds( _livingBullet );
        
        if( bullet.activeSelf ){
            bullet.SendMessage( "ResetBullet" );
        }
    }

    private IEnumerator DelayShoot()
    {
        _canShoot = false;
        yield return new WaitForSeconds( _delayShoot );
        _canShoot = true;
    }
}