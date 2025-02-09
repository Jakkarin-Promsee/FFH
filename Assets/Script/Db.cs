using UnityEngine;

[CreateAssetMenu(fileName = "NewScore", menuName = "Game/Score")]
public class Db : ScriptableObject
{
    public int isWin = 0; //-1 lose, 0 unknown, 1 win
    public int score;
    public float time;

    public void AddScore(int points)
    {
        score += points;
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
        time = 0;
    }
}
