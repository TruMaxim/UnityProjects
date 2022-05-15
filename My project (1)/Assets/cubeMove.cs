using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 oldPos;
    private float napr = 1;
    private float dlina = 5;

    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(napr * Time.deltaTime * 5f, 0, 0);
        if (transform.position.x > oldPos.x + dlina)
            napr = -1;
        if (transform.position.x < oldPos.x - dlina)
            napr = 1;
    }
}
