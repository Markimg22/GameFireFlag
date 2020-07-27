using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletDamage : MonoBehaviour
{
    private int _damageBullet = 25;
    private GunShoot _gunShoot;


    private void Awake() 
    {
        _gunShoot = GetComponentInParent<GunShoot>();
    }

    private void OnTriggerEnter2D( Collider2D collision ) 
    {
        if( collision.CompareTag("Player") )
        {
            // Collision with Player
            collision.SendMessage( "AddDamage", _damageBullet );
            ResetBullet();
        }

        else if( collision.gameObject.layer == 0 )
        {
            // Collision with other things
            ResetBullet();
        }    
    }

    public void ResetBullet()
    {
        this.gameObject.SetActive( false );
        this.transform.parent = _gunShoot.gameObject.transform;
        this.transform.position = _gunShoot.FirePoint.position;
    }
}
