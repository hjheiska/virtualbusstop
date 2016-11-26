using UnityEngine;
using System.Collections;

public class draggableObject : MonoBehaviour {

    public float grabDistance;
    private GameObject hololenseData;

    void Start()
    {
        hololenseData = GameObject.Find("hololenseData");
    }

	// Update is called once per frame
	void Update () {
        Vector3 userHandPosition = hololenseData.GetComponent<hololenseSensorData>().handPosition;
        if((userHandPosition - transform.position).magnitude < grabDistance)
            transform.position = hololenseData.GetComponent<hololenseSensorData>().handPosition;
    }
}
