using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int m_Score;
    Text m_ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        m_ScoreText = GetComponent<Text>();
        m_ScoreText.text = m_Score.ToString();
    }

    private void FixedUpdate()
    {
        ScoreHit(1);
    }

    public void ScoreHit(int points)
    {
        m_Score += points;
        m_ScoreText.text = m_Score.ToString();
    }
}
