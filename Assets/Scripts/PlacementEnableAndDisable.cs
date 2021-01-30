using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


//code to enable and disable plane selection via toggle button


[RequireComponent(typeof(ARRaycastManager))]

public class PlacementEnableAndDisable : MonoBehaviour
{
	//MODIFY THIS TO ENABLE AND DISABLE PLANE DETECTION UPON PLANE SELECTION


	//public GameObject placedPrefab;

	public GameObject welcomePanel;

	public Button dismissButton;

	public Camera arCamera;

	//private PlacementObject[] placedObject;

	//private Vector2 touchPosition = default;

	//private ARRaycastManager arRaycastManager;

	//private bool onTouchHold = false;

	//private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

	//private ARPlane lastSelectedPlane;

	[SerializeField]
	private Material highlightedPlane;

	public Button toggleButton;

	private ARPlaneManager aRPlaneManager;

	

	void Awake()
	{
		//arRaycastManager = GetComponent<ARRaycastManager>();
		dismissButton.onClick.AddListener(Dismiss);

		aRPlaneManager = GetComponent<ARPlaneManager>();

		if (toggleButton != null)
		{
			toggleButton.onClick.AddListener(TogglePlaneDetection);
		}
	}

	private void Dismiss() => welcomePanel.SetActive(false);
    

    private void TogglePlaneDetection()
	{
		aRPlaneManager.enabled = !aRPlaneManager.enabled;

		foreach (ARPlane plane in aRPlaneManager.trackables)
		{
			plane.gameObject.SetActive(aRPlaneManager.enabled);
		}

		toggleButton.GetComponentInChildren<Text>().text = aRPlaneManager.enabled ?
			"Disable Plane Dectect" : "Enable Plane Detection";
	}

    void Update()
    {
        if (welcomePanel.activeSelf)
            return;

   //     if (Input.touchCount> 0)
   //     {
			//Touch touch = Input.GetTouch(0);

			//touchPosition = touch.position;

			////when screen is touched, 
			//if(touch.phase == TouchPhase.Began)
   //         {
			//	//declares ray variable from camera to screen, as parameter for Physics.Raycast  
			//	Ray ray = arCamera.ScreenPointToRay(touchPosition);
				
			//	//Casts ray and returns true if collision was detected
			//	if(Physics.Raycast(ray, out RaycastHit hitPlane))
   //             {
			//		var lastSelectedPlane = hitPlane.transform;
					
			//		if(lastSelectedPlane != null)
   //                 {

			//			var selectedPlaneRenderer = lastSelectedPlane.GetComponent<Renderer>();
			//			if(selectedPlaneRenderer != null)
   //                     {
			//				 selectedPlaneRenderer.material = highlightedPlane;
   //                     }
   //                     ////defines array of placementobjects 
   //                     ARPlane[] allOtherPlanes = FindObjectsOfType<ARPlane>();
   //                     foreach (ARPlane plane in allOtherPlanes)
   //                     {
   //                         plane.Selected = placementObject == lastSelectedPlane;
   //                     }
   //                 }
   //             }
   //         }


			//if(touch.phase == TouchPhase.Ended)
   //         {
			//	//what to execute when touch ends
   //         }
   //     }

		//if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
  //      {
		//	Pose hitPose = hits[0].pose;

		//	if(placedObject == null)
  //          {
		//		placedObject = Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
		//	}
		//	else
  //          {
		//		if(onTouchHold)
  //              {
		//			placedObject.transform.position = hitPose.position;
		//			placedObject.transform.rotation = hitPose.rotation;
  //              }
  //          }
  //      }
    }
}