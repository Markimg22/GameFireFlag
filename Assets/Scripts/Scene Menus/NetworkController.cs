using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;


namespace Photon.Pun
{
    #pragma warning disable 649

    public class NetworkController : MonoBehaviourPunCallbacks
    {
        #region Private Fields

        [SerializeField] private GameObject _menuStart;
        [SerializeField] private byte _maxPlayersPerRoom = 4;

        private bool _isConnecting;

        #endregion


        #region Unity

        private void Awake() 
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Start the connection process.
        /// </summary>
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

        #endregion


        #region PhotonNetwork PullCallBacks

        public override void OnConnectedToMaster()
        {
            if( _isConnecting )
            {
                PhotonNetwork.JoinRandomRoom();
            }
        }

        public override void OnJoinRandomFailed( short returnCode, string message )
        {
            // Create Room
            PhotonNetwork.CreateRoom( null, new RoomOptions{MaxPlayers = this._maxPlayersPerRoom} );
        }

        public override void OnDisconnected( DisconnectCause cause )
        {
            Debug.Log( "Disconnected by: "+cause );
            _isConnecting = false;
        }

        public override void OnJoinedRoom()
        {
            if( PhotonNetwork.CurrentRoom.PlayerCount == 1 )
            {
                PhotonNetwork.LoadLevel( "Main" );
            }
        }

        #endregion

    }
}
