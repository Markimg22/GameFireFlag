using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Photon.Pun
{
    [RequireComponent( typeof(InputField) )]
    public class PlayerNameInputField : MonoBehaviour
    {
        private const string _playerNamePrefKey = "PlayerName";


        private void Start() 
        {
            string defaultName = string.Empty;
            InputField _inputField = this.GetComponent<InputField>();

            if( _inputField != null )
            {
                if( PlayerPrefs.HasKey(_playerNamePrefKey) )
                {
                    defaultName = PlayerPrefs.GetString( _playerNamePrefKey );
                    _inputField.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
        }
        
        public void SetPlayerName( string value )
        {
            if( string.IsNullOrEmpty(value) )
            {
                Debug.LogError( "Player Name is null or empty" );
                return;
            }

            PhotonNetwork.NickName = value;

            PlayerPrefs.SetString( _playerNamePrefKey, value );
        }
    }
}