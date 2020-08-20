using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class NetworkController : MonoBehaviourPunCallbacks
{
    [ Header ("Menus") ]
    public GameObject menuLogin;
    public GameObject menuRoom;

    [ Header ("Inputs") ]
    public TMP_InputField inputNameRoom;
    public TMP_InputField inputNickName;

    [ Header ("Prefabs") ]
    public GameObject prefabPlayer;


    private void Start() 
    {
        ActiveMenu( true, false );
    }

    public void ButtonLogin()
    {
        PhotonNetwork.NickName = inputNickName.text;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void ButtonCreateRoom()
    {
        RoomOptions _roomOptions = new RoomOptions(){ MaxPlayers = 10 };
        PhotonNetwork.JoinOrCreateRoom( inputNameRoom.text, _roomOptions, TypedLobby.Default );
    }

    private void ActiveMenu( bool activeMenuLogin, bool activeMenuRoom )
    {
        menuLogin.SetActive( activeMenuLogin );
        menuRoom.SetActive( activeMenuRoom );
    }



    /** Pull Call Backs **/

    public override void OnConnected()
    {
        print( $"{PhotonNetwork.NickName} Connected to the Server" );
    }

    public override void OnConnectedToMaster()
    {
        print( $"{PhotonNetwork.NickName} Connected to the Master" );
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        print( $"{PhotonNetwork.NickName} Joined in the Lobby" );
        ActiveMenu( false, true );
    }

    public override void OnJoinedRoom()
    {
        print( $"{PhotonNetwork.NickName} Joined in the Room" );

        ActiveMenu( false, false );
        SceneManager.LoadScene( "Main" );
    }

    public override void OnDisconnected( DisconnectCause cause )
    {
        print( $"{PhotonNetwork.NickName} Disconnected becaus {cause}" );
    }
}
