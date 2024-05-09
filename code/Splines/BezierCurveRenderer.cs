namespace Kira.Splines;

public class BezierCurveRenderer : Component, Component.ExecuteInEditor
{
    [Property]
    public int lineSteps { get; set; } = 10;

    [Property]
    public BezierCurve curve { get; set; }

    protected override void OnEnabled()
    {
        base.OnEnabled();
        curve = new BezierCurve();
        curve.Reset();
        Log.Info("enabled");
    }

    protected override void DrawGizmos()
    {
        DrawSplineGizmo();
    }

    private void DrawSplineGizmo()
    {
        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);

        using (Gizmo.Scope("Handles"))
        {
            Gizmo.Draw.Color = new Color(0.1f, 1f);
            Gizmo.Draw.Line(p0, p1);
            Gizmo.Draw.Line(p1, p2);
        }


        using (Gizmo.Scope("Line"))
        {
            Gizmo.Draw.Color = Color.White;

            Vector3 lineStart = curve.GetPoint(0f);
            for (int i = 1; i <= lineSteps; i++)
            {
                Vector3 lineEnd = curve.GetPoint(i / (float)lineSteps);
                Gizmo.Draw.Line(lineStart, lineEnd);
                lineStart = lineEnd;
            }
        }
    }

    private Vector3 ShowPoint(int index)
    {
        Vector3 point = curve.points[index];
        return point;
    }
}