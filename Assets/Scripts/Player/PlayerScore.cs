using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Photon.Pun
{
    public class PlayerScore : MonoBehaviour
    {   
        private TextMeshProUGUI _textScore;
        private int _score;
        

        private void Awake() 
        {
            _textScore = GameObject.Find( "Menu HUD/Score/Text Score" ).GetComponent<TextMeshProUGUI>();
        }

        public void ToScore()
        {
            _score += 100;
            _textScore.text = _score.ToString();
        }
    }
}
