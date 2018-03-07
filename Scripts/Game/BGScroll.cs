using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour {

    public float speed = 0.8f;

    private Renderer myRenderer;

    void Awake () {

        myRenderer = GetComponent<Renderer>();
    }

    void Update () {

        Vector2 offset =  new Vector2(Time.time * speed, 0);

        myRenderer.material.mainTextureOffset = offset;
    }
}
