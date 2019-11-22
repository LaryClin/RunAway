using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenCube : MonoBehaviour {

    public Transform cube;
    public Transform cube1;
    public Transform cube2;
    public Transform cube3;
    public float vitesseCubes;
    private string start;

    void Update()
    {
        if (start == "first")
        {
            cube.transform.position += Vector3.down * Time.deltaTime * vitesseCubes;
        }
        else if (start == "second")
        {
            cube1.transform.position += Vector3.down * Time.deltaTime * vitesseCubes;
        }
        else if (start == "third")
        {
            cube2.transform.position += Vector3.down * Time.deltaTime * vitesseCubes;
        }
        else if (start == "fourth")
        {
            cube3.transform.position += Vector3.down * Time.deltaTime * vitesseCubes;
        }
    }

    // lors de la collision avec le cube du bas, actionner le cube du haut (fonction sur 4 cubes)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "FallenCube1")
        {
            start = "first";
        }
        else if (collision.gameObject.name == "FallenCube1 (1)")
        {
            start = "second";
        }
        else if (collision.gameObject.name == "FallenCube1 (2)")
        {
            start = "third";
        }
        else if (collision.gameObject.name == "FallenCube1 (3)")
        {
            start = "fourth";
        }
    }
}
