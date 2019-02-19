using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private float x;
    private float z;
    // Start is called before the first frame update

    void Start()
    {
        x = transform.position.x;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1f, 0));

        transform.position = new Vector3(x, Mathf.Sin(Time.time * 2f) * .5f, z);
    }
}
