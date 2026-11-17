// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.FileInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using 딧;

namespace SplashDamage.Mobile.Fireteam
{
  [딷]
  [Serializable]
  public sealed class FileInfo
  {
    [떁(Name = "filename")]
    public string FileName;
    [떁(Name = "size")]
    public int Size;
    [떁(Name = "created_at")]
    public DateTime CreatedAt;
    [떁(Name = "modified_at")]
    public DateTime ModifiedAt;
  }
}
