using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour
{

    public Vector3 targetPos;

    private float smoothmove = 1f;
    void Start()
    {
        targetPos = transform.position;
        targetPos.z = -10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,targetPos,smoothmove*Time.deltaTime);
    }
}
