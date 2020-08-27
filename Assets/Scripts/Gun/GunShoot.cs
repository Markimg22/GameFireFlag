using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
    public class GunShoot : MonoBehaviour
    {
        #region Private Fields

        public GameObject prefabBullet;
        private List<GameObject> _listBullets = new List<GameObject>();
        private Transform _firepoint;
        public Transform FirePoint { get{return _firepoint;} set{this._firepoint = value;} }

        private int _amountBullets = 5;
        private float _delayShoot = 0.5f;
        private float _livingBullet = 1.5f;

        private bool _canShoot = true;

        #endregion


        #region Unity

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
            if( Input.GetButtonDown("Fire1") && _canShoot )
            {
                // Shoot
                StartCoroutine( "Shoot" );
                StartCoroutine( "DelayShoot" );
            }
        }

        #endregion


        #region Private Methods

        /// <summary>
        /// Adds five bullets to the weapon.
        /// </summary>
        private void AddBullets()
        {
            for( int i = 0; i < _amountBullets; i++ )
            {    
                // Add Bullets on Gun
                GameObject bullet = Instantiate( prefabBullet, _firepoint.position, Quaternion.identity, this.transform );
                bullet.SetActive( false );

                _listBullets.Add( bullet );
            }
        }

        /// <summary>
        /// Called when player performs shooting action.
        /// </summary>
        private IEnumerator Shoot()
        {
            GameObject bullet = null;

            for( int i = 0; i < _listBullets.Count; i++ )
            {
                if( !_listBullets[i].activeSelf )
                {    
                    bullet = _listBullets[i].gameObject;
                    break;
                }
            }

            // Active Bullet
            bullet.transform.parent = null;
            bullet.SetActive( true );  

            // Disable Bullet after one time
            yield return new WaitForSeconds( _livingBullet );
            
            if( bullet.activeSelf )
            {
                bullet.SendMessage( "ResetBullet" );
            }
        }

        /// <summary>
        /// Waiting time for each shot.
        /// </summary>
        private IEnumerator DelayShoot()
        {
            _canShoot = false;
            yield return new WaitForSeconds( _delayShoot );
            _canShoot = true;
        }

        #endregion
    }
}