using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;


namespace Photon.Pun
{
    public class PlayerUI : MonoBehaviour
    {
        #region PUBLIC FIELDS

        [ Header("UI") ]
        public TextMeshProUGUI playerNameText;
        public GameObject menuPause;

        #endregion


        #region PRIVATE FIELDS

        private PlayerController _playerController;
        private PlayerShooting _playerShoot;

        #endregion


        #region UNITY

        private void Awake() 
        {
            _playerController = GetComponent<PlayerController>();
            _playerShoot = GetComponentInChildren<PlayerShooting>();    
        }

        private void Start() 
        {
            if( playerNameText != null )    
            {
                playerNameText.text = _playerController.photonView.Owner.NickName;
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
