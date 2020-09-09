using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Realtime;


namespace Photon.Pun
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        #region PUBLIC FIELDS

        public static GameController Instance = null;
        
        [ Header("Prefabs Player") ]
        public GameObject[] listPrefabsPlayer;

        #endregion

        
        #region UNITY

        private void Awake() 
        {
            Instance = this;    
        }

        private void Start() 
        {
            // Spawn Player
            PhotonNetwork.Instantiate( listPrefabsPlayer[PhotonNetwork.CurrentRoom.PlayerCount - 1].name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0 );    
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


