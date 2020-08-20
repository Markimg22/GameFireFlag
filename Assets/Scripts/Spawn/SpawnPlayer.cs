using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPlayer : MonoBehaviour
{
    private GameObject _player;
    private float _delayRespawn = 3f;


    private void Awake() 
    {
        _player = GameObject.FindGameObjectWithTag( "Player" );
    }

     private void Update() 
     {
        if( !_player.activeSelf )
        {
            StartCoroutine( "RespawnPlayer" );
        }    
     }

     private IEnumerator RespawnPlayer()
     {
         yield return new WaitForSeconds( _delayRespawn );
         
         _player.transform.position = this.transform.position;
         _player.SetActive( true );
     }

}
