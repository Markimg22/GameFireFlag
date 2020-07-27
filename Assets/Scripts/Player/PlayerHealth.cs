using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    private int _life = 100;
    private RectTransform _lifeBar;


    private void Awake() 
    {
        _lifeBar = GameObject.Find( "Life Bar" ).GetComponent<RectTransform>();
    }

    private void Update() 
    {
        if( _life <= 0 )
        {
            this.gameObject.SetActive( false );
        }
    }

    private void OnEnable() 
    {   
        // Reset Life
        _life = 100;
        _lifeBar.sizeDelta = new Vector2( 260f, _lifeBar.sizeDelta.y );
    }

    private void AddDamage( int damage )
    {
        this.gameObject.GetComponent<Animator>().SetTrigger( "Damage" );
        _lifeBar.sizeDelta = new Vector2( _lifeBar.sizeDelta.x - 65f, _lifeBar.sizeDelta.y );
        _life -= damage;
    }

}
