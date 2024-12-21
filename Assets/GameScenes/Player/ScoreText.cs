using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{

    public bool truefalse;

    int playerScore = 0;
    int otherScore = 0;

    TextMeshProUGUI printScoreCode;
    public SendCameraTransform sct;

    void Start()
    {
        printScoreCode = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        
        if(truefalse)
        {
            printScoreCode.text = "플레이어 : " + playerScore;
        }
        else
        {
            printScoreCode.text = "상대방 : " + otherScore;
        }

    }
}