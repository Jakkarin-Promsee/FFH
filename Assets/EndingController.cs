using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    public Db db;
    public GameObject[] winingTxt;
    public GameObject[] losingTxt;

    public TextMeshPro timeTMP;
    public TextMeshPro scoreTMP;

    void Start()
    {
        if (db.isWin == -1)
        {
            for (int i = 0; i < losingTxt.Length; i++)
                losingTxt[i].SetActive(true);
            for (int i = 0; i < winingTxt.Length; i++)
                winingTxt[i].SetActive(false);
        }
        else
        {
            for (int i = 0; i < losingTxt.Length; i++)
                losingTxt[i].SetActive(false);
            for (int i = 0; i < winingTxt.Length; i++)
                winingTxt[i].SetActive(true);
        }

        string mm, ss;

        if (Mathf.FloorToInt(db.time / 60) < 10)
            mm = "0" + Mathf.FloorToInt(db.time / 60);
        else
            mm = "" + Mathf.FloorToInt(db.time / 60);

        if (Mathf.FloorToInt(db.time % 60) < 10)
            ss = "0" + Mathf.FloorToInt(db.time % 60);
        else
            ss = "" + Mathf.FloorToInt(db.time % 60);

        timeTMP.text = "Time Play: " + mm + ":" + ss;
        int score = db.star * 10 + db.score;
        scoreTMP.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
