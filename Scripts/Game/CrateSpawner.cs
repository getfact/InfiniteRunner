using UnityEngine;
using System.Collections;

public class CrateSpawner : MonoBehaviour {

    public GameObject doubleCratePrefab;
    public GameObject tripleCratePrefab;
    public Transform spawnPoint;

    void Awake () {

        RandomCrate();
    }

    void Update () {

        if (!CrateController.isDead) {

            return;
        }

        RandomCrate();
    }

    private void RandomCrate () {

        if (Random.value < 0.5f) {

            Spawn(tripleCratePrefab);
        }

        else {


            Spawn(doubleCratePrefab);
        }
    }

    public void Spawn (GameObject prefab) {

        CrateController.isDead = false;
        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
