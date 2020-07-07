using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    private int _life = 100;
    public RectTransform lifeBar;


    private void Update() 
    {
        if( _life <= 0 ){
            this.gameObject.SetActive( false );
        }
    }

    private void OnEnable() 
    {   
        // Reset Life
        _life = 100;
        lifeBar.sizeDelta = new Vector2( 260f, lifeBar.sizeDelta.y );
    }

    private void AddDamage( int damage )
    {
        this.gameObject.GetComponent<Animator>().SetTrigger( "Damage" );
        lifeBar.sizeDelta = new Vector2( lifeBar.sizeDelta.x - 65f, lifeBar.sizeDelta.y );
        _life -= damage;
    }

}
