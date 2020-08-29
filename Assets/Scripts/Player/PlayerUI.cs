using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class PlayerUI : MonoBehaviour
    {
        #region PRIVATE FIELDS

        [ Header("UI") ]
        [SerializeField] private TextMeshProUGUI _playerNameText;
        [SerializeField] private GameObject _menuPause;

        private PlayerController _playerController;
        private GunShoot _gunShoot;

        #endregion


        #region UNITY

        private void Awake() 
        {
            _playerController = GetComponent<PlayerController>();
            _gunShoot = GetComponentInChildren<GunShoot>();    
        }

        private void Start() 
        {
            if( _playerNameText != null )    
            {
                _playerNameText.text = _playerController.photonView.Owner.NickName;
            }
        }

        #endregion


        #region BUTTONS METHODS

        public void ButtonOpenOptionsGame()
        {
            _menuPause.SetActive( true );
            _playerController.enabled = false;
            _gunShoot.enabled = false;
        }

        public void ButtonCloseOptionsGame()
        {
            _menuPause.SetActive( false );
            _playerController.enabled = true;
            _gunShoot.enabled = true;
        }

        public void ButtonExitRoom()
        {
            PhotonNetwork.Disconnect();
        }

        #endregion
    }
}
