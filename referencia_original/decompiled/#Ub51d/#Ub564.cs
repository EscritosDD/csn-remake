// Decompiled with JetBrains decompiler
// Type: 딝.땤
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using FarseerPhysics.Collision;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 딝
{
  public class 땤 : 땲
  {
    private 땵 딟;
    private List<딺> 딟;

    public 땤([In] Transform obj0)
      : base(obj0)
    {
      base.딟 = "Buoyancy";
    }

    public override void 딟()
    {
      base.딟();
      this.딟 = new 땵(new AABB(new 땥.떁(0.0f, -12f), new 땥.떁(21.33333f, -6.666667f)), 2f, 5f, 2f, FSWorldComponent.딟().딟);
      FSWorldComponent.딟().딟((딹) this.딟);
      this.딟 = new List<딺>();
      for (int index = 0; index < 5; ++index)
      {
        딺 딺 = 딝.딝.딟(FSWorldComponent.딟(), (float) (((double) Random.value * 5.0 + 10.0) / 30.0), (float) (((double) Random.value * 5.0 + 10.0) / 30.0), 1f, new 땥.떁((float) (((double) Random.value * 400.0 + 120.0) / 30.0), (float) (((double) Random.value * -150.0 - 50.0) / 30.0)));
        딺.땃(Random.value * 3.141593f);
        딺.딟(땥.땎.딧);
        this.딟.Add(딺);
      }
      for (int index = 0; index < 5; ++index)
      {
        딺 딺 = 딝.딝.딟(FSWorldComponent.딟(), (float) (((double) Random.value * 5.0 + 10.0) / 30.0), 0.5f, new 땥.떁((float) (((double) Random.value * 400.0 + 120.0) / 30.0), (float) (((double) Random.value * -150.0 - 50.0) / 30.0)));
        딺.땃(Random.value * 3.141593f);
        딺.딟(땥.땎.딧);
        this.딟.Add(딺);
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
        딺 딺 = 딝.딝.딟(FSWorldComponent.딟(), new List<땥.땨>()
        {
          땨
        }, 1f, new 땥.떁((float) (((double) Random.value * 400.0 + 120.0) / 30.0), (float) (((double) Random.value * -150.0 - 50.0) / 30.0)));
        딺.땃(Random.value * 3.141593f);
        딺.딟(땥.땎.딧);
        this.딟.Add(딺);
      }
      딺 딺1 = new 딺(FSWorldComponent.딟());
      딺1.땄(new 땥.떁(1.666667f, -10f));
      딺1.딟(땥.땎.딧);
      떎.딟(2.666667f, 0.6666667f, 3f, 땥.떁.딟(), 딺1);
      this.딟.Add(딺1);
      딺 딺2 = new 딺(FSWorldComponent.딟());
      딺2.땄(new 땥.떁(10f, -10f));
      딺2.딟(땥.땎.딧);
      떎.딟(2f, 6.283185f, 8, 0.2333333f, new 땥.떁(1f, 0.0f), 0.0f, 딺2);
      떎.딟(2f, 6.283185f, 8, 0.2333333f, new 땥.떁(-1f, 0.0f), 0.0f, 딺2);
      떎.딟(2f, 0.1333333f, 2f, 땥.떁.딟(), 딺2);
      떎.딟(2f, 6.283185f, 8, 0.2333333f, new 땥.떁(0.0f, 1f), 0.0f, 딺2);
      떎.딟(2f, 6.283185f, 8, 0.2333333f, new 땥.떁(0.0f, -1f), 0.0f, 딺2);
      떎.딟(0.1333333f, 2f, 2f, 땥.떁.딟(), 딺2);
    }
  }
}
