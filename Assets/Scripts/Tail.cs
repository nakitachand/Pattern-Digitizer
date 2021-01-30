using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(LineRenderer))]
public class Tail : MonoBehaviour
{
    LineRenderer line;

    public float pointSpacing = .1f;
    public Transform cursor;
    List<Vector2> points;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();

        points = new List<Vector2>();

        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(points.Last(), cursor.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    void SetPoint()
    {
        points.Add(cursor.position);

        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, cursor.position);
    }
}
