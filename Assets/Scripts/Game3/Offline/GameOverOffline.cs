using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverOffline : MonoBehaviour
{
    private int[] bots;
    private string[] Listbots = { "Adam", "Sanya", "Antony", "E.B. Lan", "YOU" };
    public void Start()
    {
        GlobalDefines.IsOffline = true;
    }
    [SerializeField] private Text Score;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fire")
        {
            bots = new int[4];
            bots = Bots.GenerateResult(int.Parse(Score.text), 3);
            int[] all = new int[5];
            all[0] = bots[0];
            all[1] = bots[1];
            all[2] = bots[2];
            all[3] = bots[3];
            all[4] = int.Parse(Score.text);
            System.Array.Sort(all, Listbots);
            if (Listbots[4] == "YOU")
                GlobalDefines.OfflineWin = true;
            GlobalDefines.ListOffline = Listbots;
            GlobalDefines.ScoreOffline = all;
            UnityEngine.Debug.LogError(Listbots + " " + all);
            SceneManager.LoadScene("WinOffline");
        }
    }
}
