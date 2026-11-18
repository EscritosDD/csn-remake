// Decompiled with JetBrains decompiler
// Type: GuiMultiLineText3D
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

[AddComponentMenu("Gui3D/Multi Line Text")]
public class GuiMultiLineText3D : GuiComponent3D
{
  private GuiText3D[] 딟;
  public FontAsset Font;
  public string Text;
  public LocalisationEntry LocText;
  public float Size = 64f;
  public float AlphaCutoff = 0.5f;
  public Color TextColor = Color.black;
  public TextAnchor Anchor;
  public Color BorderColor = Color.white;
  public float BorderWidth = 0.3f;
  public bool UseBorderColor;
  public bool UseClipBounds;
  public float MaxWidth;

  private void Awake() => this.UpdateMesh();

  public void DestroyChildren()
  {
    if (this.딟 == null)
      return;
    foreach (GuiText3D guiText3D in this.딟)
    {
      GlobalAppData.땄(((Component) guiText3D).gameObject);
      Object.Destroy((Object) ((Component) guiText3D).gameObject);
    }
    this.딟 = (GuiText3D[]) null;
  }

  public static float 딟([In] string obj0, [In] FontAsset obj1, [In] float obj2, [In] float obj3)
  {
    float num = 0.0f;
    if (!string.IsNullOrEmpty(obj0))
    {
      string str1 = obj0;
      string[] separator = new string[1]{ "\n" };
      foreach (string str2 in str1.Split(separator, StringSplitOptions.None))
      {
        char[] chArray = new char[1]{ ' ' };
        string[] strArray = str2.Split(chArray);
        Vector2 vector2_1 = Vector2.op_Implicit(Vector3.zero);
        StringBuilder stringBuilder = new StringBuilder(strArray[0]);
        for (int index = 1; index < strArray.Length; ++index)
        {
          Vector2 vector2_2 = obj1.딟(stringBuilder.ToString() + " " + strArray[index], true, obj2);
          if (stringBuilder.Length > 0 && vector2_2.x > (double) obj3)
          {
            num += (float) vector2_1.y;
            stringBuilder.Length = 0;
            stringBuilder.Append(strArray[index]);
          }
          else
          {
            stringBuilder.Append(' ');
            stringBuilder.Append(strArray[index]);
          }
          vector2_1 = vector2_2;
        }
        num += (float) vector2_1.y;
      }
    }
    return num;
  }

  public float MeasureHeight(string Text) => GuiMultiLineText3D.딟(Text, this.Font, this.Size, this.MaxWidth);

  public float MeasureHeight() => GuiMultiLineText3D.딟(this.get_FinalText(), this.Font, this.Size, this.MaxWidth);

  public void UpdateMesh()
  {
    this.DestroyChildren();
    List<string> stringList = new List<string>();
    if (!string.IsNullOrEmpty(this.get_FinalText()))
    {
      string str1 = this.get_FinalText();
      string[] separator = new string[1]{ "\n" };
      foreach (string str2 in str1.Split(separator, StringSplitOptions.None))
      {
        char[] chArray = new char[1]{ ' ' };
        string[] strArray = str2.Split(chArray);
        StringBuilder stringBuilder = new StringBuilder(strArray[0]);
        for (int index = 1; index < strArray.Length; ++index)
        {
          Vector2 vector2 = this.Font.딟(stringBuilder.ToString() + " " + strArray[index], true, this.Size);
          if (stringBuilder.Length > 0 && vector2.x > (double) this.MaxWidth)
          {
            stringList.Add(stringBuilder.ToString());
            stringBuilder.Length = 0;
            stringBuilder.Append(strArray[index]);
          }
          else
          {
            stringBuilder.Append(' ');
            stringBuilder.Append(strArray[index]);
          }
        }
        stringList.Add(stringBuilder.ToString());
      }
    }
    float num = 0.0f;
    this.딟 = new GuiText3D[stringList.Count];
    for (int index = 0; index < stringList.Count; ++index)
    {
      GuiText3D guiText3D = new GameObject().AddComponent<GuiText3D>();
      this.딟[index] = guiText3D;
      ((Component) guiText3D).transform.parent = ((Component) this).transform;
      ((Component) guiText3D).transform.localPosition = new Vector3(0.0f, 0.0f, -num);
      ((Component) guiText3D).transform.localRotation = Quaternion.identity;
      ((Component) guiText3D).transform.localScale = Vector3.one;
      guiText3D.Font = this.Font;
      guiText3D.Text = stringList[index];
      guiText3D.Size = this.Size;
      guiText3D.AlphaCutoff = this.AlphaCutoff;
      guiText3D.TextColor = this.TextColor;
      guiText3D.Anchor = this.Anchor;
      guiText3D.BorderColor = this.BorderColor;
      guiText3D.BorderWidth = this.BorderWidth;
      guiText3D.UseBorderColor = this.UseBorderColor;
      guiText3D.UseClipBounds = this.UseClipBounds;
      guiText3D.UpdateMesh();
      Vector2 vector2 = this.Font.딟(stringList[index], true, this.Size);
      num += (float) vector2.y;
    }
  }

  [SpecialName]
  public string get_FinalText() => Object.op_Inequality((Object) this.LocText, (Object) null) ? 딧.딪.딟(this.LocText, this.get_LocTextParms()) : this.Text;

  [CompilerGenerated]
  [SpecialName]
  public object[] get_LocTextParms() => this.딟;

  [CompilerGenerated]
  [SpecialName]
  public void set_LocTextParms(object[] value) => this.딟 = value;
}
