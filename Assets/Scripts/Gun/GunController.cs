using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
    public class GunController : MonoBehaviour
    {
        #region Private Fields

        private PlayerController _playerController;
        private float _rotationZ;

        #endregion


        #region Unity

        private void Awake() 
        {
            _playerController = transform.GetComponentInParent<PlayerController>();
        }

        private void Update() 
        {
            // Rotation gun
            _rotationZ = Mathf.Atan2( _playerController.Direction.y, _playerController.Direction.x ) * Mathf.Rad2Deg;

            if( _playerController.Direction.x < 0f )
            {
                _rotationZ += 180f;        
            }
            
            if( (_rotationZ == 90 || _rotationZ == -90) && _playerController.transform.localScale.x == -1f  )
            {
                _rotationZ *= -1f;
            }

            this.transform.rotation = Quaternion.Euler( 0f, 0f, _rotationZ );
        }

        #endregion

    }
}
