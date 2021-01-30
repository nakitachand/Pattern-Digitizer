using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//script to select a detected plane by touch
//needs to have a function return a pose or transform for the lastSelectedPlane

public class PlaneSelector : MonoBehaviour
{
    //private ARPlaneManager planeManager;
    //private ARPlane tracePlane;
    //private GameObject cursor;

    //public Button planeButton;

    private bool planeIsSelected;
    public Material highlightedPlane;
    //private Vector2 touchPosition;
    //public Camera arCamera;

    public Material unHighlightedPlane;

    public bool IsSelected
    {
        get 
        { 
            return this.planeIsSelected; 
        }

        set 
        { 
            planeIsSelected = value; 


        }
    }

    public void Highlight()
    {
        this.GetComponent<Renderer>().material = highlightedPlane;
    }

    public void UnHighlight()
    {
        this.GetComponent<Renderer>().material = unHighlightedPlane;

    }

    public void OnEnable()
    {
        //unHighlightedPlane = GetComponent<Renderer>().material;
    }

    public void OnDisable()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if no plane is selected
    //    if (tracePlane == null && planeIsSelected == false)
    //    {
    //        //run plane selector function
    //        //SelectPlane();
    //    }
    //}

    //void SelectPlane()
    //{
    //    //run until plane is selected (planeIsSelected == true)
    //    while (planeIsSelected == false)
    //    {
    //        //check for screen touch & ray cast
    //        if (Input.touchCount > 0)
    //        {
    //            Touch touch = Input.GetTouch(0);

    //            touchPosition = touch.position;

    //            //when screen is touched, 
    //            if (touch.phase == TouchPhase.Began)
    //            {
    //                //declares ray variable from camera to screen, as parameter for Physics.Raycast  
    //                Ray ray = arCamera.ScreenPointToRay(touchPosition);

    //                //Casts ray and returns true if collision was detected
    //                if (Physics.Raycast(ray, out RaycastHit hitPlane))
    //                {
    //                    var lastSelectedPlane = hitPlane.transform;

    //                    if (lastSelectedPlane != null)
    //                    {

    //                        var selectedPlaneRenderer = lastSelectedPlane.GetComponent<Renderer>();
    //                        if (selectedPlaneRenderer != null)
    //                        {
    //                            selectedPlaneRenderer.material = highlightedPlane;
    //                        }
    //                    }
    //                }
    //            }


    //            if (touch.phase == TouchPhase.Ended)
    //            {
    //                //tracePlane = hitPlane;
    //                planeIsSelected = true;
    //                Debug.Log("Plane is selected.");
    //            }
    //        }
    //    }
    //}

    //void TrackPlanes()
    //{
    //    //plane tracking function
    //    foreach (ARPlane plane in planeManager.trackables)
    //    {
    //        if (plane.alignment == PlaneAlignment.HorizontalUp && planeIsSelected == false)
    //        {
    //            //check for screen touch & ray cast
    //            if (Input.touchCount > 0)
    //            {
    //                Touch touch = Input.GetTouch(0);

    //                touchPosition = touch.position;

    //                //when screen is touched, 
    //                if (touch.phase == TouchPhase.Began)
    //                {
    //                    //declares ray variable from camera to screen, as parameter for Physics.Raycast  
    //                    Ray ray = arCamera.ScreenPointToRay(touchPosition);

    //                    //Casts ray and returns true if collision was detected
    //                    if (Physics.Raycast(ray, out RaycastHit hitPlane))
    //                    {
    //                        //assigns lastSelectedPlane to the transform of the hit received
    //                        var lastSelectedPlane = hitPlane.transform;

    //                        //checks if lastSelectedPlane contains a hit
    //                        if (lastSelectedPlane != null)
    //                        {
    //                            var selectedPlaneRenderer = lastSelectedPlane.GetComponent<Renderer>();
                                
    //                            //checks if SelectedPlaneRender contains a material
    //                            if (selectedPlaneRenderer != null)
    //                            {
    //                                //assigns material of lastSelectedPlane to highlightedPlane material
    //                                selectedPlaneRenderer.material = highlightedPlane;
    //                            }
    //                        }
    //                    }
    //                }


    //                if (touch.phase == TouchPhase.Ended)
    //                {
    //                    tracePlane = plane;
    //                    planeIsSelected = true;
    //                    planeManager.detectionMode = PlaneDetectionMode.None;
                        
                        
    //                    //what to execute when touch ends
    //                    //isolate selected hit and clear all other tracked planes
    //                }
    //            }
    //        }
    //    }
    //}
}
