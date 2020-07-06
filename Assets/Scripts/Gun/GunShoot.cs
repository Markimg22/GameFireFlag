using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunShoot : MonoBehaviour
{
    public GameObject prefabBullet;
    private Transform _firepoint;
    private List<GameObject> _listBullets = new List<GameObject>();

    private int _amountBullets = 2;
    private float _lifeBullet = 1f;
    private float _delayShoot = 0.8f;

    private bool _canShoot;


    private void Awake() 
    {
        _firepoint = transform.Find( "Fire Point" );
    }

    private void Start() 
    {
        _canShoot = true;
        AddBullets();
    }

    private void Update() 
    {
        if( Input.GetButtonDown("Fire1") && _canShoot ){

            StartCoroutine( "Shoot" );
            StartCoroutine( "DelayShoot" );
        }
    }

    private void AddBullets()
    {
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

        yield return new WaitForSeconds( _lifeBullet );

        // Reset Bullet
        bullet.SetActive( false );
        bullet.transform.position = _firepoint.position;
        bullet.transform.parent = this.transform;
    }

    private IEnumerator DelayShoot()
    {
        _canShoot = false;
        yield return new WaitForSeconds( _delayShoot );
        _canShoot = true;
    }
}