using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DefectPlacer : MonoBehaviour
{
    public ARRaycastManager raycast;
    public Transform xrOrigin;
    public GameObject markerPrefab;

    static List<ARRaycastHit> hits = new();

    void Update()
    {
        // AR only works in Scan mode
        if (!UIManager.Instance.IsScanMode)
            return;

        if (Input.touchCount == 0) return;

        var touch = Input.GetTouch(0);

        // Don't place if touching UI
        if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            return;

        if (touch.phase != TouchPhase.Began) return;

        if (raycast.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose pose = hits[0].pose;

            var marker = Instantiate(markerPrefab, pose.position, pose.rotation, xrOrigin);
            var markerData = marker.GetComponent<DefectMarker>();
            markerData.pose = pose;

            UIManager.Instance.OpenForm(markerData);
        }
    }
}
