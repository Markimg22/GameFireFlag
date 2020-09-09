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
        
        private float _delayShoot = 0.2f;

        private int _amountBullets = 10;
        private List<GameObject> _listBullets = new List<GameObject>();

        #endregion


        #region UNITY

        private void Awake() 
        {
            _firePoint = transform.Find( $"Gun/Fire Point" );
            _playerController = this.gameObject.GetComponent<PlayerController>();
        }

        private void Start() 
        {
            _canShoot = true;    

            // Add Bullets
            for( int i = 0; i < _amountBullets; i++ )
            {
                GameObject bullet = Instantiate( bulletPrefab, _firePoint.position, _firePoint.rotation, _firePoint.parent );
                bullet.SetActive( false );

                _listBullets.Add( bullet );
            }

        }

        private void Update() 
        {
            // Can Shoot?
            if( Input.GetButton("Fire1") && _canShoot && _playerController.photonView.IsMine )
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
            GameObject bullet = null;

            // Bullet is Active?
            for( int i = 0; i < _listBullets.Count; i++ )
            {
                if( !_listBullets[i].activeSelf )
                {
                    bullet = _listBullets[i];
                    break;
                }
            }  

            // Get CrossHair
            bullet.GetComponent<BulletController>().CrossHair = _firePoint.Find( "Cross Hair" );

            // Active Bullet
            bullet.transform.parent = null;
            bullet.SetActive( true );


            // Reset Bullet
            StartCoroutine( "ResetBullet", bullet );
        }

        #endregion


        #region COROUNTINES

        private IEnumerator DelayShoot()
        {
            _canShoot = false;
            yield return new WaitForSeconds( _delayShoot );
            _canShoot = true;
        }

        // Temporário
        private IEnumerator ResetBullet( GameObject bullet )
        {
            yield return new WaitForSeconds( 2f );

            bullet.SetActive( false );
            bullet.transform.position = _firePoint.position;
            bullet.transform.parent = _firePoint.parent;
        }

        #endregion
    }
}
