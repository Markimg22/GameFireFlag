using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Photon.Pun
{
    public class PlayerScore : MonoBehaviour
    {   
        #region PRIVATE FIELDS

        private TextMeshProUGUI _textScore;
        private int _score;
        
        #endregion


        #region UNITY

        private void Awake() 
        {
            _textScore = GameObject.Find( "Menu HUD/Score/Text Score" ).GetComponent<TextMeshProUGUI>();
        }

        #endregion

        
        #region PUBLIC METHODS

        public void ToScore()
        {
            _score += 100;
            _textScore.text = _score.ToString();
        }

        #endregion
    }
}
