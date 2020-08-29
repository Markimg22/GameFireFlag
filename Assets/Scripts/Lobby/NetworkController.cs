using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


namespace Photon.Pun
{
    public class NetworkController : MonoBehaviourPunCallbacks
    { 
        #region PUBLIC FIELDS

        [ Header("Panels") ]
        public GameObject loginPanel;
        public GameObject roomPanel;

        [ Header("Inputs") ]
        public InputField playerNameInput;
        public InputField roomNameInput;

        [ Header("Texts") ]
        public TextMeshProUGUI statusText;

        #endregion


        #region UNITY

        private void Awake() 
        {
            // PhotonNetwork.AutomaticallySyncScene = true;

            string randomPlayerName = "Player" + Random.Range( 1000, 10000 );
            playerNameInput.text = randomPlayerName;
        }

        private void Start() 
        {
            SetActivePanel( loginPanel.name );
        }

        #endregion


        #region UI CALLBACKS

        public void OnButtonLogin()
        {
            if( playerNameInput.text == "" )
            {
                statusText.text = "Player name is empty.";
                return;
            }
            
            PhotonNetwork.NickName = playerNameInput.text;
            PhotonNetwork.ConnectUsingSettings();
        }

        public void OnButtonJoinRandomRoom()
        {
            PhotonNetwork.JoinLobby();
        }

        public void OnButtonCreateRoom()
        {
            if( roomNameInput.text == "" )
            {
                statusText.text = "Room name is empty.";
                return;
            }

            RoomOptions roomOptions = new RoomOptions(){ MaxPlayers = 4 };
            PhotonNetwork.JoinOrCreateRoom( roomNameInput.text, roomOptions, TypedLobby.Default );
        }

        public void SetActivePanel( string activePanel )
        {
            loginPanel.SetActive( activePanel.Equals(loginPanel.name) );
            roomPanel.SetActive( activePanel.Equals(roomPanel.name) );
        }

        #endregion


        #region PUN CALLBACKS

        public override void OnConnected()
        {
            statusText.text = "Connecting...";
        }

        public override void OnConnectedToMaster()
        {
            statusText.text = "Connected to Master.";
            statusText.text = $"Server Region : {PhotonNetwork.CloudRegion} | PING : {PhotonNetwork.GetPing()}";

            SetActivePanel( roomPanel.name );
        }

        public override void OnJoinedLobby()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinRandomFailed( short returnCode, string message )
        {
            PhotonNetwork.CreateRoom( null );
        }

        public override void OnJoinedRoom()
        {
            statusText.text = "Joined room";
            statusText.text = $"Room Name : {PhotonNetwork.CurrentRoom.Name} | Current Players in Room : {PhotonNetwork.CurrentRoom.PlayerCount}";

            SceneManager.LoadScene( "Game" );
        }

        #endregion

    }
}
