using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeDeplacement : MonoBehaviour {

    public float vitesseCube;
    public string sens;
	
    // au démarrage, définir le sens des cubes en avant
	void Start ()
    {
        sens = "forward";
	}
	
    // déplacer le cube en fonction du sens (cf: OnCollisionEnter)
	void Update ()
    {
        if (sens == "forward")
        {
            transform.position += Vector3.forward * Time.deltaTime* vitesseCube;
        }
        else if (sens == "back")
        {
            transform.position += Vector3.back * Time.deltaTime * vitesseCube;
        }
    }

    // lorsque le cube entre en collision avec un des 2 murs, inversers de déplacement du cube
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube (6)")
        {
            sens = "back";
        }
        else if (collision.gameObject.name == "Cube (2)")
        {
            sens = "forward";
        }
    }
}
