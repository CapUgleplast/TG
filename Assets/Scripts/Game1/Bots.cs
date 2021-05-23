using UnityEngine;

public class Bots : MonoBehaviour
{
    public static int[] GenerateResult(int Score, int Game)
    {
        if (Game == 1)
        {
            int[] resultBot = new int[5];
            resultBot[0] = Random.Range(0, Score + 6);
            resultBot[1] = Random.Range(0, Score + 6);
            resultBot[2] = Random.Range(0, Score + 6);
            resultBot[3] = Random.Range(0, Score + 6);
            resultBot[4] = Score;
            return resultBot;
        }
        else if (Game == 2)
        {
            int[] resultBot = new int[5];
            resultBot[0] = Random.Range(0, Score + 15);
            resultBot[1] = Random.Range(0, Score + 15);
            resultBot[2] = Random.Range(0, Score + 15);
            resultBot[3] = Random.Range(0, Score + 15);
            resultBot[4] = Score;
            return resultBot;
        }
        else if (Game == 3)
        {
            int[] resultBot = new int[5];
            resultBot[0] = Random.Range(0, Score + 10);
            resultBot[1] = Random.Range(0, Score + 10);
            resultBot[2] = Random.Range(0, Score + 10);
            resultBot[3] = Random.Range(0, Score + 10);
            resultBot[4] = Score;
            return resultBot;
        }
        else if (Game == 4)
        {
            int[] resultBot = new int[5];
            resultBot[0] = Random.Range(0, Score + 8);
            resultBot[1] = Random.Range(0, Score + 8);
            resultBot[2] = Random.Range(0, Score + 8);
            resultBot[3] = Random.Range(0, Score + 8);
            resultBot[4] = Score;
            return resultBot;
        }
        else return null;
    }
}
