using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private GunShoot _gunShoot;
        [SerializeField] private TextMeshProUGUI _playerNameText;

        [SerializeField] private GameObject _menuPause;


        private void Start() 
        {
            if( _playerNameText != null )    
            {
                _playerNameText.text = _playerController.photonView.Owner.NickName;
            }
        }

        public void OpenOptionsGame()
        {
            _menuPause.SetActive( true );
            _playerController.enabled = false;
            _gunShoot.enabled = false;
        }

        public void CloseOptionsGame()
        {
            _menuPause.SetActive( false );
            _playerController.enabled = true;
            _gunShoot.enabled = true;
        }
        
    }
}
