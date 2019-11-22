using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
    public Transform cube;
    public float vitesseCubes;
    private string start;

    // Update is called once per frame
    void Update()
    {
        if (start == "ok")
        {
            cube.transform.position += Vector3.back * Time.deltaTime * vitesseCubes;
        }
    }

    // lors de la collision avec la lave
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            start = "ok";
        }
    }
}
