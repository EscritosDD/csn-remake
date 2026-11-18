// Decompiled with JetBrains decompiler
// Type: 딝.땽
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 딝
{
  public class 땽 : 땲
  {
    public 땽([In] Transform obj0)
      : base(obj0)
    {
      this.딟 = "Continuous Collision Detection";
    }

    public override void 딟()
    {
      base.딟();
      딺 딺1 = 딝.딝.딟(FSWorldComponent.딟(), new 땥.떁(5f, -3.333333f));
      딺1.딟(땥.땎.딧);
      딺1.딟(true);
      떎.딟(3f, 0.3f, 4f, 땥.떁.딟(), 딺1).땄(1.4f);
      떎.딟(0.3f, 3f, 4f, new 땥.떁(-1.45f, 1.683333f), 딺1).땄(1.4f);
      떎.딟(0.3f, 3f, 4f, new 땥.떁(1.45f, 1.683333f), 딺1).땄(1.4f);
      for (int index = 0; index < 5; ++index)
      {
        딺 딺2 = 딝.딝.딟(FSWorldComponent.딟(), new 땥.떁((float) (((double) Random.value * 300.0 + 250.0) / 30.0), (float) (((double) Random.value * -320.0 - 20.0) / 30.0)));
        떀 떀 = 떎.딟((float) (((double) Random.value * 10.0 + 5.0) / 30.0), 1f, 딺2);
        떀.딟(0.3f);
        떀.땄(1.1f);
        딺2.딟(땥.땎.딧);
        딺2.딟(true);
      }
    }
  }
}
