using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Photon.Pun
{
    public class PlayerHealth : MonoBehaviour
    {
        #region PRIVATE FIELDS

        private int _life = 100;
        private RectTransform _lifeBar;
        private PlayerController _playerController;
    
        #endregion


        #region UNITY

        private void Awake() 
        {
            _lifeBar = transform.Find( "Canvas/Menu HUD/Life Bar" ).GetComponent<RectTransform>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Start() 
        {   
            // Reset Life
            _life = 100;
            _lifeBar.sizeDelta = new Vector2( 260f, _lifeBar.sizeDelta.y );
        }

        private void Update() 
        {
            if( _life <= 0 )
            {
                // Kill this Player
                Destroy( this.gameObject );
            }
        }

        #endregion


        #region HEALTH

        public void TakeDamage( int damage )
        {
            _playerController.photonView.RPC( "TakeDamageNetwork", RpcTarget.AllBuffered, damage );
        }

        [ PunRPC ]
        private void TakeDamageNetwork( int damage )
        {
            HealthManager( damage );
        }

        private void HealthManager( int damage )
        {
            this.gameObject.GetComponent<Animator>().SetTrigger( "Damage" );
            _lifeBar.sizeDelta = new Vector2( _lifeBar.sizeDelta.x - 65f, _lifeBar.sizeDelta.y );
            _life -= damage;
        }

        #endregion

    }
}
