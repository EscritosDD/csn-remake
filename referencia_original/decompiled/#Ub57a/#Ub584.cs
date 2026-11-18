// Decompiled with JetBrains decompiler
// Type: 땺.떄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace 땺
{
  internal struct 떄 : IComparable<떄>
  {
    public int 딟;
    public int 땄;

    public int CompareTo([In] 떄 obj0)
    {
      if (this.딟 < obj0.딟)
        return -1;
      if (this.딟 == obj0.딟)
      {
        if (this.땄 < obj0.땄)
          return -1;
        if (this.땄 == obj0.땄)
          return 0;
      }
      return 1;
    }
  }
}
