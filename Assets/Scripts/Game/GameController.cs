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

        #endregion

        
        #region UNITY

        private void Awake() 
        {
            Instance = this;    
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


