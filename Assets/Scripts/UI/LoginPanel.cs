using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using PlayFab;
using PlayFab.ClientModels;

public class LoginPanel : MonoBehaviour
{
    public InputField Password;
    public InputField Username;

    Login parent;

    void Awake() {
        parent = GetComponentInParent<Login>();
    }
    public void LogIn(string ID, bool withGoogle = false) {
        if (withGoogle) {
            Social.localUser.Authenticate((bool success) => {

                if(success) {
                    var serverAuthCode = PlayGamesPlatform.Instance.GetServerAuthCode();
                    Debug.Log("Server Auth Code: " + serverAuthCode);

                    PlayFabClientAPI.LoginWithGoogleAccount(new LoginWithGoogleAccountRequest() {
                        TitleId = PlayFabSettings.TitleId,
                        ServerAuthCode = serverAuthCode,
                        CreateAccount = true
                    }, (result) =>
                    {
                        GetComponentInParent<Login>().gameObject.SetActive(false);
                    }, OnLoginFailed);
                }
                else {
                    parent.Modal.Show("Google Failed to Authorize your login", false, true);
                }

            });
        }
        else {
            var req = new PlayFab.ClientModels.LoginWithPlayFabRequest {
                Username = Username.text,
                Password = Password.text,
                TitleId = ID
            };

            PlayFab.PlayFabClientAPI.LoginWithPlayFab(req, OnLoginSuccess, OnLoginFailed);
        }
    }

    void OnLoginSuccess(PlayFab.ClientModels.LoginResult e) {
        GetComponentInParent<Login>().gameObject.SetActive(false);
    }

    void OnLoginFailed(PlayFab.PlayFabError e) {
        parent.Modal.Show(e.ErrorMessage, false, true);
    }
}
