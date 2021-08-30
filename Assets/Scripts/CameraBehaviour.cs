using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    Transform character;

    public GameObject main_character;
    // Start is called before the first frame update
    void Start()
    {
        character = main_character.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 pos = character.position;
        pos.z = -10;

        transform.position = pos;
    }
}
