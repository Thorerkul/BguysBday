using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform centerOrigin;
    public Transform currentTarget;

    private void Start()
    {
        currentTarget = centerOrigin;
    }

    private void Update()
    {
        transform.LookAt(currentTarget);
        //transform.position = new Vector3(Mathf.Lerp(target1.position.x, target2.position.x, currentLerp), transform.position.y, transform.position.z);
    }
}
