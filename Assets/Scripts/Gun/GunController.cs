using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunController : MonoBehaviour
{
    private PlayerController _playerController;
    private float rotationZ;


    private void Awake() 
    {
        _playerController = transform.GetComponentInParent<PlayerController>();
    }

    private void Update() 
    {
        // Movement
        rotationZ = Mathf.Atan2( _playerController.Direction.y, _playerController.Direction.x ) * Mathf.Rad2Deg;

        if( _playerController.Direction.x < 0f )
        {
            rotationZ += 180f;        
        }
        
        if( (rotationZ == 90 || rotationZ == -90) && _playerController.transform.localScale.x == -1f  )
        {
            rotationZ *= -1f;
        }

        this.transform.rotation = Quaternion.Euler( 0f, 0f, rotationZ );
    }

}
