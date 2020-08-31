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
            _lifeBar = GameObject.Find( "Life Bar" ).GetComponent<RectTransform>();
            _playerController = GetComponent<PlayerController>();
        }

        private void Update() 
        {
            if( _life <= 0 )
            {
                // Kill this Player
                this.gameObject.SetActive( false );
            }
        }

        private void OnEnable() 
        {   
            // Reset Life
            _life = 100;
            _lifeBar.sizeDelta = new Vector2( 260f, _lifeBar.sizeDelta.y );
        }

        #endregion


        #region METHODS

        public void AddDamage( int damage )
        {
            _playerController.photonView.RPC( "AddDamageNetwork", RpcTarget.AllBuffered, damage );
        }

        [ PunRPC ]
        private void AddDamageNetwork( int damage )
        {
            this.gameObject.GetComponent<Animator>().SetTrigger( "Damage" );
            _lifeBar.sizeDelta = new Vector2( _lifeBar.sizeDelta.x - 65f, _lifeBar.sizeDelta.y );
            _life -= damage;
        }

        #endregion

    }
}
