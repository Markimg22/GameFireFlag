using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class CameraController : MonoBehaviour
    {
        #region PRIVATE FIELDS

        private GameObject _player;
        private CinemachineVirtualCamera _virtualCamera;

        #endregion


        #region UNITY

        private void Awake() 
        {
            _player = transform.parent.gameObject;
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _virtualCamera.Follow = _player.transform;
        }

        #endregion
        
    }
}

