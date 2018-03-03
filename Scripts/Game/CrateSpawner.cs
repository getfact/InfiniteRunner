using UnityEngine;

public class CrateSpawner : MonoBehaviour {

    public GameObject cratePrefab;
    public Transform spawnPoint;

    void Awake () {

        Spawn();
    }

    void Update () {

        if (!CrateController.isDead) {

            return;
        }

        Spawn();
    }

    public void Spawn () {

        CrateController.isDead = false;
        Instantiate(cratePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
