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

    private Vector3 mapObjectLocation;

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
                mapObjectLocation = hitInfo.point - (Vector3.forward * 0.05f);
                Instantiate(mapObject, hitInfo.point - (Vector3.forward * 0.05f), Quaternion.identity);
            }
        }
        if (mapObjectInstantiated && !weatherObjectInstantiated)
        { 
            if (Physics.Raycast(
                    mapObjectLocation + Vector3.back * 0.1f,
                    Vector3.up,
                    out hitInfo,
                    999.0f))
            {
                weatherObjectInstantiated = true;
                Instantiate(weatherObject, hitInfo.point + (Vector3.down * 0.1f) + (Vector3.back * 0.5f), Quaternion.identity);
            }
        }
        if(!soundObjectInstantiated)
        {
            soundObjectInstantiated = true;
            Instantiate(soundObject, (Vector3.up + Vector3.forward), Quaternion.identity); 
        }       
    }
}
