using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
    public class FlagController : MonoBehaviour
    {
        #region Private Fields

        private Animator _animator;
        private bool _isCaptured;
        private GameObject _gun;

        private bool _canGet;
        private bool _canPut;

        private GameObject _flag;
        private GameObject _putFlag;

        #endregion


        #region Unity

        private void Awake() 
        {
            _animator = GetComponent<Animator>();
        }

        private void Update() 
        {
            if( _canGet && Input.GetKeyDown(KeyCode.E))
            {
                // Can Get Flag
                GetFlag( _flag );
            }

            if( _canPut && Input.GetKeyDown(KeyCode.E) )
            {
                // Can Put Flag
                PutFlag( _putFlag );
            }
        }

        private void LateUpdate() 
        {
            _animator.SetBool( "Is Captured",  _isCaptured );
        }

        private void OnTriggerStay2D( Collider2D collision )  
        {
            if( collision.CompareTag("Player") || collision.CompareTag("PutFlag") )
            {
                if( !_isCaptured)
                {
                    // Get Flag
                    _canGet = true;
                    _flag = collision.gameObject;
                }

                if( _isCaptured )
                {
                    // Put Flag
                    _canPut = true;
                    _putFlag = collision.gameObject;
                }
            }
        }

        private void OnTriggerExit2D( Collider2D collision ) 
        {
            // Exit of the Area Flag;
            _canGet = false;
            _canPut = false;    
            _flag = null;
            _putFlag = null;
        }

        #endregion


        #region Get & Put Flag

        /// <summary>
        /// Perfom the player's action to capture the enemy flag
        /// </summary>
        /// <param name="player"> Game Object Player </param>
        private void GetFlag( GameObject player )
        {
            _isCaptured = true;
            _canGet = false;

            this.transform.parent = player.transform;

            _gun = player.GetComponentInChildren<GunController>().gameObject;
            _gun.SetActive( false );
        }


        /// <summary>
        /// Perfom the action of the player placing the enemy flag in the right place
        /// </summary>
        /// <param name="putFlag"> Right place to put the flag </param>
        private void PutFlag( GameObject putFlag )
        {
            _isCaptured = false;
            _canPut = false;

            this.transform.parent = putFlag.transform;

            _gun.SetActive( true );
        }

        #endregion

    }
}
