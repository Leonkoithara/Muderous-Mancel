using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        var wantedPosition = Camera.main.ScreenToWorldPoint (mousePos);
        transform.position = wantedPosition;
    }
}
