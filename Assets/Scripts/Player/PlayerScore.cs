using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace Photon.Pun
{
    public class PlayerScore : MonoBehaviour
    {   
        #region Private Fields

        private TextMeshProUGUI _textScore;
        private int _score;
        
        #endregion


        #region Unity

        private void Awake() 
        {
            _textScore = GameObject.Find( "Menu HUD/Score/Text Score" ).GetComponent<TextMeshProUGUI>();
        }

        #endregion

        
        #region Public Methods

        /// <summary>
        /// Score Player
        /// </summary>
        public void ToScore()
        {
            _score += 100;
            _textScore.text = _score.ToString();
        }

        #endregion
    }
}
