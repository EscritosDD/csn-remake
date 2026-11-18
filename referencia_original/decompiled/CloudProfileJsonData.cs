// Decompiled with JetBrains decompiler
// Type: CloudProfileJsonData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

[딧.딷]
[Serializable]
public sealed class CloudProfileJsonData
{
  [딧.떁(Name = "access")]
  public string AccessToken;
  [딧.떁(Name = "refresh")]
  public string RefreshToken;
  [딧.떁(Name = "name")]
  public string UserName;

  public CloudProfileJsonData([In] string obj0, [In] string obj1, [In] string obj2)
  {
    this.AccessToken = obj0;
    this.RefreshToken = obj1;
    this.UserName = obj2;
  }

  public CloudProfileJsonData()
  {
  }
}
