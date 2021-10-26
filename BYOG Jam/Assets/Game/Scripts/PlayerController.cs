using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public List<Vector3> pathPoints = new List<Vector3>();
    public Queue<Vector3> pathPointQueue = new Queue<Vector3>();

    private LineRenderer lineRenderer;
    public Camera orthoCam;
    public Camera persCam;
    private NavMeshAgent navMeshAgent;

    private bool canDrawPath;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        canDrawPath = true;
    }

    // private void OnMouseDown()
    // {
    //     canDrawPath = true;
    // }

    // private void OnMouseUp()
    // {
    //     canDrawPath = false;
    // }

    private void Update()
    {
        if(canDrawPath)
        {
            if(Input.GetMouseButtonDown(0))
            {
                pathPoints.Clear();
                pathPointQueue.Clear();
            }        

            if(Input.GetMouseButton(0))
            {
                Ray ray;//  = mainCam.ScreenPointToRay(Input.mousePosition);

                Vector2 mouseInput = Input.mousePosition;
                if(mouseInput.x / Screen.width > 0.5f)
                {
                    ray = persCam.ScreenPointToRay(mouseInput);
                }
                else
                {
                    ray = orthoCam.ScreenPointToRay(mouseInput);                    
                }

                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if(DistanceToLastPoint(hit.point) > 0.5f)
                    {
                        pathPoints.Add(hit.point);

                        lineRenderer.positionCount = pathPoints.Count;
                        lineRenderer.SetPositions(pathPoints.ToArray());
                    }
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                pathPointQueue = new Queue<Vector3>(pathPoints);
            }
        }

        if(ShouldSetPath())
        {
            navMeshAgent.SetDestination(pathPointQueue.Dequeue());
        }
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if(pathPoints.Count < 1)
        {
            return Mathf.Infinity;
        }

        return Vector3.Distance(pathPoints[pathPoints.Count - 1], point);
    }

    private bool ShouldSetPath()
    {
        if(pathPointQueue.Count < 1)
        {
            return false;
        }

        if(!navMeshAgent.hasPath || navMeshAgent.remainingDistance < 0.5f)
        {
            return true;
        }

        return false;
    }
}
