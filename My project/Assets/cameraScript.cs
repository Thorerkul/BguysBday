using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform centerOrigin;

    public float timebetweentargets;
    public float currentLerp;
    public float currenttime;
    public bool isOnWayBack;
    public float rotationAngle;

    private void Update()
    {
        if (isOnWayBack)
        {
            currenttime += Time.deltaTime;
            if (currenttime >= timebetweentargets)
            {
                isOnWayBack = false;
            }
        }
        else
        {
            currenttime -= Time.deltaTime;
            if (currenttime <= 0)
            {
                isOnWayBack = true;
            }
        }

        currentLerp = isOnWayBack ? 1 : -1;

        transform.RotateAround(centerOrigin.position, Vector3.up, currentLerp * rotationAngle);

        transform.LookAt(centerOrigin);
        //transform.position = new Vector3(Mathf.Lerp(target1.position.x, target2.position.x, currentLerp), transform.position.y, transform.position.z);
    }
}
