using Godot;
using System;
using System.Collections.Generic;

[Tool]
public partial class LineRenderer : MeshInstance3D {
    [Export] public Godot.Collections.Array<Vector3> points = new Godot.Collections.Array<Vector3> { new Vector3(0, 0, 0), new Vector3(0, 5, 0) };
    [Export] public float startThickness = 0.1f;
    [Export] public float endThickness = 0.1f;
    [Export] public int cornerSmooth = 5;
    [Export] public int capSmooth = 5;
    [Export] public bool drawCaps = true;
    [Export] public bool drawCorners = true;
    [Export] public bool globalCoords = true;
    [Export] public bool scaleTexture = true;

    private const float UV_CENTER = 0.5f;
    private const float FULL_CIRCLE = Mathf.Pi * 2;

    private Camera3D? camera;
    private Vector3 cameraOrigin;
    private ImmediateMesh? immediateMesh;

    public override void _Ready() {
        immediateMesh = new ImmediateMesh();
        Mesh = immediateMesh;
    }

    public override void _Process(double delta) {
        if (points.Count < 2) return;

        camera = GetViewport().GetCamera3D();
        if (camera == null) return;

        cameraOrigin = ToLocal(camera.GlobalTransform.Origin);
        GenerateMesh();
    }

    private void GenerateMesh() {
        float progressStep = 1.0f / points.Count;
        float progress = 0;
        float thickness = Mathf.Lerp(startThickness, endThickness, progress);
        float nextThickness = Mathf.Lerp(startThickness, endThickness, progress + progressStep);

        immediateMesh?.ClearSurfaces();
        immediateMesh?.SurfaceBegin(Mesh.PrimitiveType.Triangles);

        for (int i = 0; i < points.Count - 1; i++) {
            Vector3 startPoint = points[i];
            Vector3 endPoint = points[i + 1];

            if (globalCoords) {
                startPoint = ToLocal(startPoint);
                endPoint = ToLocal(endPoint);
            }

            Vector3 startOrthogonal = CalculateOrthogonal(startPoint, endPoint, thickness);
            Vector3 endOrthogonal = CalculateOrthogonal(startPoint, endPoint, nextThickness);

            Vector3 startPointOuter = startPoint + startOrthogonal;
            Vector3 startPointInner = startPoint - startOrthogonal;
            Vector3 endPointOuter = endPoint + endOrthogonal;
            Vector3 endPointInner = endPoint - endOrthogonal;

            if (i == 0 && drawCaps) {
                Cap(startPoint, endPoint, thickness, capSmooth);
            }

            AddVertices(startPointOuter, startPointInner, endPointOuter, endPointInner);

            if (i == points.Count - 2 && drawCaps) {
                Cap(endPoint, startPoint, nextThickness, capSmooth);
            }
            else if (drawCorners && i < points.Count - 2) {
                DrawCorner(i, endPoint, endOrthogonal, nextThickness);
            }

            progress += progressStep;
            thickness = Mathf.Lerp(startThickness, endThickness, progress);
            nextThickness = Mathf.Lerp(startThickness, endThickness, progress + progressStep);
        }

        immediateMesh?.SurfaceEnd();
    }

    private Vector3 CalculateOrthogonal(Vector3 A, Vector3 B, float thickness) {
        Vector3 AB = B - A;
        return (cameraOrigin - ((A + B) / 2)).Cross(AB).Normalized() * thickness;
    }

