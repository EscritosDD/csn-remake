// Decompiled with JetBrains decompiler
// Type: 딶.딺
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딺 : 떒
  {
    protected 땊 딟;

    public 딺([In] 땊 obj0)
    {
      this.딟 = obj0;
      ((땏) this).딟 = true;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      Object.Destroy((Object) this.딟.땄);
    }

    public override string ToString() => string.Format("[DestroyGameObjectCinematicEvent]");
  }
}
