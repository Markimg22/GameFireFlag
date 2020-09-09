using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;


namespace Photon.Pun
{
    public class PlayerController : MonoBehaviour
    {
        #region PRIVATE FIELDS    
        
        private float _speed = 1.3f;
        private Vector2 _direction;

        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private PhotonView _photonView;

        #endregion


        # region GETT & SET

        public Vector2 Direction { get{return _direction;} set{this._direction = value;} }
        public PhotonView photonView{ get{return _photonView;} set{this._photonView = value;} }

        #endregion


        #region UNITY

        private void Awake() 
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();   
            _photonView = GetComponent<PhotonView>();

            DontDestroyOnLoad( this.gameObject );
        }

        private void Update()
        {   
            if( !_photonView.IsMine )
            {
                return;
            }

            // Get Direction
            _direction = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );

            // Flip Direction
            if( _direction.x > 0f )
            {
                // right
                this.transform.rotation = Quaternion.Euler( 0f, 0f, 0f );
            }
            else if( _direction.x < 0f )
            {
                // left
                this.transform.rotation = Quaternion.Euler( 0f, 180f, 0f );
            }
        }

        private void FixedUpdate() 
        {
            // Move
            _rigidbody.velocity = _direction * _speed;      
        }

        private void LateUpdate() 
        {   
            _animator.SetFloat( "Speed", _direction.magnitude );   
        }

        #endregion
    }
}

