using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    public Text scoreText;

    void Update () {

        scoreText.text = PlayerStats.score.ToString();
    }
}
