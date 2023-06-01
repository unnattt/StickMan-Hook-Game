using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    LineRenderer line;
    DistanceJoint2D joint;
    public List<Transform> target;
    bool check;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.positionCount = 0;
        
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&& !check)
        {
            check = true;
            GetTargetPosition();
        }

        else if(Input.GetMouseButtonDown(0))
        {
            check = false;
            joint.enabled = false;
            line.positionCount = 0;
        }
        DrawLine();

    }

    void GetTargetPosition()
    {
        for (int i = 0; i < target.Count; i++)
        {
            joint.enabled = true;
            joint.connectedAnchor = target[i].transform.position;           
            line.positionCount = 2;
        }
    }

    private void DrawLine()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, target[0].transform.position);
    }

}
