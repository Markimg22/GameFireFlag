using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Photon.Pun
{
    public class PlayerShooting : MonoBehaviour
    {
        #region PUBLIC FIELDS

        [ Header("Bullet Prefab") ]
        public GameObject bulletPrefab;

        [ Header( "Color Player" ) ]
        public string color;

        #endregion


        #region PRIVATE FIELDS

        private bool _canShoot;
        private Transform _firePoint;
        private PlayerController _playerController;
        
        private float _delayShoot = 0.5f;

        #endregion


        #region UNITY

        private void Awake() 
        {
            _firePoint = transform.Find( $"Gun {color}/Fire Point" );
            _playerController = this.gameObject.GetComponent<PlayerController>();
        }

        private void Start() 
        {
            _canShoot = true;    
        }

        private void Update() 
        {
            // Can Shoot
            if( Input.GetButtonDown("Fire1") && _canShoot && _playerController.photonView.IsMine )
            {
                _playerController.photonView.RPC( "Shoot", RpcTarget.All );
                StartCoroutine( "DelayShoot" );
            }
        }

        #endregion


        #region PUNRPC METHODS

        [ PunRPC ]
        private void Shoot()
        {
            GameObject bullet = Instantiate( bulletPrefab, _firePoint.position, _firePoint.transform.rotation );
            bullet.GetComponent<BulletController>().CrossHair = _firePoint.Find( "Cross Hair" );
        }

        #endregion


        #region COROUNTINES

        private IEnumerator DelayShoot()
        {
            _canShoot = false;
            yield return new WaitForSeconds( _delayShoot );
            _canShoot = true;
        }

        #endregion
    }
}
