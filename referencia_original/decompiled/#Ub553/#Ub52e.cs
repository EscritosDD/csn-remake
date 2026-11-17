// Decompiled with JetBrains decompiler
// Type: 땓.딮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땓
{
  public class 딮 : IComparable
  {
    public int 딟;
    public string 딟;

    public int CompareTo([In] object obj0)
    {
      딮 딮 = obj0 as 딮;
      if (딮.딟 > this.딟)
        return 1;
      return 딮.딟 < this.딟 ? -1 : 0;
    }
  }
}
