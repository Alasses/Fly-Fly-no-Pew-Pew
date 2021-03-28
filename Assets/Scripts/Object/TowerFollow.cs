using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFollow : MonoBehaviour
{

    public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(followTarget.position.x + 8000 - 65, transform.position.y, transform.position.z);
    }
}
