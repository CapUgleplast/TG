using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;

public class LoginPanel : MonoBehaviour {
    public InputField Password;
    public InputField Username;

    Login parent;

    void Awake() {
        parent = GetComponentInParent<Login>();
    }
    public void LogIn(string ID, bool withGoogle = false) {
        var req = new LoginWithPlayFabRequest {
            Username = Username.text,
            Password = Password.text,
            TitleId = ID
        };

        PlayFabClientAPI.LoginWithPlayFab(req, OnLoginSuccess, OnLoginFailed);
    }

    void OnLoginSuccess(LoginResult e) {
        parent.Modal.Show("Login success", false, false);
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        GetPlayerData(e.PlayFabId);
    }

    void OnLoginFailed(PlayFabError e) {
        parent.Modal.Show(e.ErrorMessage, false, true);
    }

    void GetPlayerData(string id) {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
            PlayFabId = id,
            Keys = null,
        }, OnGetUserDataSuccess, OnGetUserDataFailed);
    }

    void OnGetUserDataSuccess(GetUserDataResult e) {
        if(e.Data == null) {
            UserData.Instance.SetUserData(0, 0);
        }
        else if (!e.Data.ContainsKey("Money") || !e.Data.ContainsKey("Crystal")) {
            if(!e.Data.ContainsKey("Money")) {
                UserData.Instance.SetMoney(0);
            }
            if(!e.Data.ContainsKey("Crystal")) {
                UserData.Instance.SetCrystal(0);
            }
        }
        else {
            UserData.Instance.SetUserData(int.Parse(e.Data["Money"].Value), int.Parse(e.Data["Crystal"].Value));
        }
    }

    void OnGetUserDataFailed(PlayFabError e) {
        UserData.Instance.SetUserData(0, 0);
    }
}
