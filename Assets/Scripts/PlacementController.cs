using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    private ARRaycastManager arRaycastManager;

    public GameObject PlacedPrefab
    {
        get
        {
            return placedPrefab;
        }
        set
        {
            placedPrefab = value;
        }
    }


    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    //keep track of screen touches by using raycast to see if touch collides with plane created
    //returns true value and saves touch position
    bool TryGetTouchPosition (out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            //set touchPosition = screen touch point
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        else
        {
            //sets touchPosition = default when there are no touches
            touchPosition = default;
            return false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //check for no touches
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        //checks if we have hit a collider with a raycast
        if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            //places prefabs at the location detected in the collision on the plane
            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        }
    }

    static List<ARRaycastHit>hits = new List<ARRaycastHit>();
}
