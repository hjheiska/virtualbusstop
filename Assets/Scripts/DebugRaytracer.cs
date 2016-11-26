using UnityEngine;
using System.Collections;

public class DebugRaytracer : MonoBehaviour {

    private GameObject hololenseData;
    public GameObject mainCamera;
    public GameObject mapObject;
    public GameObject weatherObject;
    public GameObject soundObject;
    private bool mapObjectInstantiated;
    private bool weatherObjectInstantiated;
    private bool soundObjectInstantiated;

    void Start()
    {
        hololenseData = GameObject.Find("hololenseData");
    }

    void FixedUpdate()
    {

        RaycastHit hitInfo;

        if (!mapObjectInstantiated)
        {
            if (Physics.Raycast(
             mainCamera.transform.position,
             Vector3.forward,
             out hitInfo,
             999.0f))
            {
                mapObjectInstantiated = true;
                Instantiate(mapObject, hitInfo.point, Quaternion.identity);
            }
        }
        if (!weatherObjectInstantiated)
        { 
            if (Physics.Raycast(
                    mainCamera.transform.position,
                    Vector3.up,
                    out hitInfo,
                    999.0f))
            {
                weatherObjectInstantiated = true;
                Instantiate(weatherObject, hitInfo.point, Quaternion.identity);
            }
        }
        if(!soundObjectInstantiated)
        {
            soundObjectInstantiated = true;
            Instantiate(soundObject, Vector3.up + Vector3.forward, Quaternion.identity); 
        }       
    }
}
