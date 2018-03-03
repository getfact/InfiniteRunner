using UnityEngine;

public class SpeedManager : MonoBehaviour {

    public static float worldSpeed;
    public float startSpeed = 2.5f;

    private int lastScore = 0;

    void Awake () {

        worldSpeed = startSpeed;
    }

    void Update () {

        if (PlayerStats.score >= lastScore + 100) {

            ApplySpeed();
        }
    }

    private void ApplySpeed () {

        worldSpeed += 1f;
        lastScore = PlayerStats.score;
        Debug.Log("World Speed Increased");
    }
}
