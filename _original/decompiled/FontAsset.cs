// Decompiled with JetBrains decompiler
// Type: FontAsset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FontAsset : ScriptableObject
{
  private Dictionary<int, FontCharData> 딟;
  private Dictionary<int, FontPageData> 딟;
  public float FontSize;
  public float LineHeight;
  public Vector2 PageSize;
  public FontCharData[] Chars;
  public FontPageData[] Pages;
  public Shader TextShader;
  public Shader TextShaderClipped;

  private void OnEnable()
  {
    this.딟();
    this.땄();
    this.딧();
  }

  public void 딟()
  {
    this.딟 = new Dictionary<int, FontPageData>();
    if (this.Pages == null)
      return;
    for (int index = 0; index < this.Pages.Length; ++index)
      this.딟.Add(this.Pages[index].Id, this.Pages[index]);
  }

  public void 땄()
  {
    this.딟 = new Dictionary<int, FontCharData>();
    if (this.Chars == null)
      return;
    for (int index = 0; index < this.Chars.Length; ++index)
    {
      if (this.딟.TryGetValue(this.Chars[index].Id, out FontCharData _))
        Debug.LogError((object) (this.Chars[index].Id.ToString() + " exists in font data multiple times (" + (object) index + ")"));
      else
        this.딟.Add(this.Chars[index].Id, this.Chars[index]);
    }
  }

  public void 딧()
  {
    if (this.Chars == null)
      return;
    for (int index1 = 0; index1 < this.Chars.Length; ++index1)
    {
      if (this.Chars[index1].Kerning != null)
      {
        this.Chars[index1].KerningHash = new Dictionary<int, FontCharKerningData>();
        for (int index2 = 0; index2 < this.Chars[index1].Kerning.Count; ++index2)
          this.Chars[index1].KerningHash.Add(this.Chars[index1].Kerning[index2].SecondId, this.Chars[index1].Kerning[index2]);
      }
    }
  }

  public FontCharData 딟([In] char obj0)
  {
    FontCharData fontCharData;
    return !this.딟.TryGetValue((int) obj0, out fontCharData) ? (FontCharData) null : fontCharData;
  }

  public FontPageData 딟([In] int obj0) => this.Pages[obj0];

  public Vector2 딟([In] string obj0, [In] bool obj1, [In] float obj2)
  {
    float num1 = obj2 / this.FontSize;
    FontCharData[] fontCharDataArray = new FontCharData[obj0.Length];
    for (int index = 0; index < obj0.Length; ++index)
    {
      fontCharDataArray[index] = this.딟(obj0[index]);
      if (fontCharDataArray[index] == null)
        fontCharDataArray[index] = this.딟('_');
    }
    float num2 = 0.0f;
    for (int index = 0; index < obj0.Length; ++index)
    {
      FontCharData fontCharData = fontCharDataArray[index];
      float num3 = 0.0f;
      if (index > 0 && obj1)
      {
        FontCharKerningData fontCharKerningData = fontCharDataArray[index - 1].딟(obj0[index]);
        if (fontCharKerningData != null)
          num3 = fontCharKerningData.Amount;
      }
      num2 += (fontCharData.XAdvance + num3) * num1;
    }
    return new Vector2(num2, this.LineHeight * num1);
  }

  public void 딟(
    [In] string obj0,
    [In] GameObject obj1,
    out Material[] _param3,
    [In] bool obj3,
    [In] float obj4,
    [In] Color obj5,
    [In] Color obj6,
    [In] float obj7,
    [In] float obj8,
    [In] TextAnchor obj9,
    [In] bool obj10,
    [In] Vector4 obj11,
    [In] 딧.떕 obj12)
  {
    float num1 = obj4 / this.FontSize;
    Vector3[] vector3Array = new Vector3[obj0.Length * 4];
    Vector2[] vector2Array = new Vector2[obj0.Length * 4];
    FontCharData[] fontCharDataArray = new FontCharData[obj0.Length];
    FontAsset.딜[] 딜Array = new FontAsset.딜[obj0.Length];
    List<FontAsset.딜> 딜List = new List<FontAsset.딜>();
    for (int index1 = 0; index1 < obj0.Length; ++index1)
    {
      fontCharDataArray[index1] = this.딟(obj0[index1]);
      if (fontCharDataArray[index1] == null)
        fontCharDataArray[index1] = this.딟('_');
      int index2;
      for (index2 = 0; index2 < 딜List.Count; ++index2)
      {
        if (딜List[index2].딟 == this.딟(fontCharDataArray[index1].Page))
        {
          ++딜List[index2].딟;
          딜Array[index1] = 딜List[index2];
          break;
        }
      }
      if (index2 == 딜List.Count)
      {
        FontAsset.딜 딜 = new FontAsset.딜();
        딜.딟 = 1;
        딜.딟 = this.딟(fontCharDataArray[index1].Page);
        딜List.Add(딜);
        딜Array[index1] = 딜;
      }
    }
    for (int index = 0; index < 딜List.Count; ++index)
      딜List[index].딟 = new int[딜List[index].딟 * 6];
    Vector2 vector2;
    // ISSUE: explicit constructor call
    ((Vector2) ref vector2).\u002Ector((float) (1.0 / this.PageSize.x), (float) (1.0 / this.PageSize.y));
    float num2 = 0.0f;
    int index3 = 0;
    for (int index4 = 0; index4 < obj0.Length; ++index4)
    {
      FontCharData fontCharData = fontCharDataArray[index4];
      FontAsset.딜 딜 = 딜Array[index4];
      딜.딟[딜.땄] = index3;
      딜.딟[딜.땄 + 1] = index3 + 1;
      딜.딟[딜.땄 + 2] = index3 + 2;
      딜.딟[딜.땄 + 3] = index3 + 2;
      딜.딟[딜.땄 + 4] = index3 + 3;
      딜.딟[딜.땄 + 5] = index3;
      딜.땄 += 6;
      vector2Array[index3].x = (__Null) (double) (vector2Array[index3 + 3].x = (__Null) (fontCharData.x * (float) vector2.x));
      vector2Array[index3 + 1].x = (__Null) (double) (vector2Array[index3 + 2].x = (__Null) (float) (((double) fontCharData.x + (double) fontCharData.Width) * vector2.x));
      vector2Array[index3].y = (__Null) (double) (vector2Array[index3 + 1].y = (__Null) (float) (1.0 - (double) fontCharData.y * vector2.y));
      vector2Array[index3 + 2].y = (__Null) (double) (vector2Array[index3 + 3].y = (__Null) (float) (1.0 - ((double) fontCharData.y + (double) fontCharData.Height) * vector2.y));
      float num3 = 0.0f;
      if (index4 > 0 && obj3)
      {
        FontCharKerningData fontCharKerningData = fontCharDataArray[index4 - 1].딟(obj0[index4]);
        if (fontCharKerningData != null)
          num3 = fontCharKerningData.Amount;
      }
      float num4 = num2 + (fontCharData.XOffset + num3) * num1;
      float num5 = -fontCharData.YOffset * num1;
      float num6 = fontCharData.Width * num1;
      float num7 = fontCharData.Height * num1;
      vector3Array[index3] = new Vector3(num4, 0.0f, num5);
      vector3Array[index3 + 1] = new Vector3(num4 + num6, 0.0f, num5);
      vector3Array[index3 + 2] = new Vector3(num4 + num6, 0.0f, num5 - num7);
      vector3Array[index3 + 3] = new Vector3(num4, 0.0f, num5 - num7);
      index3 += 4;
      if (obj12 != null)
      {
        Bounds bounds;
        // ISSUE: explicit constructor call
        ((Bounds) ref bounds).\u002Ector(new Vector3(num4 + num6 * 0.5f, 0.0f, num7 * 0.5f), new Vector3(num6, 0.0f, num7));
        obj12.딟.Add(bounds);
      }
      num2 += (fontCharData.XAdvance + num3) * num1;
    }
    float num8 = this.LineHeight * num1;
    float num9 = -num2;
    switch ((int) obj9)
    {
      case 0:
      case 1:
      case 2:
        num8 *= 1f;
        break;
      case 3:
      case 4:
      case 5:
        num8 *= 0.5f;
        break;
      case 6:
      case 7:
      case 8:
        num8 *= 0.0f;
        break;
    }
    switch ((int) obj9)
    {
      case 0:
      case 3:
      case 6:
        num9 *= 1f;
        break;
      case 1:
      case 4:
      case 7:
        num9 *= 0.5f;
        break;
      case 2:
      case 5:
      case 8:
        num9 *= 0.0f;
        break;
    }
    Vector3 vector3;
    // ISSUE: explicit constructor call
    ((Vector3) ref vector3).\u002Ector(num9, 0.0f, num8);
    for (int index5 = 0; index5 < vector3Array.Length; ++index5)
    {
      ref Vector3 local = ref vector3Array[index5];
      local = Vector3.op_Addition(local, vector3);
    }
    MeshFilter meshFilter = obj1.GetComponent<MeshFilter>();
    if (Object.op_Equality((Object) meshFilter, (Object) null))
      meshFilter = obj1.AddComponent<MeshFilter>();
    MeshRenderer meshRenderer = obj1.GetComponent<MeshRenderer>();
    if (Object.op_Equality((Object) meshRenderer, (Object) null))
      meshRenderer = obj1.AddComponent<MeshRenderer>();
    Mesh mesh = new Mesh();
    mesh.vertices = vector3Array;
    mesh.uv = vector2Array;
    mesh.subMeshCount = 딜List.Count;
    Material[] materialArray = new Material[딜List.Count];
    for (int index6 = 0; index6 < 딜List.Count; ++index6)
    {
      mesh.SetTriangles(딜List[index6].딟, index6);
      if (obj10)
      {
        materialArray[index6] = new Material(this.TextShaderClipped);
        materialArray[index6].SetVector("_Bounds", obj11);
        materialArray[index6].mainTexture = (Texture) 딜List[index6].딟.Texture;
        materialArray[index6].color = obj5;
        materialArray[index6].SetColor("_BorderColor", obj6);
        materialArray[index6].SetVector("_Settings", new Vector4(obj7, obj8));
      }
      else
      {
        materialArray[index6] = new Material(this.TextShader);
        materialArray[index6].mainTexture = (Texture) 딜List[index6].딟.Texture;
        materialArray[index6].color = obj5;
        materialArray[index6].SetColor("_BorderColor", obj6);
        materialArray[index6].SetVector("_Settings", new Vector4(obj7, obj8));
      }
    }
    ((Object) mesh).name = "Text";
    mesh.RecalculateNormals();
    mesh.RecalculateBounds();
    ((Renderer) meshRenderer).materials = materialArray;
    meshFilter.sharedMesh = mesh;
    _param3 = materialArray;
    if (obj12 == null)
      return;
    obj12.딟 = mesh.bounds;
  }

  private class 딜
  {
    public FontPageData 딟;
    public int 딟;
    public int 땄;
    public int[] 딟;
  }
}
