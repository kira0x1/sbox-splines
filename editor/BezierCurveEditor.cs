namespace Kira.Splines.Editor;

using System.Drawing;

public class BezierCurveEditor : EditorTool<BezierCurveRenderer>
{
    public override void OnEnabled()
    {
    }

    public override void OnUpdate()
    {
        var target = GetSelectedComponent<BezierCurveRenderer>();
        var curve = target.curve;

        for (int i = 0; i < curve.points.Length; i++)
        {
            var point = curve.points[i];
            var moved = CreateHandle($"{i} point", point, out Vector3 nextPos);
            if (moved)
            {
                curve.points[i] = nextPos;
            }
        }
    }

    private bool CreateHandle(string name, Vector3 pos, out Vector3 movePos)
    {
        using (Gizmo.Scope(name))
        {
            Gizmo.Transform = new Transform(pos);
            bool moved = Gizmo.Control.Position("pos1", pos, out Vector3 nextPos);
            movePos = moved ? nextPos : Vector3.Zero;
            return moved;
        }
    }

    public override void OnDisabled()
    {
    }
}