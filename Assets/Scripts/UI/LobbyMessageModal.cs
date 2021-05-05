using UnityEngine;
using UnityEngine.UI;

public class LobbyMessageModal : MonoBehaviour {

    public Text MessageText;
    public GameObject CloseButtonContainer;
    public GameObject SpinnerContainer;
    public Transform Spinner;
    public float SpinnerSpeed = 360f;

    public void Show(string message, bool showSpinner, bool showCloseButton) {
        MessageText.text = message;
        SpinnerContainer.SetActive(showSpinner);
        CloseButtonContainer.SetActive(showCloseButton);

        if(transform.GetSiblingIndex() + 1 != transform.parent.childCount)
            transform.SetAsLastSibling();

        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }

    void Update() {
        if(SpinnerContainer.activeSelf)
            Spinner.Rotate(0f, 0f, Time.deltaTime * SpinnerSpeed, Space.Self);
    }
}
