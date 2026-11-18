// Decompiled with JetBrains decompiler
// Type: 땥.떂
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 땥
{
  internal abstract class 떂
  {
    protected 떂 딟;
    public List<떂> 딟;
    protected 떂 땄;

    protected 떂([In] 떂 obj0, [In] 떂 obj1)
    {
      this.딟 = new List<떂>();
      this.딟 = obj0;
      this.땄 = obj1;
      obj0?.딟.Add(this);
      obj1?.딟.Add(this);
    }

    public abstract 딦 딟([In] 땋 obj0);

    public void 딟([In] 떂 obj0)
    {
      foreach (떂 떂 in obj0.딟)
      {
        if (떂.딟 == obj0)
          떂.딟 = this;
        else
          떂.땄 = this;
      }
      this.딟.AddRange((IEnumerable<떂>) obj0.딟);
    }
  }
}
