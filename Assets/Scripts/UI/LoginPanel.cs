using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    public InputField Password;
    public InputField Username;

    Login parent;

    void Awake() {
        parent = GetComponentInParent<Login>();
    }
    public void LogIn(string ID) {
        var req = new PlayFab.ClientModels.LoginWithPlayFabRequest {
            Username = Username.text,
            Password = Password.text,
            TitleId = ID
        };
        PlayFab.PlayFabClientAPI.LoginWithPlayFab(req, OnLoginSuccess, OnLoginFailed);
    }

    void OnLoginSuccess(PlayFab.ClientModels.LoginResult e) {
        parent.Modal.Show(e.SessionTicket, false, true);
        GetComponentInParent<Login>().gameObject.SetActive(false);
    }

    void OnLoginFailed(PlayFab.PlayFabError e) {
        parent.Modal.Show(e.ErrorMessage, false, true);
    }
}
