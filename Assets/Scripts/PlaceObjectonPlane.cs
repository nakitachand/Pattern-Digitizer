using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectonPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private Pose placementPose;
    private bool placementPoseIsValid;

    public GameObject positionIndicator;
    public GameObject prefabToPlace;
    public Camera aRCamera;
    private Vector2 touchPosition;
    private PlaneSelector currentPlane;
    private List<PlaneSelector> detectedPlanes=new List<PlaneSelector>();
   //change detectedPlanes to a list


    // Start is called before the first frame update
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            PlaceObject();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            //when screen is touched, 
            if (touch.phase == TouchPhase.Began)
            {
                //declares ray variable from camera to screen, as parameter for Physics.Raycast  
                Ray ray = aRCamera.ScreenPointToRay(touchPosition);

                //Casts ray and returns true if collision was detected
                if (Physics.Raycast(ray, out RaycastHit hitPlane))
                {
                    currentPlane = hitPlane.transform.GetComponent<PlaneSelector>();
                   
                    if (currentPlane != null)
                    {
                        PlaneSelector[] allPlaneSelectors = FindObjectsOfType<PlaneSelector>();

                        ChangeSelectedPlane(currentPlane, allPlaneSelectors);
                    }
                }
            }


            //if (touch.phase == TouchPhase.Ended)
            //{
            //    //tracePlane = hitPlane;
            //    planeIsSelected = true;
            //    Debug.Log("Plane is selected.");
            //}
        }
    }

    private void UpdatePlacementPose()
    {
        //get screen center point
        var screenCenter = aRCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        //declare array for raycast hits
        var hits = new List<ARRaycastHit>();

        //track all rays
        raycastManager.Raycast(screenCenter, hits, TrackableType.All);

        //check if placementPoseisValid is true by checking if hit count > 0
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
            var cameraForward = aRCamera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
            positionIndicator.SetActive(true);
            positionIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            positionIndicator.SetActive(false);
        }

        

    }

    private void OnEnable()
    {
        planeManager.planesChanged += OnPlaneChange;

    }

    private void OnDisable()
    {
        
    }

    private void OnPlaneChange(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            detectedPlanes.Add(plane.GetComponent<PlaneSelector>());
            //plane.gameObject.AddComponent<PlaneSelector>();
        }
    }

    private void PlaceObject()
    {
        Instantiate(prefabToPlace, placementPose.position, placementPose.rotation);
    }

    private void ChangeSelectedPlane(PlaneSelector selectedPlane, PlaneSelector[] allPlaneSelectors)
    {
        foreach(PlaneSelector current in allPlaneSelectors)
        {
            if (current != selectedPlane)
            {
                current.IsSelected = false;
                current.UnHighlight();
            }
            else
            {
                current.IsSelected = true;
                current.Highlight();
            }
        }
        
        
        
        
    }
}
