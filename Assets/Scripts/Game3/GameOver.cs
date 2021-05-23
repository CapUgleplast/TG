using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject panel;
    public void Update()
    {
        if (GlobalDefines.WaitPlayerForExit)
        {
            panel.SetActive(true);
        }
        else
            panel.SetActive(false);
    }
    [SerializeField] private Text Score;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fire")
        {
            GlobalDefines.WaitPlayerForExit = true;
            GlobalDefines.returnsThirdGame = int.Parse(Score.text);
            StartCoroutine(Connect.loadOut(this,3));
        }
    }
}
