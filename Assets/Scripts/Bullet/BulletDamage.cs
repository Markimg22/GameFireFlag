using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Photon.Pun
{
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

                // Death Player Enemy
                // if( !collision.gameObject.activeSelf )
                // {

                // }
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
            this.transform.position = _gunShoot.firePoint.position;
        }
    }
}
