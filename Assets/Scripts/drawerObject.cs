using UnityEngine;
using System.Collections;

public class drawerObject : MonoBehaviour {

    private bool drawerActive;
    private GameObject hololenseData;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    public GameObject circleRoot;
    public GameObject selectorBar;
    public GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        hololenseData = GameObject.Find("hololenseData");
        originalPosition = transform.position;
        mainCamera = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update () {
        hololenseSensorData holoData = hololenseData.GetComponent<hololenseSensorData>();
        RaycastHit hitInfo;

        if (Physics.Raycast(
            mainCamera.transform.position,
            mainCamera.transform.forward,
            out hitInfo,
            999.0f))
        {
            float distance = (hitInfo.point - selectorBar.transform.position).magnitude;
            if (distance < 0.2f)
            {
                selectorBar.SetActive(true);
            }
            else
            {
                selectorBar.SetActive(false);
            }
        }


        if (holoData.handPinched)
        {
            float distance = (holoData.pinchHitLocation - selectorBar.transform.position).magnitude;
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
            circleRoot.SetActive(true);
            selectorBar.SetActive(false);
        }
        else
        {
            circleRoot.SetActive(false);
            selectorBar.SetActive(true);
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
	}
}
