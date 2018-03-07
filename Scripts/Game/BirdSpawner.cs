using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour {

    public GameObject birdPrefab;
    public Transform spawnPoint;
    public Transform secondSpawnPoint;

    void Awake () {

        RandomSpawn();
    }

    void Update () {

        if (!BirdController.isDead) {

            return;
        }

        RandomSpawn();
    }

    private void RandomSpawn () {

        if (Random.value < 0.5f) {

            Spawn(spawnPoint);
        }

        else {

            Spawn(secondSpawnPoint);
        }
    }

    private void Spawn (Transform spawn) {

        BirdController.isDead = false;
        Instantiate(birdPrefab, spawn.position, spawn.rotation);
    }
}
