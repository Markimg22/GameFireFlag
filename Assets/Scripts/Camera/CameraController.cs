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
            _player = GameObject.FindGameObjectWithTag( "Player" );
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        private void Start() 
        {   
            if( !_player.GetComponent<PlayerController>().photonView.IsMine )
            {
                return;
            }

            _virtualCamera.Follow = _player.transform;
        }

        #endregion
        
    }
}

