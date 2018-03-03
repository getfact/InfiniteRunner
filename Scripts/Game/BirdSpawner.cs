using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {

    public GameObject birdPrefab;
    public Transform spawnPoint;

    void Awake () {

        Spawn();
    }

    void Update () {

        if (!BirdController.isDead) {

            return;
        }

        Spawn();

    }

    private void Spawn () {

        BirdController.isDead = false;
        Instantiate(birdPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
