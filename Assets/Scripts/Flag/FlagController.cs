using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagController : MonoBehaviour
{
    private Animator _animator;
    private bool _isCaptured;
    private GameObject _gun;

    private bool _canGet;
    private bool _canPut;

    private GameObject _flag;
    private GameObject _putFlag;


    private void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        // Can Get Flag
        if( _canGet && Input.GetKeyDown(KeyCode.E)){
            GetFlag( _flag );
        }

        // Can Put Flag
        if( _canPut && Input.GetKeyDown(KeyCode.E) ){
            PutFlag( _putFlag );
        }
    }

    private void LateUpdate() 
    {
        _animator.SetBool( "Is Captured",  _isCaptured );
    }

    private void OnTriggerStay2D( Collider2D collision )  
    {
        if( collision.CompareTag("Player") || collision.CompareTag("PutFlag") ){

            // Get Flag
            if( !_isCaptured){
                _canGet = true;
                _flag = collision.gameObject;
            }

            // Put Flag
            if( _isCaptured ){
                _canPut = true;
                _putFlag = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D( Collider2D collision ) 
    {
        // Exit of the Area Flag;
        _canGet = false;
        _canPut = false;    
        _flag = null;
        _putFlag = null;
    }

    private void GetFlag( GameObject player )
    {
        _isCaptured = true;
        _canGet = false;

        this.transform.parent = player.transform;

        _gun = player.GetComponentInChildren<GunController>().gameObject;
        _gun.SetActive( false );
    }

    private void PutFlag( GameObject putFlag )
    {
        _isCaptured = false;
        _canPut = false;

        this.transform.parent = putFlag.transform;

        _gun.SetActive( true );
    }

}
