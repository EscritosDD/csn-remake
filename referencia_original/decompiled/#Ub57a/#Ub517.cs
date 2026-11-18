// Decompiled with JetBrains decompiler
// Type: 땺.딗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using UnityEngine;

namespace 땺
{
  internal static class 딗
  {
    public static void 딟([In] this List<RageGroupElement> obj0, [In] int obj1)
    {
      if (obj0 == null)
        return;
      foreach (RageGroupElement rageGroupElement in obj0)
      {
        딥 spline = (딥) rageGroupElement.Spline;
        if (spline.땩() && spline.땲() != obj1)
          spline.딟(obj1);
      }
    }

    public static void 딟([In] this List<RageGroupElement> obj0, [In] float obj1, [In] int obj2)
    {
      if (obj0 == null)
        return;
      foreach (RageGroupElement rageGroupElement in obj0)
        rageGroupElement.Spline.딟(Mathf.RoundToInt(Mathf.Clamp((float) rageGroupElement.DefaultDensity * obj1, 1f, (float) obj2)));
    }

    public static void 딟([In] this List<RageGroupElement> obj0, [In] float obj1, [In] bool obj2, [In] bool obj3)
    {
      if (obj0 == null)
        return;
      foreach (RageGroupElement rageGroupElement in obj0)
      {
        딥 spline = (딥) rageGroupElement.Spline;
        if (spline != null)
        {
          if (obj2)
            spline.딝().땄(rageGroupElement.DefaultAa * obj1);
          else
            spline.딝().땄(obj1);
          if (obj3)
            spline.땟().RefreshMeshInEditor(true, true, true);
        }
      }
    }

    public static void 땄([In] this List<RageGroupElement> obj0, [In] float obj1, [In] bool obj2, [In] bool obj3)
    {
      if (obj0 == null)
        return;
      foreach (RageGroupElement rageGroupElement in obj0)
      {
        딥 spline = (딥) rageGroupElement.Spline;
        if (spline != null)
        {
          Color color;
          if (obj2)
          {
            color = spline.땄();
            spline.딟(new Color((float) color.r, (float) color.g, (float) color.b, (float) rageGroupElement.DefaultFillColor1.a * obj1));
            color = spline.땟().GetFillColor2();
            spline.땟().SetFillColor2(new Color((float) color.r, (float) color.g, (float) color.b, (float) rageGroupElement.DefaultFillColor2.a * obj1));
            color = spline.땓();
            spline.땄(new Color((float) color.r, (float) color.g, (float) color.b, (float) rageGroupElement.DefaultOutlineColor.a * obj1));
          }
          else
          {
            color = spline.땄();
            spline.딟(new Color((float) color.r, (float) color.g, (float) color.b, obj1));
            color = spline.땟().GetFillColor2();
            spline.땟().SetFillColor2(new Color((float) color.r, (float) color.g, (float) color.b, obj1));
            color = spline.땓();
            spline.땄(new Color((float) color.r, (float) color.g, (float) color.b, obj1));
          }
          if (obj3)
            spline.땟().RefreshMeshInEditor(true, true, true);
        }
      }
    }

    public static void 딟([In] this GameObject obj0)
    {
      if (Object.op_Equality((Object) obj0, (Object) null))
        return;
      foreach (Transform componentsInChild in obj0.GetComponentsInChildren<Transform>())
      {
        if (((Object) componentsInChild).name.Contains("_"))
          ((Object) componentsInChild).name = ((Object) componentsInChild).name.Split('_')[0];
      }
    }

    public static void 딟([In] this Object obj0)
    {
      GameObject gameObject = obj0 as GameObject;
      if (Object.op_Equality((Object) gameObject, (Object) null))
        return;
      MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
      if (componentsInChildren != null)
      {
        foreach (MeshFilter meshFilter in componentsInChildren)
          Object.DestroyImmediate((Object) meshFilter.sharedMesh);
      }
      if (Application.isEditor)
        Object.DestroyImmediate(obj0);
      else
        Object.Destroy(obj0);
    }

    public static bool 딟([In] this 땓 obj0, [In] int obj1, [In] int obj2, [In] float obj3, [In] bool obj4)
    {
      if (obj2 == 0)
        obj1 = obj0.GetPointCount() - 1;
      if ((double) Vector3.Distance(obj0.GetPositionWorldSpace(obj1), obj0.GetPositionWorldSpace(obj2)) > (double) obj3)
        return false;
      if (obj4)
        Debug.Log((object) ("overlap path pos = " + (object) obj0.GetPositionWorldSpace(obj1)));
      obj0.SetNatural(obj2, false);
      obj0.SetInControlPositionWorldSpace(obj2, obj0.GetInControlPositionWorldSpace(obj1));
      obj0.RemovePoint(obj1);
      return true;
    }

    public static bool 딟([In] this 땓 obj0, [In] bool obj1)
    {
      if (obj0.GetPointCount() <= 2)
        return false;
      int num = obj0.GetPointCount() - 1;
      Vector3 positionWorldSpace = obj0.GetPositionWorldSpace(num);
      if ((double) Vector3.Distance(obj0.GetPositionWorldSpace(0), positionWorldSpace) >= 9.99999974737875E-05)
        return false;
      if (obj1)
        Debug.Log((object) "\t Removing endpoint overlap ");
      obj0.SetInControlPositionWorldSpace(0, obj0.GetInControlPositionWorldSpace(num));
      obj0.RemovePoint(num);
      return true;
    }

    public static Vector2 딟()
    {
      if (!Application.isEditor)
        return new Vector2((float) Screen.width, (float) Screen.height);
      Type type = Type.GetType("UnityEditor.GameView,UnityEditor");
      return (object) type == null ? Vector2.zero : (Vector2) type.GetMethod("GetSizeOfMainGameView", BindingFlags.Static | BindingFlags.NonPublic).Invoke((object) null, (object[]) null);
    }

    public static void 딟([In] this IEnumerable<GameObject> obj0, [In] bool obj1)
    {
      foreach (GameObject gameObject in obj0)
        gameObject.SetActiveRecursively(obj1);
    }

    public static string 딟([In] this Transform obj0) => Object.op_Inequality((Object) obj0.parent, (Object) null) ? obj0.parent.딟() + "/" + ((Object) ((Component) obj0).gameObject).name : ((Object) ((Component) obj0).gameObject).name;

    public static string 딟<딟>([In] this 딟 obj0)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(obj0.GetType());
      StringWriter stringWriter = new StringWriter();
      xmlSerializer.Serialize((TextWriter) stringWriter, (object) obj0);
      return stringWriter.ToString();
    }

    public static 딟 딟<딟>([In] this string obj0) => (딟) new XmlSerializer(typeof (딟)).Deserialize((TextReader) new StringReader(obj0));

    public static bool 딟([In] Vector2[] obj0, [In] Vector2 obj1)
    {
      int index1 = obj0.Length - 1;
      bool flag = false;
      for (int index2 = 0; index2 < obj0.Length; ++index2)
      {
        if ((obj0[index2].y < obj1.y && obj0[index1].y >= obj1.y || obj0[index1].y < obj1.y && obj0[index2].y >= obj1.y) && obj0[index2].x + (obj1.y - obj0[index2].y) / (obj0[index1].y - obj0[index2].y) * (obj0[index1].x - obj0[index2].x) < obj1.x)
          flag = !flag;
        index1 = index2;
      }
      return flag;
    }
  }
}
