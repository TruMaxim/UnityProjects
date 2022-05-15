using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightMove : MonoBehaviour
{

    float napr = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * napr * 10f, 0, 0);
        if (transform.rotation.ToEuler().x < 0)
            napr = 1;
        if (transform.rotation.ToEuler().x > 1.55)
            napr = -1;

    }
}
