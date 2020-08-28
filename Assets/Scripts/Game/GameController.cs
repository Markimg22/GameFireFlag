using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using Hashtable = ExitGames.Client.Photon.Hashtable;


namespace Photon.Pun
{
    public class GameController : MonoBehaviourPunCallbacks
    {
        public static GameController Instance = null;

        public TextMeshProUGUI infoText;
        public GameObject[] playerPrefabs;


        #region UNITY

        private void Awake() 
        {
            Instance = this;    
        }

        #endregion

    }
}


