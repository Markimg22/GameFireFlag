using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Photon.Pun
{
    public class BulletDamage : MonoBehaviour
    {
        #region PRIVATE FIELDS

        private int _damageBullet = 25;

        #endregion


        #region UNITY COLLISION

        private void OnTriggerEnter2D( Collider2D collision ) 
        {
            if( collision.CompareTag("Player") && collision.GetComponent<PlayerController>().photonView.IsMine )
            {
                // Collision with Player
                collision.GetComponent<PlayerHealth>().TakeDamage( _damageBullet );
                Destroy( this.gameObject );
            }    
        }

        #endregion

    }
}
