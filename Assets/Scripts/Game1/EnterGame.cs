using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    public int GameID;
    public LobbyMessageModal Modal;

    // Update is called once per frame
    void OnMouseUp() {
        Modal.Show("Loading", true, false);
        StartCoroutine(DoLoadGame());
    }

    IEnumerator DoLoadGame() {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        SceneManager.LoadSceneAsync(GameID);
    }
}
