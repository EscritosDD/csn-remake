// Decompiled with JetBrains decompiler
// Type: 땺.떔
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public static class 떔
  {
    public static int 딟(
      [In] this RageSpline obj0,
      [In] bool obj1,
      [In] bool obj2,
      [In] bool obj3,
      [In] int obj4,
      [In] float obj5)
    {
      obj0.SetVertexCount(obj0.GetVertexCount());
      if ((double) Mathf.Abs((float) ((Component) obj0).gameObject.transform.localScale.x) <= 0.0 || (double) Mathf.Abs((float) ((Component) obj0).gameObject.transform.localScale.y) <= 0.0 || (double) Mathf.Abs((float) ((Component) obj0).gameObject.transform.localScale.z) <= 0.0)
        return obj4;
      int num1 = obj0.GetVertexCount() + 1;
      int num2 = (int) ((double) num1 * (double) obj5);
      if (num2 > num1)
        num2 = num1;
      if (obj2)
        떔.딟(obj0, obj4, num2);
      떔.딟(obj0, obj1);
      if (obj3)
        obj0.RefreshPhysics();
      return num2 >= num1 ? 0 : num2;
    }

    public static void 딟([In] RageSpline obj0, [In] int obj1, [In] int obj2)
    {
      int length = obj0.GetVertexCount() + 1;
      if (obj0.spline.precalcNormals == null || obj0.spline.precalcNormals.Length != length)
        obj0.spline.precalcNormals = new Vector3[length];
      Vector3 vector3;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3).\u002Ector(0.0f, 0.0f, -1f);
      for (int index = obj1; index < obj2; ++index)
        obj0.spline.precalcNormals[index] = 떔.딟(obj0, (float) index / (float) (length - 1), vector3);
    }

    private static void 딟([In] RageSpline obj0, [In] bool obj1)
    {
      if (obj0.GetFill() != RageSpline.땤.딟)
        obj0.ShiftOverlappingControlPoints();
      bool flag1 = false;
      float antialiasingWidth = obj0.GetAntialiasingWidth();
      if ((double) antialiasingWidth > 0.0)
      {
        if (obj0.inverseTriangleDrawOrder)
          flag1 = true;
        else if (obj0.GetOutline() == RageSpline.떂.딟 || (double) Mathf.Abs(obj0.GetOutlineNormalOffset()) > (double) obj0.GetOutlineWidth() + (double) antialiasingWidth)
          flag1 = true;
      }
      bool flag2 = (double) obj0.GetAntialiasingWidth() > 0.0;
      bool multipleMaterials = false;
      MeshRenderer component1 = ((Component) obj0).GetComponent(typeof (MeshRenderer)) as MeshRenderer;
      if (Object.op_Inequality((Object) component1, (Object) null) && ((Renderer) component1).sharedMaterials.GetLength(0) > 1)
        multipleMaterials = true;
      RageSpline.땼[] outlineVerts = obj0.GenerateOutlineVerts(flag2, multipleMaterials);
      RageSpline.땼[] fillVerts = obj0.GenerateFillVerts(flag1, multipleMaterials);
      int length = outlineVerts.Length + fillVerts.Length;
      Vector3[] vector3Array = new Vector3[length];
      Vector2[] vector2Array1 = (Vector2[]) null;
      Vector2[] vector2Array2 = (Vector2[]) null;
      if (obj0.FixUvs)
      {
        vector2Array1 = new Vector2[length];
        vector2Array2 = new Vector2[length];
      }
      Color[] colorArray = new Color[length];
      for (int index = 0; index < fillVerts.Length; ++index)
      {
        vector3Array[index] = fillVerts[index].딟;
        colorArray[index] = fillVerts[index].딟;
        if (vector2Array1 != null)
        {
          vector2Array1[index] = fillVerts[index].딟;
          vector2Array2[index] = fillVerts[index].땄;
        }
      }
      for (int index1 = 0; index1 < outlineVerts.Length; ++index1)
      {
        int index2 = index1 + fillVerts.Length;
        vector3Array[index2] = outlineVerts[index1].딟;
        colorArray[index2] = outlineVerts[index1].딟;
        if (vector2Array1 != null)
        {
          vector2Array1[index2] = outlineVerts[index1].딟;
          vector2Array2[index2] = outlineVerts[index1].땄;
        }
      }
      MeshFilter component2 = ((Component) obj0).GetComponent(typeof (MeshFilter)) as MeshFilter;
      if (vector3Array.Length > 0)
      {
        ref Vector3 local = ref vector3Array[0];
        local = Vector3.op_Addition(local, new Vector3(0.0f, 0.0f, -1f / 1000f));
      }
      if (!Object.op_Inequality((Object) component2, (Object) null))
        return;
      Mesh mesh = component2.sharedMesh ?? new Mesh();
      if (obj1)
        mesh.Clear();
      mesh.vertices = vector3Array;
      if (obj1)
        obj0.GenerateTriangles(mesh, fillVerts, new RageSpline.땼[0], outlineVerts, flag1, false, flag2, multipleMaterials);
      if (obj0.FixUvs)
      {
        mesh.uv = vector2Array1;
        mesh.uv2 = vector2Array2;
      }
      mesh.colors = colorArray;
      mesh.RecalculateBounds();
      component2.sharedMesh = mesh;
    }

    public static Vector3 딟([In] RageSpline obj0, [In] float obj1, [In] Vector3 obj2)
    {
      if (obj0.spline.points.Length <= 0)
        return new Vector3(1f, 0.0f, 0.0f);
      obj1 = Mathf.Clamp01(obj1);
      float num1 = (float) (((double) (obj1 - 1f / 1000f) % 1.0 + 1.0) % 1.0);
      int index1 = obj0.spline.딢(num1);
      int index2 = obj0.spline.땃(num1);
      float num2 = obj0.spline.땥(num1);
      RageSplinePoint point1 = obj0.spline.points[index1];
      RageSplinePoint point2 = obj0.spline.points[index2];
      float num3 = (float) (((double) (obj1 + 1f / 1000f) % 1.0 + 1.0) % 1.0);
      int index3 = obj0.spline.딢(num3);
      int index4 = obj0.spline.땃(num3);
      float num4 = obj0.spline.땥(num3);
      RageSplinePoint point3 = obj0.spline.points[index3];
      RageSplinePoint point4 = obj0.spline.points[index4];
      Vector3 vector3_1 = Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(-3f, point1.point), Vector3.op_Multiply(9f, Vector3.op_Addition(point1.point, point1.outCtrl))), Vector3.op_Multiply(9f, Vector3.op_Addition(point2.point, point2.inCtrl))), Vector3.op_Multiply(3f, point2.point)), num2), num2), Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Multiply(6f, point1.point), Vector3.op_Multiply(12f, Vector3.op_Addition(point1.point, point1.outCtrl))), Vector3.op_Multiply(6f, Vector3.op_Addition(point2.point, point2.inCtrl))), num2)), Vector3.op_Multiply(3f, point1.point)), Vector3.op_Multiply(3f, Vector3.op_Addition(point1.point, point1.outCtrl)));
      Vector3 vector3_2 = Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Addition(Vector3.op_Multiply(-3f, point3.point), Vector3.op_Multiply(9f, Vector3.op_Addition(point3.point, point3.outCtrl))), Vector3.op_Multiply(9f, Vector3.op_Addition(point4.point, point4.inCtrl))), Vector3.op_Multiply(3f, point4.point)), num4), num4), Vector3.op_Multiply(Vector3.op_Addition(Vector3.op_Subtraction(Vector3.op_Multiply(6f, point3.point), Vector3.op_Multiply(12f, Vector3.op_Addition(point3.point, point3.outCtrl))), Vector3.op_Multiply(6f, Vector3.op_Addition(point4.point, point4.inCtrl))), num4)), Vector3.op_Multiply(3f, point3.point)), Vector3.op_Multiply(3f, Vector3.op_Addition(point3.point, point3.outCtrl)));
      Vector3 vector3_3 = Vector3.Cross(Vector3.op_Multiply(Vector3.op_Addition(((Vector3) ref vector3_1).normalized, ((Vector3) ref vector3_2).normalized), 0.5f), obj2);
      return ((Vector3) ref vector3_3).normalized;
    }
  }
}
