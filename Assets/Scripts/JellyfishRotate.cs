using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishRotate : MonoBehaviour
{
    [SerializeField] int rotateSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotateSpeed, 0, Space.World);

    }
}
