// Decompiled with JetBrains decompiler
// Type: 땓.딤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  internal class 딤 : IDisposable
  {
    private Mesh 딟;
    private int 딟;
    private int 땄;
    private bool 딟;
    private GameObject 딟;

    public 딤([In] 딶.딡 obj0, [In] 땦 obj1)
    {
      this.딟 = obj1.땴().딢;
      this.땄 = obj0.땼().땻()[obj1.땔()].딟((땊) null);
      this.딟 = obj1.때();
      this.딟(obj0, obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
    }

    public void Dispose() => this.딟();

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

    public static Mesh 딟([In] int obj0, [In] int obj1)
    {
      Color apBarColor = GlobalAppData.딟.GameAssets.APBarColor;
      int num1 = 2;
      int length1 = 72 * num1;
      int length2 = 354 * num1;
      Vector3[] vector3Array1 = new Vector3[length1];
      Color[] colorArray1 = new Color[length1];
      int[] numArray1 = new int[length2];
      int length3 = 0;
      int length4 = 0;
      float num2 = 180f;
      딭.딟(vector3Array1, colorArray1, ref length3, numArray1, ref length4, obj1, 0.0f, 90f, 0, apBarColor, 0.25f, 0.35f, ref obj0, ref num2);
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

    private void 딟([In] 딶.딡 obj0, [In] 땦 obj1)
    {
      this.딟();
      Vector3 tileCentre = obj0.땓().GetTileCentre(obj1.땴().땃, obj1.땴().딶);
      ref Vector3 local = ref tileCentre;
      local.y = (__Null) (local.y + 0.200000002980232);
      this.딟 = new GameObject();
      this.딟.transform.position = tileCentre;
      this.딟.transform.rotation = obj0.딟.GetFlatRotation(90f);
      this.딟 = 딤.딟(this.딟, this.땄);
      this.딟.AddComponent<MeshFilter>().sharedMesh = this.딟;
      ((Renderer) this.딟.AddComponent<MeshRenderer>()).sharedMaterial = !obj1.때() ? GlobalAppData.딟.GameAssets.VertexColourAlphaBlend : GlobalAppData.딟.GameAssets.VertexColourAlphaBlendDrawOnTop;
    }

    private void 땄()
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.딟.SetActive(false);
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
    }

    private void 딧()
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        this.딟.SetActive(true);
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
    }

    public void 딟([In] 딶.딡 obj0, [In] 땦 obj1, [In] Vector3 obj2, [In] Quaternion obj3, [In] float obj4)
    {
      int num1 = Mathf.Max(0, obj1.땴().딢);
      int num2 = obj0.땼().땻()[obj1.땔()].딟((땊) null);
      if (this.딟 != num1 || this.땄 != num2 || this.딟 != obj1.때())
      {
        this.딟 = num1;
        this.땄 = num2;
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

    public void 딢() => this.땄();

    public void 땃() => this.딧();

    [CompilerGenerated]
    [SpecialName]
    public bool 딶() => this.땄;
  }
}
