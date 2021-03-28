using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFollow : MonoBehaviour
{

    public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(followTarget.position.x, transform.position.y, followTarget.position.z);
    }
}
