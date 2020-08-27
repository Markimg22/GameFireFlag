using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class PlayerUI : MonoBehaviour
    {
        #region Serialize Fields

        [SerializeField] private PlayerController _playerController;
        [SerializeField] private GunShoot _gunShoot;
        [SerializeField] private TextMeshProUGUI _playerNameText;

        [SerializeField] private GameObject _menuPause;

        #endregion


        #region Unity

        private void Start() 
        {
            if( _playerNameText != null )    
            {
                _playerNameText.text = _playerController.photonView.Owner.NickName;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Called to open option menu at game time.
        /// </summary>
        public void OpenOptionsGame()
        {
            _menuPause.SetActive( true );
            _playerController.enabled = false;
            _gunShoot.enabled = false;
        }

        /// <summary>
        /// Called to close the options menu at the time of the game.
        /// </summary>
        public void CloseOptionsGame()
        {
            _menuPause.SetActive( false );
            _playerController.enabled = true;
            _gunShoot.enabled = true;
        }

        /// <summary>
        /// Added method on the button to leave the room.
        /// </summary>
        public void ButtonExitRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion
    }
}
