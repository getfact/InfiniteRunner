using UnityEngine;

public class SpawnCrate : MonoBehaviour {

    public GameObject cratePrefab;
    public Transform spawnPoint;

    void Update () {

        if (Input.GetButtonDown("Fire1")) {

            Spawn();
        }
    }

    private void Spawn () {

        Instantiate(cratePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
