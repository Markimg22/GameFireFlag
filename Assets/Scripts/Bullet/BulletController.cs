using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Photon.Pun
{
    public class BulletController : MonoBehaviour
    {
        #region PRIVATE FIELDS

        private float _bulletSpeed = 4f;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Transform _crossHair;

        #endregion

        
        #region GET & SET
        
        public Transform CrossHair{ get{return _crossHair;} set{this._crossHair = value;} }

        #endregion


        #region OnEnable & OnDisable

        private void OnEnable() 
        {
            // Direction
            if( _crossHair != null )
            {
                _direction = _crossHair.position - this.transform.position;
            }
        }

        private void OnDisable() 
        {
            _rigidbody.velocity = Vector2.zero;
        }

        #endregion


        #region UNITY

        private void Awake() 
        {
            _rigidbody = GetComponent<Rigidbody2D>(); 
        }

        private void FixedUpdate() 
        {
            // Move
            _rigidbody.velocity = _direction.normalized * _bulletSpeed;    
        }

        #endregion
    }
}
