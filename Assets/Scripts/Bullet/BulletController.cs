using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
    public class BulletController : MonoBehaviour
    {
        private float speed = 3f;
        private Vector2 _direction;

        private Rigidbody2D _rigidbody;
        private GunController _gun;
        private Transform _crossHair;


        private void Awake() 
        {
            _rigidbody = GetComponent<Rigidbody2D>();  
            _gun = GetComponentInParent<GunController>();
            _crossHair = this.transform.parent.Find( "Fire Point/Cross Hair" );   
        }

        private void OnEnable() 
        {
            _direction = _crossHair.position - this.transform.position;
        }

        private void FixedUpdate() 
        {
            _rigidbody.velocity = _direction.normalized * speed;
        }

    }
}
