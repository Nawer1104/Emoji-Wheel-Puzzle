using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public int segments = 64;
    public float radius = 1f;
    public int numPoints = 6;

    LineRenderer line;

    public GameObject[] objsToRespawn;

    public List<Transform> circlePoints = new List<Transform>();



    void Start()
    {


        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
        CreateCirclePoints();
    }

    void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 0f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }

    void CreateCirclePoints()
    {
        float angleIncrement = 360f / numPoints;
        Vector3[] points = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float angle = i * angleIncrement;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            points[i] = new Vector3(x, y, 0f);

            GameObject obj = Instantiate(objsToRespawn[i], points[i], Quaternion.identity);
            
            circlePoints.Add(obj.transform);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Add(obj);
        }
    }
}
