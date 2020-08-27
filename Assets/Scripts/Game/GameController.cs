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


        #region Private Fields

        [SerializeField]
        private List<GameObject> _listPrefabsPlayer = new List<GameObject>();

        private GameObject _player;
        private List<GameObject> _listPlayers = new List<GameObject>();

        #endregion


        #region Unity

        private void Start() 
        {   
            Instance = this;

            if( !PhotonNetwork.IsConnected )
            {
                SceneManager.LoadScene( "Menus" );
                return;
            }

            if( PlayerController.LocalPlayerInstance == null )
            {         
                // Instance player       
                _player = PhotonNetwork.Instantiate( this._listPrefabsPlayer[0].name, new Vector3(0f, 0f, 0f) , Quaternion.identity );
            }
        }

        #endregion


        #region Photon Callbacks

        /// <summary>
        /// Called when a Photon Player got connected. We need to then load a bigger scene.
        /// </summary>
        /// <param name="other"> Other </param>
        public override void OnPlayerEnteredRoom( Player other )
        {
            _listPlayers.Add( _player );
        }

        /// <summary>
        /// Called when a Photon Player got disconnected. We need to load a smaller scene.
        /// </summary>
        /// <param name="other"> Other </param>
        public override void OnPlayerLeftRoom( Player other )
        {
            if( PhotonNetwork.IsMasterClient )
            {
                SceneManager.LoadScene( "Menus" );
            }
        }

        #endregion

    }
}


