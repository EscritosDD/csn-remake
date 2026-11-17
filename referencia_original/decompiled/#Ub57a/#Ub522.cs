// Decompiled with JetBrains decompiler
// Type: 땺.딢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땺
{
  public class 딢
  {
    public Dictionary<string, 딧> 딟;

    public 딢() => this.딟 = new Dictionary<string, 딧>();

    public void 딟([In] string obj0, [In] int obj1)
    {
      딧 딧;
      if (!this.딟.TryGetValue(obj0, out 딧))
      {
        딧 = new 딧();
        this.딟.Add(obj0, 딧);
      }
      ++딧.딟;
    }
  }
}
