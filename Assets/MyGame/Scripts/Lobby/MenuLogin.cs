using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;


public class MenuLogin : MonoBehaviour
{
    [ Header("Input") ]
    public InputField inputNickName;

    [ Header("Text Log") ]
    public TextMeshProUGUI textLog;

    
    private void Start() 
    {
        inputNickName.text = PlayerPrefs.GetString( "PLAYER_NAME", "" );
    }

    public void ButtonLogin()
    {
        if( inputNickName.text == "" )
        {
            textLog.text = "NickName is empty";
            return;
        }

        // Set Nick Name
        PhotonNetwork.NickName = inputNickName.text;
        PlayerPrefs.SetString( "PLAYER_NAME", inputNickName.text );

        // Connect to Server
        PhotonNetwork.ConnectUsingSettings();
    }
}
