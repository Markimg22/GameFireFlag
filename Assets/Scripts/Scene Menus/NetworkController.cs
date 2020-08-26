using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class NetworkController : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject _menuStart;
        [SerializeField] private byte _maxPlayersPerRoom = 4;

        private bool _isConnecting;


        private void Awake() 
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        public void Connect()
        {
            _isConnecting = true;

            if( PhotonNetwork.IsConnected )
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public override void OnConnectedToMaster()
        {
            if( _isConnecting )
            {
                Debug.Log( "Client is connected and could join a Room" );
                PhotonNetwork.JoinRandomRoom();
            }
        }

        public override void OnJoinRandomFailed( short returnCode, string message )
        {
            Debug.Log( "No rando room Available, so we create one" );
            PhotonNetwork.CreateRoom( null, new RoomOptions{MaxPlayers = this._maxPlayersPerRoom} );
        }

        public override void OnDisconnected( DisconnectCause cause )
        {
            Debug.Log( "Disconnected by: "+cause );
            _isConnecting = false;
        }

        public override void OnJoinedRoom()
        {
            Debug.Log( "Client is in a Room" );

            if( PhotonNetwork.CurrentRoom.PlayerCount == 1 )
            {
                Debug.Log( "We loaded the *Room for 1*" );
                PhotonNetwork.LoadLevel( "Main" );
            }
        }

    }
}
