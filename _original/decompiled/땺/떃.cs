// Decompiled with JetBrains decompiler
// Type: 땺.떃
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 떃 : IComparer<땮>
  {
    public int Compare([In] 땮 obj0, [In] 땮 obj1)
    {
      if (obj0.땄 < obj1.땄)
        return -1;
      if (obj0.땄 > obj1.땄)
        return 1;
      if (obj0.딟 < obj1.딟)
        return -1;
      return obj0.딟 > obj1.딟 ? 1 : 0;
    }
  }
}
