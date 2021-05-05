using JamSuite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    const string ID = "29291";

    public RegisterPanel RegisterUI;
    public LoginPanel LoginUI;
    public LobbyMessageModal Modal;

    void Start() {
        RegisterUI.gameObject.SetActive(false);
        LoginUI.gameObject.SetActive(true);
    }

    public void Register() {
        if (!RegisterUI.gameObject.activeSelf) {
            Toggle();
            return;
        }

        RegisterUI.Register();
    }

    public void LogIn(bool withGoogle) {
        if (!LoginUI.gameObject.activeSelf) {
            Toggle();
            return;
        }

        LoginUI.LogIn(ID, withGoogle);
    }

    void Toggle() {
        RegisterUI.gameObject.SetActive(!RegisterUI.gameObject.activeSelf);
        LoginUI.gameObject.SetActive(!LoginUI.gameObject.activeSelf);
    }
}
