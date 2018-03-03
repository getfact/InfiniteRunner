using UnityEngine;

public class BirdController : MonoBehaviour {

    public static bool isDead = false;

    public float speed;

    void Update () {

        Move();
    }

    void OnBecameInvisible () {

        Die();
    }

    private void Move () {

        if (this != null) {

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void Die () {


        isDead = true;

        Destroy(gameObject);

    }
}
