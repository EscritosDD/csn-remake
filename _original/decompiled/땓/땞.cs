// Decompiled with JetBrains decompiler
// Type: 땓.땞
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  internal static class 땞
  {
    public static void 딟([In] GameObject obj0, [In] GuiText3D obj1, [In] bool obj2, [In] float obj3)
    {
      if (!Object.op_Inequality((Object) obj0, (Object) null) || !Object.op_Inequality((Object) obj1, (Object) null))
        return;
      Vector3 localPosition = ((Component) obj1).gameObject.transform.localPosition;
      Vector3 textWidthHeight = obj1.GetTextWidthHeight();
      Vector3 vector3 = 땞.딟(obj0);
      float num = (float) -((double) (float) (textWidthHeight.x + vector3.x) * 0.5);
      if (obj2)
      {
        obj0.transform.localPosition = new Vector3(num + (float) (vector3.x * 0.5) + obj3, (float) localPosition.y, (float) localPosition.z);
        localPosition.x = (__Null) ((double) num + vector3.x);
        obj1.SetTextPosition(localPosition);
      }
      else
      {
        localPosition.x = (__Null) (double) num;
        obj1.SetTextPosition(localPosition);
        obj0.transform.localPosition = new Vector3((float) ((double) num + textWidthHeight.x + vector3.x * 0.5) + obj3, (float) localPosition.y, (float) localPosition.z);
      }
    }

    public static void 딟(
      [In] ref GameObject obj0,
      [In] ref GameObject obj1,
      [In] ref GameObject obj2,
      [In] float obj3)
    {
      MeshFilter component1 = obj0.GetComponent<MeshFilter>();
      MeshFilter component2 = obj1.GetComponent<MeshFilter>();
      MeshFilter component3 = obj2.GetComponent<MeshFilter>();
      if (!Object.op_Inequality((Object) component1, (Object) null) || !Object.op_Inequality((Object) component2, (Object) null) || !Object.op_Inequality((Object) component3, (Object) null))
        return;
      Vector3 localScale1 = obj0.transform.localScale;
      Bounds bounds1 = component1.sharedMesh.bounds;
      Vector3 size1 = ((Bounds) ref bounds1).size;
      Vector3 localScale2 = obj1.transform.localScale;
      Bounds bounds2 = component2.sharedMesh.bounds;
      Vector3 size2 = ((Bounds) ref bounds2).size;
      Vector3 localScale3 = obj2.transform.localScale;
      Bounds bounds3 = component3.sharedMesh.bounds;
      Vector3 size3 = ((Bounds) ref bounds3).size;
      localScale1.x = (__Null) ((double) obj3 / size1.x);
      obj0.transform.localScale = localScale1;
      float num1 = (float) (size1.x * localScale1.x * 0.5 + size3.x * localScale3.x * 0.5);
      obj2.transform.localPosition = new Vector3(num1, 0.0f, 0.0f);
      float num2 = (float) (size1.x * localScale1.x * 0.5 + size2.x * localScale2.x * 0.5);
      obj1.transform.localPosition = new Vector3(-num2, 0.0f, 0.0f);
    }

    public static Vector3 딟([In] GameObject obj0)
    {
      Vector3 vector3;
      // ISSUE: explicit constructor call
      ((Vector3) ref vector3).\u002Ector(0.0f, 0.0f, 0.0f);
      if (Object.op_Inequality((Object) obj0, (Object) null))
      {
        MeshFilter component = obj0.GetComponent<MeshFilter>();
        if (Object.op_Inequality((Object) component, (Object) null))
        {
          Bounds bounds = component.sharedMesh.bounds;
          vector3 = Vector3.Scale(((Bounds) ref bounds).size, ((Component) component).transform.localScale);
        }
      }
      return vector3;
    }

    public static int 딟([In] 딶.땖 obj0) => obj0 != null ? Mathf.CeilToInt((float) (obj0.딥().Count - 1) / (float) obj0.땜().Length) : 0;

    public static int 땄([In] 딶.땖 obj0)
    {
      if (obj0 == null)
        return 0;
      int num = Mathf.CeilToInt((float) obj0.딥().Count / (float) obj0.땜().Length);
      if (obj0.떔() is 딶.딖)
        num -= 2;
      return num;
    }

    public static bool 딧([In] 딶.땖 obj0)
    {
      if (obj0 == null)
        return false;
      if (obj0.떓() != 딶.딹.딟)
        return obj0.딷();
      return obj0.딟(obj0.떂(), 0) && obj0.딟(obj0.떂(), 1);
    }

    public static void 딟([In] GuiText3D obj0, [In] string obj1)
    {
      if (!Object.op_Inequality((Object) obj0, (Object) null))
        return;
      obj0.Text = obj1;
      obj0.UpdateMesh();
    }

    public static void 딟([In] GuiText3D obj0, [In] LocalisationEntry obj1)
    {
      if (!Object.op_Inequality((Object) obj0, (Object) null))
        return;
      obj0.LocText = obj1;
      obj0.UpdateMesh();
    }

    public static string 딟([In] GuiText3D obj0, [In] string obj1, [In] float obj2)
    {
      string str = obj1;
      if (obj0.Font.딟(str, true, obj0.Size).x <= (double) obj2)
        return obj1;
      for (Vector2 vector2 = obj0.Font.딟(str + "...", true, obj0.Size); vector2.x > (double) obj2; vector2 = obj0.Font.딟(str + "...", true, obj0.Size))
        str = str.Substring(0, str.Length - 1);
      return str + "...";
    }
  }
}
