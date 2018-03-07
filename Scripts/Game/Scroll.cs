using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

    private float speed;

    private Renderer myRenderer;

    void Awake () {

        myRenderer = GetComponent<Renderer>();
    }

    void Update () {

        speed = SpeedManager.worldSpeed / 2;

        Vector2 offset =  new Vector2(Time.time * speed, 0);

        myRenderer.material.mainTextureOffset = offset;
    }
}
