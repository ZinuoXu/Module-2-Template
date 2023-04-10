using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameRoute : MonoBehaviour
{
    Transform[] childObjects;
    public List<Transform> childrenNodeList = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        FillNodes();

        for(int i = 0; i < childrenNodeList.Count;i++)
        { 
            Vector3 currentPos = childrenNodeList[i].position;
            if(i > 0)
            {
                Vector3 prevNode = childrenNodeList[i - 1].position;
                Gizmos.DrawLine(prevNode, currentPos);
            }
        }
    }

    void FillNodes()
    {
        childrenNodeList.Clear();
        childObjects = GetComponentsInChildren<Transform>();

        foreach(Transform child in childObjects)
        {
            if(child != this.transform)
            {
                childrenNodeList.Add(child);
            }
        }
    }
}



