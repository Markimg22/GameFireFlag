using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Photon.Pun
{
    public class FeedbackController : MonoBehaviour
    {
        private readonly string _connectionStatusMessage = "    Connection Status: ";
        private TextMeshProUGUI _textFeedBack;


        private void Awake() 
        {
            _textFeedBack = GetComponent<TextMeshProUGUI>();
        }

        private void Update() 
        {
            _textFeedBack.text = _connectionStatusMessage + PhotonNetwork.NetworkClientState;    
        }

    }
}
