using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class MenuManager : MonoBehaviour {

  [Header("Menus")]
  public GameObject menuLogin;
  public GameObject menuRooms;
  public GameObject menuCreateRoom;


  private void Start() {
    SetActiveMenus(menuLogin.name);
  }

  public void SetActiveMenus(string nameActiveMenu) {
    menuLogin.SetActive(nameActiveMenu.Equals(menuLogin.name));
    menuRooms.SetActive(nameActiveMenu.Equals(menuRooms.name));
    menuCreateRoom.SetActive(nameActiveMenu.Equals(menuCreateRoom.name));
  }
}
