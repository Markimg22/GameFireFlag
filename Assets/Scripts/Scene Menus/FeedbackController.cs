using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Photon.Pun
{
    public class FeedbackController : MonoBehaviour
    {
        #region Private Fields

        private readonly string _connectionStatusMessage = "    Connection Status: ";
        private TextMeshProUGUI _textFeedBack;

        #endregion


        #region Unity

        private void Awake() 
        {
            _textFeedBack = GetComponent<TextMeshProUGUI>();
        }

        private void Update() 
        {
            _textFeedBack.text = _connectionStatusMessage + PhotonNetwork.NetworkClientState;    
        }

        #endregion

    }
}
