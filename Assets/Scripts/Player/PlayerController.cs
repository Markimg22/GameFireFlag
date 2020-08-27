using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class PlayerController : MonoBehaviourPun, IPunObservable
    {
        public static GameObject LocalPlayerInstance;

        #region Private Fields    
        
        private float _speed = 0.8f;
        private Vector2 _direction;
        public Vector2 Direction { get{return _direction;} set{this._direction = value;} }

        private Animator _animator;
        private Rigidbody2D _rigidbody;

        #endregion


        #region Unity

        private void Awake() 
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();   

            if( photonView.IsMine )
            {
                LocalPlayerInstance = this.gameObject;
            }

            DontDestroyOnLoad( this.gameObject );
        }

        private void Update()
        {
            if( !photonView.IsMine && PhotonNetwork.IsConnected )
            {
                return;
            }
            
            // Move
            _direction = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );

            // Flip
            if( _direction.x > 0f )
            {
                // right
                this.transform.localScale = new Vector2( 1f, 1f );
            }
            else if( _direction.x < 0f )
            {
                // left
                this.transform.localScale = new Vector2( -1f, 1f );
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


        #region IPunObservable implemantation

        public void OnPhotonSerializeView( PhotonStream stream, PhotonMessageInfo info )
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}

