using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("UI")]
    public List<GameObject> GreenPlates;
    public GameObject Cursor;
    public Text Score;
    public Text Timer;
    public Text Result;
    public GameObject WinPnel;
    [Header("Controls")]
    public float MaxTime;
    public Animator Pig;
    public Animator ScorePlus;
    public Animator ScoreMinus;

    int counter = 0;
    float timer;
    private string[] Listbots = { "mevlme44", "Sanya", "Poma", "E.B. Lan", "CapUgleplast" };
    GameObject currentActive;
    bool update = true;
    // Start is called before the first frame update
    void Start() {
        timer = MaxTime;
        Timer.text = MaxTime.ToString();
        ChangeGreenTile();
    }

    // Update is called once per frame
    void Update() {
        if (timer > 0) {
            if (Input.GetMouseButtonDown(0)) {
                if (Cursor.transform.position.x <= currentActive.transform.position.x + 15f && Cursor.transform.position.x >= currentActive.transform.position.x - 15f) {
                    counter++;
                    Pig.SetTrigger("Success");
                    timer += 0.5f;
                    ChangeGreenTile();
                }
                else {
                    timer -= 0.5f;
                    Pig.SetTrigger("Fail");
                    ChangeGreenTile();
                }
            }

            timer -= Time.deltaTime;
            Timer.text = Mathf.RoundToInt(timer).ToString();
            Score.text = counter.ToString();
        }
        else if (update){
            update = false;
            var res = Bots.GenerateResult(counter, 1);
            StartCoroutine(DoShowWinners(res));
            Pig.SetTrigger("Fail");
        }
    }

    void ChangeGreenTile() {
        currentActive = GreenPlates[Random.Range(0, GreenPlates.Count)];

        foreach (var tile in GreenPlates) {
            tile.SetActive(tile == currentActive);
        }
    }

    IEnumerator DoShowWinners(int[] res) {
        System.Array.Sort(res, Listbots);
        WinPnel.SetActive(true);
        for (int i = 4; i >= 0; i--) 
            Result.text += Listbots[i] + " " + res[i] + "\n";

        yield return new WaitForSeconds(5f);
        UserData.Instance.SetUserData(UserData.Instance.Money + 50, UserData.Instance.Crystal + 1);
        SceneManager.LoadSceneAsync(1);
    }
}
