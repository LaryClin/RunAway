
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    public Transform[] target;
    public float ballSpeed;
    public float vitesseRotation;
    private int current;

	// déplacement de la boule principale qui suit le joueur au début (map 1)
	void Update () {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, ballSpeed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

        }
        else current = (current + 1) % target.Length;
        transform.Rotate(Vector3.up * Time.deltaTime * vitesseRotation);
	}
}
