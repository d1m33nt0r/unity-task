using UnityEngine;
using UnityEngine.UI;
using System;

public class SessionScore : MonoBehaviour
{
    [SerializeField]
    private Text score;

    public string Score => score.text;

    public void AddOnePoint()
    {
        score.text = Convert.ToString(Convert.ToInt32(score.text) + 1);
    }

    public void RestartScore()
    {
        score.text = "0";
    }

}
