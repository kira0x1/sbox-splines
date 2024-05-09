namespace Kira.Splines;

public class BezierCurve
{
    [Property]
    public Vector3[] points { get; set; } = new Vector3[]
    {
        new Vector3(0f, 0f, 0f),
        new Vector3(60f, 0f, 50f),
        new Vector3(120f, 0f, 0f)
    };

    public void Reset()
    {
        points = new Vector3[]
        {
            new Vector3(0f, 0f, 0f),
            new Vector3(60f, 0f, 50f),
            new Vector3(120f, 0f, 0f)
        };
    }

    public Vector3 GetPoint(float t)
    {
        return Bezier.GetPoint(points[0], points[1], points[2], t);
    }
}