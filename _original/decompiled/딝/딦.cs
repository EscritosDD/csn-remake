// Decompiled with JetBrains decompiler
// Type: 딝.딦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 딝
{
  public class 딦 : 땲
  {
    public 딦([In] Transform obj0)
      : base(obj0)
    {
      this.딟 = "Bridge";
    }

    public override void 딟()
    {
      base.딟();
      int num = 10;
      딺 딺1 = 딝.딝.딟(FSWorldComponent.딟(), 0.1f, 20f, new 땥.떁(3.333333f, -8.333333f));
      for (int index = 0; index < num; ++index)
      {
        딺 딺2 = 딝.딝.딟(FSWorldComponent.딟(), 1.6f, 0.3333333f, 20f, new 땥.떁((float) ((122.0 + 44.0 * (double) index) / 30.0), -8.333333f));
        딺2.딟(땥.땎.딧);
        떒 떒 = 떂.딟(FSWorldComponent.딟(), 딺1, 딺2, new 땥.떁(-0.7333333f, 0.0f));
        떒.딢(-0.2617994f);
        떒.땃(0.2617994f);
        떒.딟(true);
        딺1 = 딺2;
      }
      딺 딺3 = 딝.딝.딟(FSWorldComponent.딟(), 0.1f, 20f, new 땥.떁((float) ((100.0 + 44.0 * (double) num) / 30.0), -8.333333f));
      떒 떒1 = 떂.딟(FSWorldComponent.딟(), 딺1, 딺3, new 땥.떁(0.0f, 0.0f));
      떒1.딢(-0.2617994f);
      떒1.땃(0.2617994f);
      떒1.딟(true);
      for (int index = 0; index < 5; ++index)
      {
        딺 딺4 = 딝.딝.딟(FSWorldComponent.딟(), (float) (((double) Random.value * 10.0 + 20.0) / 30.0), (float) (((double) Random.value * 10.0 + 20.0) / 30.0), 1f, new 땥.떁((float) (((double) Random.value * 400.0 + 120.0) / 30.0), (float) (((double) Random.value * -150.0 - 50.0) / 30.0)));
        딺4.땃(Random.value * 3.141593f);
        딺4.딟(땥.땎.딧);
      }
      for (int index = 0; index < 5; ++index)
      {
        딺 딺5 = 딝.딝.딟(FSWorldComponent.딟(), (float) (((double) Random.value * 20.0 + 10.0) / 30.0), 1f, new 땥.떁((float) (((double) Random.value * 400.0 + 120.0) / 30.0), (float) (((double) Random.value * -150.0 - 50.0) / 30.0)));
        딺5.땃(Random.value * 3.141593f);
        딺5.딟(땥.땎.딧);
      }
      for (int index = 0; index < 15; ++index)
      {
        땥.땨 땨 = new 땥.땨();
        if ((double) Random.value > 0.660000026226044)
        {
          땨.Add(new 땥.떁((float) ((10.0 + (double) Random.value * 10.0) / 30.0), (float) ((-10.0 - (double) Random.value * 10.0) / 30.0)));
          땨.Add(new 땥.떁((float) ((5.0 + (double) Random.value * 10.0) / 30.0), (float) ((10.0 + (double) Random.value * 10.0) / 30.0)));
          땨.Add(new 땥.떁((float) ((-5.0 - (double) Random.value * 10.0) / 30.0), (float) ((10.0 + (double) Random.value * 10.0) / 30.0)));
          땨.Add(new 땥.떁((float) ((-10.0 - (double) Random.value * 10.0) / 30.0), (float) ((-10.0 - (double) Random.value * 10.0) / 30.0)));
        }
        else if ((double) Random.value > 0.5)
        {
          땥.떁 떁1 = new 땥.떁(0.0f, (float) ((-10.0 - (double) Random.value * 10.0) / 30.0));
          땥.떁 떁2 = new 땥.떁((float) ((-5.0 - (double) Random.value * 10.0) / 30.0), (float) ((10.0 + (double) Random.value * 10.0) / 30.0));
          땥.떁 떁3 = new 땥.떁((float) ((5.0 + (double) Random.value * 10.0) / 30.0), (float) ((10.0 + (double) Random.value * 10.0) / 30.0));
          땥.떁 떁4 = new 땥.떁(떁1.딟 + 떁2.딟, 떁1.땄 + 떁2.땄);
          떁4 *= (float) ((double) Random.value / 2.0 + 0.800000011920929);
          땥.떁 떁5 = new 땥.떁(떁3.딟 + 떁1.딟, 떁3.땄 + 떁1.땄);
          떁5 *= (float) ((double) Random.value / 2.0 + 0.800000011920929);
          땨.Add(떁5);
          땨.Add(떁3);
          땨.Add(떁2);
          땨.Add(떁4);
          땨.Add(떁1);
        }
        else
        {
          땨.Add(new 땥.떁((float) ((5.0 + (double) Random.value * 10.0) / 30.0), (float) ((10.0 + (double) Random.value * 10.0) / 30.0)));
          땨.Add(new 땥.떁((float) ((-5.0 - (double) Random.value * 10.0) / 30.0), (float) ((10.0 + (double) Random.value * 10.0) / 30.0)));
          땨.Add(new 땥.떁(0.0f, (float) ((-10.0 - (double) Random.value * 10.0) / 30.0)));
        }
        딺 딺6 = 딝.딝.딟(FSWorldComponent.딟(), new List<땥.땨>()
        {
          땨
        }, 1f, new 땥.떁((float) (((double) Random.value * 400.0 + 120.0) / 30.0), (float) (((double) Random.value * -150.0 - 50.0) / 30.0)));
        딺6.땃(Random.value * 3.141593f);
        딺6.딟(땥.땎.딧);
      }
    }
  }
}
