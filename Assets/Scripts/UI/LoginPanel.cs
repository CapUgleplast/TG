using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public InputField Username;

    public void LogIn(string ID) {
        var req = new PlayFab.ClientModels.LoginWithPlayFabRequest {
            Username = Username.text,
            Password = Password.text,
            TitleId = ID
        };
        PlayFab.PlayFabClientAPI.LoginWithPlayFab(req, OnLoginSuccess, OnLoginFailed);
    }

    void OnLoginSuccess(PlayFab.ClientModels.LoginResult e) {
        GetComponentInParent<Login>().gameObject.SetActive(false);
    }

    void OnLoginFailed(PlayFab.PlayFabError e) {
        Debug.LogError(e);
        Application.Quit();
    }
}
