namespace Kira.Splines.Editor;

[EditorTool]
[Title("Splines")]
[Icon("linear_scale")]
public class SplineTool : EditorTool
{
    public override void OnEnabled()
    {
        AllowGameObjectSelection = false;
    }

    public override void OnUpdate()
    {
        var cursorPos = EditorScene.GizmoInstance.Input.CursorPosition;
        var sceneCam = EditorScene.GizmoInstance.Input.Camera;
        var cursorRay = sceneCam.GetRay(cursorPos).Project(1000f);

        using (Gizmo.Scope("cursor"))
        {
            Gizmo.Transform = new Transform(cursorRay, Rotation.LookAt(Vector3.Up));
            Gizmo.Draw.LineCircle(0, 30);
        }
    }
}