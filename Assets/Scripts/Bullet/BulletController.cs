using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Photon.Pun
{
    public class BulletController : MonoBehaviour
    {
        #region PRIVATE FIELDS

        private float _bulletSpeed = 3f;
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Transform _crossHair;

        private float _lifeBullet = 2f;

        #endregion

        
        #region GET & SET
        
        public Transform CrossHair{ get{return _crossHair;} set{this._crossHair = value;} }

        #endregion


        #region UNITY

        private void Awake() 
        {
            _rigidbody = GetComponent<Rigidbody2D>(); 
        }

        private void Start() 
        {
            _direction = _crossHair.position - this.transform.position;
        }
        
        private void FixedUpdate() 
        {
            _rigidbody.velocity = _direction.normalized * _bulletSpeed;    
        }

        #endregion


        #region ON ENABLE

        private void OnEnable() 
        {
            Destroy( this.gameObject, _lifeBullet );
        }

        #endregion
    }
}
