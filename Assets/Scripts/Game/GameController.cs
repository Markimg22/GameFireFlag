using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class GameController : MonoBehaviourPunCallbacks
    {
        public static GameController Instance;

        [SerializeField]
        private List<GameObject> _listPrefabsPlayer = new List<GameObject>();

        private GameObject _player;
        private List<GameObject> _listPlayers = new List<GameObject>();

        
        private void Start() 
        {   
            Instance = this;

            if( !PhotonNetwork.IsConnected )
            {
                SceneManager.LoadScene( "Menus" );
                return;
            }

            if( _listPrefabsPlayer == null )
            {
                Debug.LogError( "Please set ir up in GameObject: GameController" );
            }
            else
            {   
                if( PlayerController.LocalPlayerInstance == null )
                {
                    Debug.LogFormat( "We are Instantiating LocalPlayer drom {0}", SceneManagerHelper.ActiveSceneName );
                    
                    _player = PhotonNetwork.Instantiate( this._listPrefabsPlayer[0].name, new Vector3(0f, 0f, 0f) , Quaternion.identity );
                }
                else
                {
                    Debug.LogFormat( "Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName );
                }
            }
        }

        public override void OnPlayerEnteredRoom( Player newPlayer )
        {
            Debug.Log( $"Player {newPlayer.NickName} entered Room" );
            _listPlayers.Add( _player );

            if( PhotonNetwork.IsMasterClient )
            {
                Debug.LogFormat( "OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient );
            }
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene( "Menus" );
        }

    }
}


