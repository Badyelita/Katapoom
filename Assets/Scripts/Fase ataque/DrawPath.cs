using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{

    AimSystem aimSystem;
    LineRenderer lineRenderer;

    // Number of points on the line
    public int numPoints = 50;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;
    void Start()
    {
        aimSystem = GetComponent<AimSystem>();
        lineRenderer = GetComponent<LineRenderer>();
    }


    void Update()
    {
        //FIXME Fallo en las layers no cambia el renderer si choca
        if(GameManager.Instance.gameState==GameState.Playing && GameManager.Instance.playingState==PlayingState.Attack){
        lineRenderer.positionCount = (int)numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = aimSystem.ShootPoint.position;
        Vector3 startingVelocity = aimSystem.ShootPoint.up * aimSystem.force;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
            points.Add(newPoint);

            if(Physics.OverlapSphere(newPoint, 2, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());
    }
    }
}
