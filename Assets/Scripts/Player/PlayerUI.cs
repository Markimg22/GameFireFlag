using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


namespace Photon.Pun
{
    public class PlayerUI : MonoBehaviour
    {
        #region PUBLIC FIELDS

        [ Header( "CANVAS" ) ]
        public Canvas canvas;

        [ Header("UI") ]
        public TextMeshProUGUI playerNameText;
        public GameObject menuPause;

        #endregion


        #region PRIVATE FIELDS

        private PlayerController _playerController;
        private PlayerShooting _playerShoot;

        private Camera _camera;

        #endregion


        #region UNITY

        private void Awake() 
        {
            _playerController = GetComponent<PlayerController>();
            _playerShoot = GetComponentInChildren<PlayerShooting>();    
            _camera = GameObject.FindGameObjectWithTag( "MainCamera" ).GetComponent<Camera>();
        }

        private void Start() 
        {
            if( _playerController.photonView.IsMine )
            {
                // Set nick name
                if( playerNameText != null )    
                {
                    playerNameText.text = _playerController.photonView.Owner.NickName;
                }

                // Set Camera in Canvas
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = _camera;
            }
        }

        #endregion


        #region BUTTONS METHODS

        public void ButtonOpenOptionsGame()
        {
            menuPause.SetActive( true );
            _playerController.enabled = false;
            _playerShoot.enabled = false;
        }

        public void ButtonCloseOptionsGame()
        {
            menuPause.SetActive( false );
            _playerController.enabled = true;
            _playerShoot.enabled = true;
        }

        public void ButtonExitRoom()
        {
            PhotonNetwork.Disconnect();
        }

        #endregion
    }
}
