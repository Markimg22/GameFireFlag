using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;


namespace Photon.Pun
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        public static GameController Instance = null;

        public GameObject[] playerPrefabs;

        
        #region UNITY

        private void Awake() 
        {
            Instance = this;    
        }

        private void Start() 
        {
            PhotonNetwork.Instantiate( playerPrefabs[1].name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0 );
        }

        #endregion


        #region PUN CALLBACKS

        public override void OnDisconnected( DisconnectCause cause )
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene( "Lobby" );
        }

        #endregion

    }
}


