// Decompiled with JetBrains decompiler
// Type: FontCharData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

[Serializable]
public class FontCharData
{
  public int Id;
  public float x;
  public float y;
  public float Width;
  public float Height;
  public float XOffset;
  public float YOffset;
  public float XAdvance;
  public int Page;
  public List<FontCharKerningData> Kerning;
  public Dictionary<int, FontCharKerningData> KerningHash;

  public FontCharKerningData 딟([In] char obj0)
  {
    if (this.KerningHash == null)
      return (FontCharKerningData) null;
    FontCharKerningData fontCharKerningData;
    return !this.KerningHash.TryGetValue((int) obj0, out fontCharKerningData) ? (FontCharKerningData) null : fontCharKerningData;
  }
}
