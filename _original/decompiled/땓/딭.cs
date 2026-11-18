// Decompiled with JetBrains decompiler
// Type: 땓.딭
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  internal class 딭 : IDisposable
  {
    public const int 딟 = 5;
    private Mesh 딟;
    private int 땄;
    private int 딧;
    private bool 딟;
    private GameObject 딟;

    public 딭([In] 딶.딡 obj0, [In] 땦 obj1)
    {
      this.땄 = obj1.땴().딧;
      this.딧 = obj1.떓();
      this.딟 = obj1.때();
      this.딟(obj0, obj1);
    }

    public void Dispose() => this.딟();

    public static void 딟(
      out int _param0,
      out int _param1,
      [In] Vector3[] obj2,
      [In] Color[] obj3,
      [In] ref int obj4,
      [In] int obj5,
      [In] float obj6,
      [In] float obj7,
      [In] float obj8,
      [In] float obj9,
      [In] Color obj10,
      [In] Color obj11)
    {
      int num1 = obj5 + 1;
      _param0 = obj4;
      _param1 = obj4 + num1;
      float num2 = 0.0f;
      float num3 = 1f / (float) obj5;
      int num4 = 0;
      while (num4 < num1)
      {
        float num5 = Mathf.LerpAngle(obj6, obj7, num2);
        float num6 = Mathf.Sin(num5);
        float num7 = Mathf.Cos(num5);
        obj2[_param0 + num4] = new Vector3(num6 * obj8, 0.0f, num7 * obj8);
        obj3[_param0 + num4] = obj11;
        obj2[_param1 + num4] = new Vector3(num6 * obj9, 0.0f, num7 * obj9);
        obj3[_param1 + num4] = obj10;
        ++num4;
        num2 += num3;
      }
      obj4 += num1 * 2;
    }

    public static void 딟(
      [In] Vector3[] obj0,
      [In] Color[] obj1,
      [In] ref int obj2,
      [In] int[] obj3,
      [In] ref int obj4,
      [In] ref int obj5,
      [In] ref int obj6,
      [In] int obj7,
      [In] float obj8,
      [In] float obj9,
      [In] float obj10,
      [In] float obj11,
      [In] Color obj12)
    {
      int num1 = obj7 - 2;
      int num2;
      int num3;
      딭.딟(out num2, out num3, obj0, obj1, ref obj2, obj7, obj8, obj9, obj10, obj11, obj12, obj12);
      int index1 = obj4;
      int num4 = 1;
      while (num4 < obj7 - 1)
      {
        obj3[index1] = num2 + num4;
        obj3[index1 + 1] = num2 + num4 + 1;
        obj3[index1 + 2] = obj5 + (num4 - 1) + 1;
        obj3[index1 + 3] = num2 + num4;
        obj3[index1 + 4] = obj5 + (num4 - 1) + 1;
        obj3[index1 + 5] = obj5 + (num4 - 1);
        ++num4;
        index1 += 6;
      }
      int num5 = 1;
      while (num5 < obj7 - 1)
      {
        obj3[index1] = obj6 + (num5 - 1);
        obj3[index1 + 1] = obj6 + (num5 - 1) + 1;
        obj3[index1 + 2] = num3 + num5 + 1;
        obj3[index1 + 3] = obj6 + (num5 - 1);
        obj3[index1 + 4] = num3 + num5 + 1;
        obj3[index1 + 5] = num3 + num5;
        ++num5;
        index1 += 6;
      }
      obj3[index1] = num2;
      obj3[index1 + 1] = num2 + 1;
      obj3[index1 + 2] = obj5;
      obj3[index1 + 3] = num2;
      obj3[index1 + 4] = obj5;
      obj3[index1 + 5] = num3;
      int index2 = index1 + 6;
      obj3[index2] = obj5;
      obj3[index2 + 1] = obj6;
      obj3[index2 + 2] = num3;
      obj3[index2 + 3] = obj6;
      obj3[index2 + 4] = num3 + 1;
      obj3[index2 + 5] = num3;
      int index3 = index2 + 6;
      obj3[index3] = num2 + obj7 - 1;
      obj3[index3 + 1] = num2 + obj7;
      obj3[index3 + 2] = obj5 + num1;
      obj3[index3 + 3] = num2 + obj7;
      obj3[index3 + 4] = num3 + obj7;
      obj3[index3 + 5] = obj5 + num1;
      int index4 = index3 + 6;
      obj3[index4] = obj5 + num1;
      obj3[index4 + 1] = num3 + obj7;
      obj3[index4 + 2] = obj6 + num1;
      obj3[index4 + 3] = obj6 + num1;
      obj3[index4 + 4] = num3 + obj7;
      obj3[index4 + 5] = num3 + obj7 - 1;
      int num6 = index4 + 6;
      obj5 = num2;
      obj6 = num3;
      obj4 = num6;
    }

    public static void 땄(
      [In] Vector3[] obj0,
      [In] Color[] obj1,
      [In] ref int obj2,
      [In] int[] obj3,
      [In] ref int obj4,
      out int _param5,
      out int _param6,
      [In] int obj7,
      [In] float obj8,
      [In] float obj9,
      [In] float obj10,
      [In] float obj11,
      [In] Color obj12)
    {
      딭.딟(out _param5, out _param6, obj0, obj1, ref obj2, obj7, obj8, obj9, obj10, obj11, obj12, obj12);
      int index = obj4;
      int num = 0;
      while (num < obj7)
      {
        obj3[index] = _param5 + num;
        obj3[index + 1] = _param5 + num + 1;
        obj3[index + 2] = _param6 + num + 1;
        obj3[index + 3] = _param5 + num;
        obj3[index + 4] = _param6 + num + 1;
        obj3[index + 5] = _param6 + num;
        ++num;
        index += 6;
      }
      obj4 = index;
    }

    private static void 딟(
      [In] Vector3[] obj0,
      [In] Color[] obj1,
      [In] ref int obj2,
      [In] int[] obj3,
      [In] ref int obj4,
      [In] float obj5,
      [In] float obj6,
      [In] Color obj7,
      [In] float obj8,
      [In] float obj9)
    {
      딭.딟(obj0, obj1, ref obj2, obj3, ref obj4, obj5, obj6, obj7, obj8, obj9, false, false);
    }

    private static void 딟(
      [In] Vector3[] obj0,
      [In] Color[] obj1,
      [In] ref int obj2,
      [In] int[] obj3,
      [In] ref int obj4,
      [In] float obj5,
      [In] float obj6,
      [In] Color obj7,
      [In] float obj8,
      [In] float obj9,
      [In] bool obj10,
      [In] bool obj11)
    {
      obj5 *= (float) Math.PI / 180f;
      obj6 *= (float) Math.PI / 180f;
      float num1 = !obj10 ? 1f : 0.0f;
      float num2 = !obj11 ? 1f : 0.0f;
      obj5 += (float) (Math.PI / 180.0 * (1.5 + (double) num1));
      obj6 -= (float) (Math.PI / 180.0 * (1.5 + (double) num2));
      int num3 = 5;
      obj8 += 0.03f;
      obj9 -= 0.03f;
      int num4;
      int num5;
      딭.땄(obj0, obj1, ref obj2, obj3, ref obj4, out num4, out num5, num3, obj5, obj6, obj9, obj8, obj7);
      obj5 -= (float) Math.PI / 360f;
      obj6 += (float) Math.PI / 360f;
      obj8 -= 0.01f;
      obj9 += 0.01f;
      int num6 = num3 + 2;
      딭.딟(obj0, obj1, ref obj2, obj3, ref obj4, ref num4, ref num5, num6, obj5, obj6, obj9, obj8, obj7);
      obj5 -= (float) Math.PI / 180f;
      obj6 += (float) Math.PI / 180f;
      obj8 -= 0.01f;
      obj9 += 0.01f;
      Color black1 = Color.black;
      int num7 = num6 + 2;
      딭.딟(obj0, obj1, ref obj2, obj3, ref obj4, ref num4, ref num5, num7, obj5, obj6, obj9, obj8, black1);
      obj5 -= (float) Math.PI / 180f * num1;
      obj6 += (float) Math.PI / 180f * num2;
      obj8 -= 0.01f;
      obj9 += 0.01f;
      Color black2 = Color.black;
      black2.a = (__Null) 0.0;
      int num8 = num7 + 2;
      딭.딟(obj0, obj1, ref obj2, obj3, ref obj4, ref num4, ref num5, num8, obj5, obj6, obj9, obj8, black2);
    }

    public static void 딟(
      [In] Vector3[] obj0,
      [In] Color[] obj1,
      [In] ref int obj2,
      [In] int[] obj3,
      [In] ref int obj4,
      [In] int obj5,
      [In] float obj6,
      [In] float obj7,
      [In] int obj8,
      [In] Color obj9,
      [In] float obj10,
      [In] float obj11,
      [In] ref int obj12,
      [In] ref float obj13)
    {
      Color healthBarRed = GlobalAppData.딟.GameAssets.HealthBarRed;
      Color black = Color.black;
      black.a = (__Null) 0.25;
      int num1 = Mathf.Max(obj12 - obj5, 0);
      int num2 = obj8 - num1;
      float num3 = 1f / (float) obj5;
      딭.땣[] 땣Array;
      if (obj12 == 0)
      {
        땣Array = new 딭.땣[1];
        땣Array[0].딟 = 1f;
        땣Array[0].딟 = black;
      }
      else if (obj12 < obj5)
      {
        if (num2 >= obj12)
        {
          float num4 = (float) obj12 * num3;
          땣Array = new 딭.땣[2];
          땣Array[0].딟 = num4;
          땣Array[0].딟 = healthBarRed;
          땣Array[1].딟 = 1f - num4;
          땣Array[1].딟 = black;
        }
        else if (num2 > 0)
        {
          float num5 = (float) num2 * num3;
          float num6 = (float) (obj12 - num2) * num3;
          땣Array = new 딭.땣[3];
          땣Array[0].딟 = num6;
          땣Array[0].딟 = obj9;
          땣Array[1].딟 = num5;
          땣Array[1].딟 = healthBarRed;
          땣Array[2].딟 = (float) (1.0 - ((double) num6 + (double) num5));
          땣Array[2].딟 = black;
        }
        else
        {
          float num7 = (float) obj12 * num3;
          땣Array = new 딭.땣[2];
          땣Array[0].딟 = num7;
          땣Array[0].딟 = obj9;
          땣Array[1].딟 = 1f - num7;
          땣Array[1].딟 = black;
        }
      }
      else if (num1 < obj8)
      {
        if (num2 >= obj5)
        {
          땣Array = new 딭.땣[1];
          땣Array[0].딟 = 1f;
          땣Array[0].딟 = healthBarRed;
        }
        else
        {
          float num8 = (float) num2 * num3;
          땣Array = new 딭.땣[2];
          땣Array[0].딟 = 1f - num8;
          땣Array[0].딟 = obj9;
          땣Array[1].딟 = num8;
          땣Array[1].딟 = healthBarRed;
        }
      }
      else
      {
        땣Array = new 딭.땣[1];
        땣Array[0].딟 = 1f;
        땣Array[0].딟 = obj9;
      }
      float num9 = obj13;
      for (int index = 0; index < 땣Array.Length; ++index)
      {
        float num10 = 땣Array[index].딟 * obj7;
        딭.딟(obj0, obj1, ref obj2, obj3, ref obj4, num9 - num10, num9, 땣Array[index].딟, obj10, obj11, index < 땣Array.Length - 1, index > 0);
        num9 -= num10;
      }
      obj13 -= obj7 + obj6;
      obj12 = num1;
    }

    public static Mesh 딟([In] int obj0, [In] int obj1, [In] int obj2)
    {
      int num1 = Mathf.CeilToInt((float) obj1 / 50f);
      Color color = (double) obj0 > (double) obj1 * 0.25 ? ((double) obj0 > (double) obj1 * 0.5 ? GlobalAppData.딟.GameAssets.HealthBarGreen : GlobalAppData.딟.GameAssets.HealthBarYellow) : GlobalAppData.딟.GameAssets.HealthBarOrange;
      int num2 = num1 * 2 + 1;
      int length1 = 72 * num2;
      int length2 = 354 * num2;
      Vector3[] vector3Array1 = new Vector3[length1];
      Color[] colorArray1 = new Color[length1];
      int[] numArray1 = new int[length2];
      int length3 = 0;
      int length4 = 0;
      int num3 = obj0;
      float num4 = 180f;
      for (int index = 0; index < num1; ++index)
        딭.딟(vector3Array1, colorArray1, ref length3, numArray1, ref length4, 50, 2f, 20.5f, obj2, color, 0.35f, 0.45f, ref num3, ref num4);
      Vector3[] vector3Array2 = new Vector3[length3];
      Array.Copy((Array) vector3Array1, (Array) vector3Array2, length3);
      Color[] colorArray2 = new Color[length3];
      Array.Copy((Array) colorArray1, (Array) colorArray2, length3);
      int[] numArray2 = new int[length4];
      Array.Copy((Array) numArray1, (Array) numArray2, length4);
      return new Mesh()
      {
        vertices = vector3Array2,
        triangles = numArray2,
        colors = colorArray2
      };
    }

    private void 딟()
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        Object.Destroy((Object) this.딟);
        this.딟 = (GameObject) null;
      }
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      Object.Destroy((Object) this.딟);
      this.딟 = (Mesh) null;
    }

    private void 땄()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.SetActive(true);
    }

    private void 딧()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.SetActive(false);
    }

    private void 딟([In] 딶.딡 obj0, [In] 땦 obj1)
    {
      this.딟();
      Vector3 tileCentre = obj0.땓().GetTileCentre(obj1.땴().땃, obj1.땴().딶);
      ref Vector3 local = ref tileCentre;
      local.y = (__Null) (local.y + 0.200000002980232);
      this.딟 = new GameObject();
      this.딟.transform.position = tileCentre;
      this.딟.transform.rotation = obj0.딟.GetFlatRotation(90f);
      this.딟 = 딭.딟(obj1.땴().딧, obj0.땼().땻()[obj1.땔()].딱(), obj1.떓());
      this.딟.AddComponent<MeshFilter>().sharedMesh = this.딟;
      ((Renderer) this.딟.AddComponent<MeshRenderer>()).sharedMaterial = !obj1.때() ? GlobalAppData.딟.GameAssets.VertexColourAlphaBlend : GlobalAppData.딟.GameAssets.VertexColourAlphaBlendDrawOnTop;
    }

    public void 딟([In] 딶.딡 obj0, [In] 땦 obj1, [In] Vector3 obj2, [In] Quaternion obj3, [In] float obj4)
    {
      if (this.땄 != obj1.땴().딧 || this.딧 != obj1.떓() || this.딟 != obj1.때())
      {
        this.땄 = obj1.땴().딧;
        this.딧 = obj1.떓();
        this.딟 = obj1.때();
        this.딟(obj0, obj1);
      }
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      ref Vector3 local = ref obj2;
      local.y = (__Null) (local.y + 0.200000002980232);
      this.딟.transform.position = obj2;
      this.딟.transform.rotation = obj0.딟.GetFlatRotation(90f);
      this.딟.transform.localScale = Vector3.op_Multiply(Vector3.one, (float) (0.5 * (double) obj4 * (double) obj0.딟.GetZoom() + 1.0));
    }

    public void 딢()
    {
      this.딧();
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
    }

    public void 땃()
    {
      this.땄();
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
    }

    [CompilerGenerated]
    [SpecialName]
    public bool 딶() => this.땄;

    private struct 땣
    {
      public float 딟;
      public Color 딟;
    }
  }
}
