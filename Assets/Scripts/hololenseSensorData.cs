using UnityEngine;
using System.Collections;
using UnityEngine.VR.WSA.Input;

public class hololenseSensorData : MonoBehaviour {

    public int numberOfHands;
    public bool handPinched;
    public Vector3 handPosition;
    public Vector3 pinchHitLocation;
    public GameObject mainCamera;
    public GameObject gazeDebugObject;

	// Use this for initialization
	void Start () {
        InteractionManager.SourcePressed += InteractionManager_SourcePressed;
        InteractionManager.SourceUpdated += InteractionManager_SourceUpdated;
        InteractionManager.SourceReleased += InteractionManager_SourceReleased;

        InteractionManager.SourceDetected += InteractionManager_SourceDetected;
        InteractionManager.SourceLost += InteractionManager_SourceLost;
    }

    private void InteractionManager_SourceReleased(InteractionSourceState state)
    {
        handPinched = false;
    }

    private void InteractionManager_SourceUpdated(InteractionSourceState state)
    {
        state.properties.location.TryGetPosition(out handPosition);  
    }

    private void InteractionManager_SourcePressed(InteractionSourceState state)
    {
        handPinched = true;
        RaycastHit hitInfo;
        if (Physics.Raycast(
                mainCamera.transform.position,
                mainCamera.transform.forward,
                out hitInfo,
                999.0f))
        {
            pinchHitLocation = hitInfo.point;
        }
    }

    private void InteractionManager_SourceLost(InteractionSourceState state)
    {
        numberOfHands--;
    }

    private void InteractionManager_SourceDetected(InteractionSourceState state)
    {
        numberOfHands++;
    }

    // Update is called once per frame
    void Update () {
        RaycastHit hitInfo;
        if (Physics.Raycast(
                mainCamera.transform.position,
                mainCamera.transform.forward,
                out hitInfo,
                999.0f))
        {
            gazeDebugObject.transform.position = hitInfo.point;
        }
    }

    void destroy()
    {
        InteractionManager.SourcePressed -= InteractionManager_SourcePressed;
        InteractionManager.SourceUpdated -= InteractionManager_SourceUpdated;
        InteractionManager.SourceReleased -= InteractionManager_SourceReleased;

        InteractionManager.SourceDetected -= InteractionManager_SourceDetected;
        InteractionManager.SourceLost -= InteractionManager_SourceLost;
    }
}
