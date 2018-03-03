using UnityEngine;

public class CrateController : MonoBehaviour {

    public static bool isDead = false;

    public float speed;
    public int points = 20;

    void Update () {

        Move();
    }

    void OnBecameInvisible () {

        Die();
    }

    private void Move () {

        if (this != null) {

            speed = SpeedManager.worldSpeed;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void Die () {

        isDead = true;

        PlayerStats.score += points;
//        SpeedManager.worldSpeed += 1f;

        Destroy(gameObject);
    }
}
