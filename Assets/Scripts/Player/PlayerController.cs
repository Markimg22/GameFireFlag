using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    // Move
    private float speed = 0.8f;
    private Vector2 _direction;
    public Vector2 Direction 
    { 
        get{ return _direction; } 
        set{ this._direction = value; }  
    }

    // Reference
    private Animator _animator;
    private Rigidbody2D _rigidbody;


    private void Awake() 
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        // Move
        _direction = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );

        // Flip
        if( _direction.x > 0f )
        {
            // right
            this.transform.localScale = new Vector2( 1f, 1f );
        }
        else if( _direction.x < 0f )
        {
            // left
            this.transform.localScale = new Vector2( -1f, 1f );
        }
    }

    private void FixedUpdate() 
    {
        // Move
        _rigidbody.velocity = _direction * speed;      
    }

    private void LateUpdate() 
    {
        _animator.SetFloat( "Speed", _direction.magnitude );
    }

}
