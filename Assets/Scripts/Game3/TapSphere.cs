using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapSphere : MonoBehaviour
{
    private Text Score;
    private void Start()
    {
        Score = GameObject.Find("Score").GetComponent<Text>();
    }
    System.Random rnd = new System.Random();
    public void OnMouseDown()
    {
        if (!GlobalDefines.WaitPlayerForExit && !GlobalDefines.GameTip3)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(rnd.Next(-5, 5), 25, 0), ForceMode.Impulse);
            Score.text = (int.Parse(Score.text) + 1).ToString();
        }
    }
}
