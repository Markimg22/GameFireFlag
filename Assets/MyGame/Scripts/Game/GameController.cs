using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;


public class GameController : MonoBehaviourPunCallbacks {   

  [Header("Prefabs Player")]
  public GameObject[] listPrefabsPlayer;
  

  private void Start() {
    // Spawn Player
    PhotonNetwork.Instantiate(listPrefabsPlayer[PhotonNetwork.CurrentRoom.PlayerCount - 1].name, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);    
  }

  public override void OnDisconnected(DisconnectCause cause) {
      UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
  }
}
