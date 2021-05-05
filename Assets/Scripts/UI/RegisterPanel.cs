using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public InputField Username;

    public void Register() {
        var req = new PlayFab.ClientModels.RegisterPlayFabUserRequest {
            Username = Username.text,
            Email = Email.text,
            Password = Password.text
        };

        PlayFab.PlayFabClientAPI.RegisterPlayFabUser(req, OnRegisterSuccess, OnRegisterFailed);
    }

    void OnRegisterSuccess(PlayFab.ClientModels.RegisterPlayFabUserResult e) {
        GetComponentInParent<Login>().gameObject.SetActive(false);
    }

    void OnRegisterFailed(PlayFab.PlayFabError e) {
        Debug.LogError(e);
        Application.Quit();
    }
}
