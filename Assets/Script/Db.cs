using UnityEngine;

[CreateAssetMenu(fileName = "NewScore", menuName = "Game/Score")]
public class Db : ScriptableObject
{
    public int isWin = 0; //-1 lose, 0 unknown, 1 win
    public int score;
    public int star;
    public float time;

    public void AddScore(int points)
    {
        score += points;

        if (points < 0)
        {
            while (star >= 1)
            {
                star--;
                score += 10;
            }
        }

        while (score >= 10)
        {
            star++;
            score -= 10;
        }


    }

    public void AddTime(float t)
    {
        time += t;
    }

    public void SetWin(int s)
    {
        isWin = s;
    }

    public void Reset()
    {
        isWin = 0;
        score = 0;
        star = 0;
        time = 0;
    }
}