    private void AddVertices(Vector3 startPointOuter, Vector3 startPointInner, Vector3 endPointOuter, Vector3 endPointInner) {
        if (scaleTexture) {
            float segmentLength = (endPointOuter - startPointOuter).Length();
            float segmentFloor = Mathf.Floor(segmentLength);
            float segmentFraction = segmentLength - segmentFloor;

            immediateMesh?.SurfaceSetUV(new Vector2(segmentFloor, 0));
            immediateMesh?.SurfaceAddVertex(startPointOuter);
            immediateMesh?.SurfaceSetUV(new Vector2(-segmentFraction, 0));
            immediateMesh?.SurfaceAddVertex(endPointOuter);
            immediateMesh?.SurfaceSetUV(new Vector2(segmentFloor, 1));
            immediateMesh?.SurfaceAddVertex(startPointInner);
            immediateMesh?.SurfaceSetUV(new Vector2(-segmentFraction, 0));
            immediateMesh?.SurfaceAddVertex(endPointOuter);
            immediateMesh?.SurfaceSetUV(new Vector2(-segmentFraction, 1));
            immediateMesh?.SurfaceAddVertex(endPointInner);
            immediateMesh?.SurfaceSetUV(new Vector2(segmentFloor, 1));
            immediateMesh?.SurfaceAddVertex(startPointInner);
        }
        else {
            immediateMesh?.SurfaceSetUV(new Vector2(1, 0));
            immediateMesh?.SurfaceAddVertex(startPointOuter);
            immediateMesh?.SurfaceSetUV(new Vector2(0, 0));
            immediateMesh?.SurfaceAddVertex(endPointOuter);
            immediateMesh?.SurfaceSetUV(new Vector2(1, 1));
            immediateMesh?.SurfaceAddVertex(startPointInner);
            immediateMesh?.SurfaceSetUV(new Vector2(0, 0));
            immediateMesh?.SurfaceAddVertex(endPointOuter);
            immediateMesh?.SurfaceSetUV(new Vector2(0, 1));
            immediateMesh?.SurfaceAddVertex(endPointInner);
            immediateMesh?.SurfaceSetUV(new Vector2(1, 1));
            immediateMesh?.SurfaceAddVertex(startPointInner);
        }
    }

    private void DrawCorner(int i, Vector3 B, Vector3 orthogonalABEnd, float nextThickness) {
        if (i + 2 >= points.Count) return;

        Vector3 C = points[i + 2];
        if (globalCoords) {
            C = ToLocal(C);
        }

        Vector3 BC = C - B;
        Vector3 orthogonalBCStart = (cameraOrigin - ((B + C) / 2)).Cross(BC).Normalized() * nextThickness;

        float angleDot = (B - points[i]).Dot(orthogonalBCStart);

        if (angleDot > 0) {
            Corner(B, B + orthogonalABEnd, B + orthogonalBCStart, cornerSmooth);
        }
        else {
            Corner(B, B - orthogonalBCStart, B - orthogonalABEnd, cornerSmooth);
        }
    }

    private void Corner(Vector3 center, Vector3 start, Vector3 next, int smoothing) {
        Vector3 axis = (start - center).Normalized();
        float angleStep = Mathf.Pi / smoothing;

        for (int i = 0; i <= smoothing; i++) {
            float angle = angleStep * i;
            Vector3 offset = axis.Rotated(Vector3.Up, angle) * (start - center).Length();
            Vector3 vertex = center + offset;

            immediateMesh?.SurfaceAddVertex(vertex);
            immediateMesh?.SurfaceSetUV(new Vector2(i / (float)smoothing, 1));
        }
    }

    private void Cap(Vector3 center, Vector3 pivot, float thickness, int smoothing) {
        Vector3 orthogonal = (cameraOrigin - center).Cross(center - pivot).Normalized() * thickness;
        Vector3 axis = (center - cameraOrigin).Normalized();

        List<Vector3> vertices = new List<Vector3>();

        for (int i = 0; i <= smoothing; i++) {
            float angle = FULL_CIRCLE * i / smoothing;
            Vector3 offset = orthogonal.Rotated(axis, angle);
            vertices.Add(center + offset);
        }

        for (int i = 0; i < smoothing; i++) {
            immediateMesh?.SurfaceAddVertex(center);
            immediateMesh?.SurfaceSetUV(new Vector2(UV_CENTER, UV_CENTER));

            immediateMesh?.SurfaceAddVertex(vertices[i]);
            immediateMesh?.SurfaceSetUV(new Vector2((float)Math.Cos(FULL_CIRCLE * i / smoothing) * UV_CENTER + UV_CENTER, (float)Math.Sin(FULL_CIRCLE * i / smoothing) * UV_CENTER + UV_CENTER));

            immediateMesh?.SurfaceAddVertex(vertices[i + 1]);
            immediateMesh?.SurfaceSetUV(new Vector2((float)Math.Cos(FULL_CIRCLE * (i + 1) / smoothing) * UV_CENTER + UV_CENTER, (float)Math.Sin(FULL_CIRCLE * (i + 1) / smoothing) * UV_CENTER + UV_CENTER));
        }
    }

}