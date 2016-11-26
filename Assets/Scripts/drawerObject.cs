using UnityEngine;
using System.Collections;

public class drawerObject : MonoBehaviour {

    private bool drawerActive;
    private GameObject hololenseData;
    private Vector3 originalPosition;
    private Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
        hololenseData = GameObject.Find("hololenseData");
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update () {
        hololenseSensorData holoData = hololenseData.GetComponent<hololenseSensorData>();

        if (holoData.handPinched)
        {
            float distance = (holoData.pinchHitLocation - transform.position).magnitude;
            if(distance < 0.2f)
            {
                drawerActive = true;
            }
        }
        else
        {
            drawerActive = false;
            targetPosition = originalPosition;
        }

        if (drawerActive)
        {
            Vector3 handPosition = holoData.handPosition;
            targetPosition = new Vector3(originalPosition.x, handPosition.y, originalPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
	}
}
