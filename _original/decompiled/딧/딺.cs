// Decompiled with JetBrains decompiler
// Type: 딧.딺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 딧
{
  public static class 딺
  {
    public static byte[] 딟([In] this Guid obj0) => 딺.딟(obj0.ToByteArray());

    private static byte[] 딟([In] byte[] obj0) => new byte[16]
    {
      obj0[3],
      obj0[2],
      obj0[1],
      obj0[0],
      obj0[5],
      obj0[4],
      obj0[7],
      obj0[6],
      obj0[8],
      obj0[9],
      obj0[10],
      obj0[11],
      obj0[12],
      obj0[13],
      obj0[14],
      obj0[15]
    };

    public static Guid 땄([In] byte[] obj0) => new Guid(딺.딟(obj0));

    public static bool 딟([In] string obj0, out Guid _param1)
    {
      try
      {
        _param1 = new Guid(obj0);
        return true;
      }
      catch (Exception ex)
      {
        _param1 = Guid.Empty;
        return false;
      }
    }
  }
}
