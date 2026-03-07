using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathPointsGenerator : MonoBehaviour
{
    public enum PathShape
    {
        Circle,
        Square,
        Triangle,
        Pentagon,
        Hexagon,
        Star
    }

    [Header("Shape Settings")]
    public PathShape shape = PathShape.Circle;
    public float radius = 4f;

    [Header("Circle / Polygon Settings")]
    public int numberOfPoints = 50;   // Usado en Circle y polígonos para suavidad

    [Header("Star Settings")]
    public float innerRadius = 2f;    // Radio interior de la estrella

    public List<Vector2> pathPoints;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        GeneratePath();
        DrawPathLines();
    }

    void GeneratePath()
    {
        switch (shape)
        {
            case PathShape.Circle: GeneratePolygon(numberOfPoints); break;
            case PathShape.Square: GeneratePolygon(4); break;
            case PathShape.Triangle: GeneratePolygon(3); break;
            case PathShape.Pentagon: GeneratePolygon(5); break;
            case PathShape.Hexagon: GeneratePolygon(6); break;
            case PathShape.Star: GenerateStar(5); break;
        }
    }

    // Genera cualquier polígono regular (círculo = muchos lados)
    void GeneratePolygon(int sides)
    {
        pathPoints = new List<Vector2>();

        // Offset para que el cuadrado quede "recto" (45 grados)
        float angleOffset = (sides == 4) ? Mathf.PI / 4f : -Mathf.PI / 2f;

        for (int i = 0; i < sides; i++)
        {
            float angle = (2 * Mathf.PI / sides) * i + angleOffset;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            pathPoints.Add(new Vector2(x, y));
        }
    }

    // Genera una estrella de N puntas
    void GenerateStar(int points)
    {
        pathPoints = new List<Vector2>();
        int totalVerts = points * 2;

        for (int i = 0; i < totalVerts; i++)
        {
            float angle = (2 * Mathf.PI / totalVerts) * i - Mathf.PI / 2f;
            float r = (i % 2 == 0) ? radius : innerRadius;
            float x = Mathf.Cos(angle) * r;
            float y = Mathf.Sin(angle) * r;
            pathPoints.Add(new Vector2(x, y));
        }
    }

    void DrawPathLines()
    {
        lineRenderer.positionCount = pathPoints.Count + 1;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.loop = true;

        for (int i = 0; i < pathPoints.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(pathPoints[i].x, pathPoints[i].y, 0));
        }
        lineRenderer.SetPosition(pathPoints.Count, new Vector3(pathPoints[0].x, pathPoints[0].y, 0));
    }

    void OnDrawGizmos()
    {
        if (pathPoints == null) return;
        Gizmos.color = Color.red;
        foreach (Vector2 point in pathPoints)
        {
            Gizmos.DrawSphere(new Vector3(point.x, point.y, 0), 0.1f);
        }
    }
}