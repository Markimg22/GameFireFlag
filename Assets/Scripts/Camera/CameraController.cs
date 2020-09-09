using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;


namespace Photon.Pun
{
    public class CameraController : MonoBehaviour
    {
        #region PRIVATE FIELDS

        private GameObject _player;
        private CinemachineVirtualCamera _virtualCamera;

        #endregion


        #region UNITY

        private void Awake() 
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        private void Start() 
        {   
            // Get Player
            _player = GameObject.FindGameObjectWithTag( "Player" );

            if( _player == null )
            {
                Debug.Log( "Player não encontrado" );
                return;
            }

            // PhotonView is Mine?
            if( !_player.GetComponent<PlayerController>().photonView.IsMine )
            {
                return;
            }

            // Following Player
            _virtualCamera.Follow = _player.transform;
        }

        #endregion
        
    }
}

