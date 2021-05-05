using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : MonoBehaviour
{
    public InputField Email;
    public InputField Password;
    public InputField Username;

    Login parent;

    void Awake() {
        parent = GetComponentInParent<Login>();
    }

    public void Register() {
        var req = new PlayFab.ClientModels.RegisterPlayFabUserRequest {
            Username = Username.text,
            Email = Email.text,
            Password = Password.text
        };

        PlayFab.PlayFabClientAPI.RegisterPlayFabUser(req, OnRegisterSuccess, OnRegisterFailed);
    }

    void OnRegisterSuccess(PlayFab.ClientModels.RegisterPlayFabUserResult e) {
        parent.Modal.Show(e.SessionTicket, false, true);
        GetComponentInParent<Login>().gameObject.SetActive(false);
    }

    void OnRegisterFailed(PlayFab.PlayFabError e) {
        parent.Modal.Show(e.ErrorMessage, false, true);
        Application.Quit();
    }
}
