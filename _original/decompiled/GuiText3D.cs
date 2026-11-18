// Decompiled with JetBrains decompiler
// Type: GuiText3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("Gui3D/Text")]
public class GuiText3D : GuiComponent3D
{
  private Material[] 딟;
  public FontAsset Font;
  public string Text;
  public LocalisationEntry LocText;
  public float Size = 64f;
  public float AlphaCutoff = 0.5f;
  public Color TextColor = Color.black;
  public TextAnchor Anchor;
  public float MaxWidth;
  public Color BorderColor = Color.white;
  public float BorderWidth = 0.3f;
  public bool UseBorderColor;
  public int ClipBoundsX;
  public int ClipBoundsY;
  public int ClipBoundsWidth;
  public int ClipBoundsHeight;
  public bool UseClipBounds;

  private void OnDestroy()
  {
    this.FreeSharedMesh();
    this.FreeMaterials();
  }

  private void FreeSharedMesh()
  {
    MeshFilter component = ((Component) this).gameObject.GetComponent<MeshFilter>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    this.DestroyObjectWrapper((Object) component.sharedMesh);
    component.sharedMesh = (Mesh) null;
  }

  private void FreeMaterials()
  {
    if (this.딟 == null)
      return;
    foreach (Object @object in this.딟)
      this.DestroyObjectWrapper(@object);
    this.딟 = (Material[]) null;
  }

  private void DestroyObjectWrapper(Object Obj)
  {
    if (Object.op_Equality(Obj, (Object) null))
      return;
    if (Application.isEditor)
      Object.DestroyImmediate(Obj);
    else
      Object.Destroy(Obj);
  }

  private void Awake() => this.UpdateMesh();

  public void UpdateMesh() => this.UpdateMesh((딧.떕) null);

  public void UpdateMesh(딧.떕 textCollision)
  {
    bool flag = false;
    Vector4 vector4_1 = new Vector4();
    MeshFilter component = ((Component) this).gameObject.GetComponent<MeshFilter>();
    if (Object.op_Inequality((Object) ((Component) this).gameObject.renderer, (Object) null) && Object.op_Inequality((Object) ((Component) this).gameObject.renderer.sharedMaterial, (Object) null) && ((Component) this).gameObject.renderer.sharedMaterial.HasProperty("_Bounds"))
    {
      vector4_1 = ((Component) this).gameObject.renderer.sharedMaterial.GetVector("_Bounds");
      flag = true;
    }
    this.FreeSharedMesh();
    this.FreeMaterials();
    string str = !Object.op_Inequality((Object) this.LocText, (Object) null) ? this.Text : 딧.딪.딟(this.LocText, this.get_LocTextParms());
    if (!string.IsNullOrEmpty(str))
    {
      Vector4 vector4_2 = new Vector4();
      if (flag)
        vector4_2 = vector4_1;
      else if (this.UseClipBounds)
      {
        float num1 = (float) ((double) this.ClipBoundsWidth * (1.0 / 320.0) * 0.5);
        float num2 = (float) ((double) this.ClipBoundsHeight * (1.0 / 320.0) * 0.5);
        float num3 = (float) ((double) this.ClipBoundsX * (1.0 / 320.0) - 0.75);
        float num4 = (float) (0.5 - (double) this.ClipBoundsY * (1.0 / 320.0));
        vector4_2.x = (__Null) ((double) num3 - (double) num1);
        vector4_2.y = (__Null) ((double) num4 - (double) num2);
        vector4_2.z = (__Null) ((double) num3 + (double) num1);
        vector4_2.w = (__Null) ((double) num4 + (double) num2);
      }
      if ((double) this.MaxWidth > 0.0)
        this.Size = this.ScaleText();
      this.Font.딟(str, ((Component) this).gameObject, out this.딟, true, this.Size, this.TextColor, !this.UseBorderColor ? this.TextColor : this.BorderColor, this.AlphaCutoff, this.BorderWidth, this.Anchor, this.UseClipBounds, vector4_2, textCollision);
      textCollision?.딟(((Component) this).transform.position, this.Anchor);
    }
    else
    {
      this.DestroyObjectWrapper((Object) ((Component) this).renderer);
      this.DestroyObjectWrapper((Object) component);
    }
  }

  public Vector3 GetTextWidthHeight()
  {
    MeshFilter component = ((Component) this).GetComponent<MeshFilter>();
    if (!Object.op_Inequality((Object) component, (Object) null) || !Object.op_Inequality((Object) component.sharedMesh, (Object) null))
      return Vector3.zero;
    Bounds bounds = component.sharedMesh.bounds;
    return ((Bounds) ref bounds).size;
  }

  public void SetTextPosition(Vector3 NewTextPos)
  {
    MeshFilter component = ((Component) this).GetComponent<MeshFilter>();
    if (!Object.op_Inequality((Object) component, (Object) null))
      return;
    ((Component) component).transform.localPosition = NewTextPos;
  }

  public void SetTextAlpha(float Alpha)
  {
    if (!Object.op_Inequality((Object) ((Component) this).gameObject.renderer, (Object) null))
      return;
    for (int index = 0; index < ((Component) this).gameObject.renderer.sharedMaterials.Length; ++index)
      ((Component) this).gameObject.renderer.sharedMaterial.color = new Color((float) ((Component) this).gameObject.renderer.sharedMaterial.color.r, (float) ((Component) this).gameObject.renderer.sharedMaterial.color.g, (float) ((Component) this).gameObject.renderer.sharedMaterial.color.b, Alpha);
  }

  public string ShortenText(string Text, float MaxLength)
  {
    string str = Text;
    if (this.Font.딟(str, true, this.Size).x <= (double) MaxLength)
      return Text;
    for (Vector2 vector2 = this.Font.딟(str + "...", true, this.Size); vector2.x > (double) MaxLength; vector2 = this.Font.딟(str + "...", true, this.Size))
      str = str.Substring(0, str.Length - 1);
    return str + "...";
  }

  public float ScaleText()
  {
    Vector2 vector2 = this.Font.딟(this.Text, true, this.Size);
    return vector2.x > (double) this.MaxWidth ? this.Size * (this.MaxWidth / (float) vector2.x) : this.Size;
  }

  [CompilerGenerated]
  [SpecialName]
  public object[] get_LocTextParms() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_LocTextParms(object[] value) => this.딟 = value;
}
