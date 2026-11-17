// Decompiled with JetBrains decompiler
// Type: 딝.땋
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딝
{
  public class 땋 : 땲
  {
    public 땋([In] Transform obj0)
      : base(obj0)
    {
      this.딟 = "Ragdolls";
    }

    public override void 딟()
    {
      base.딟();
      for (int index = 0; index < 2; ++index)
      {
        float num1 = (float) (70.0 + (double) Random.value * 20.0 + 480.0 * (double) index);
        float num2 = (float) ((20.0 + (double) Random.value * 50.0) * -1.0);
        땥.딺 딺1 = new 땥.딺(FSWorldComponent.딟());
        땺.땶 땶 = new 땺.땶(0.4166667f, 1f);
        땥.떀 떀1 = new 땥.떀(딺1, (땺.땏) 땶);
        떀1.딟(0.4f);
        떀1.땄(0.3f);
        딺1.땄(new 땥.떁(num1 / 30f, num2 / 30f));
        딺1.땄(new 땥.떁((float) ((double) Random.value * 100.0 - 50.0), (float) ((double) Random.value * 100.0 - 50.0)), 딺1.땼());
        딺1.딟(땥.땎.딧);
        땥.딺 딺2 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅1 = new 땺.떅(1f);
        떅1.딟(0.5f, 0.3333333f);
        땥.떀 떀2 = new 땥.떀(딺2, (땺.땏) 떅1);
        떀2.딟(0.4f);
        떀2.땄(0.1f);
        딺2.땄(new 땥.떁(num1 / 30f, (float) (((double) num2 - 28.0) / 30.0)));
        딺2.딟(땥.땎.딧);
        땥.딺 딺3 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅2 = new 땺.떅(1f);
        떅2.딟(0.5f, 0.3333333f);
        땥.떀 떀3 = new 땥.떀(딺3, (땺.땏) 떅2);
        떀3.딟(0.4f);
        떀3.땄(0.1f);
        딺3.땄(new 땥.떁(num1 / 30f, (float) (((double) num2 - 43.0) / 30.0)));
        딺3.딟(땥.땎.딧);
        땥.딺 딺4 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅3 = new 땺.떅(1f);
        떅3.딟(0.5f, 0.3333333f);
        땥.떀 떀4 = new 땥.떀(딺4, (땺.땏) 떅3);
        떀4.딟(0.4f);
        떀4.땄(0.1f);
        딺4.땄(new 땥.떁(num1 / 30f, (float) (((double) num2 - 58.0) / 30.0)));
        딺4.딟(땥.땎.딧);
        땥.딺 딺5 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅4 = new 땺.떅(1f);
        떅4.딟(0.6f, 0.2166667f);
        땥.떀 떀5 = new 땥.떀(딺5, (땺.땏) 떅4);
        떀5.딟(0.4f);
        떀5.땄(0.1f);
        딺5.땄(new 땥.떁((float) (((double) num1 - 30.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0)));
        딺5.딟(땥.땎.딧);
        땥.딺 딺6 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅5 = new 땺.떅(1f);
        떅5.딟(0.6f, 0.2166667f);
        땥.떀 떀6 = new 땥.떀(딺6, (땺.땏) 떅5);
        떀6.딟(0.4f);
        떀6.땄(0.1f);
        딺6.땄(new 땥.떁((float) (((double) num1 + 30.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0)));
        딺6.딟(땥.땎.딧);
        땥.딺 딺7 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅6 = new 땺.떅(1f);
        떅6.딟(0.5666667f, 0.2f);
        땥.떀 떀7 = new 땥.떀(딺7, (땺.땏) 떅6);
        떀7.딟(0.4f);
        떀7.땄(0.1f);
        딺7.땄(new 땥.떁((float) (((double) num1 - 57.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0)));
        딺7.딟(땥.땎.딧);
        땥.딺 딺8 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅7 = new 땺.떅(1f);
        떅7.딟(0.5666667f, 0.2f);
        땥.떀 떀8 = new 땥.떀(딺8, (땺.땏) 떅7);
        떀8.딟(0.4f);
        떀8.땄(0.1f);
        딺8.땄(new 땥.떁((float) (((double) num1 + 57.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0)));
        딺8.딟(땥.땎.딧);
        땥.딺 딺9 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅8 = new 땺.떅(1f);
        떅8.딟(0.25f, 0.7333333f);
        땥.떀 떀9 = new 땥.떀(딺9, (땺.땏) 떅8);
        떀9.딟(0.4f);
        떀9.땄(0.1f);
        딺9.땄(new 땥.떁((float) (((double) num1 - 8.0) / 30.0), (float) (((double) num2 - 85.0) / 30.0)));
        딺9.딟(땥.땎.딧);
        땥.딺 딺10 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅9 = new 땺.떅(1f);
        떅9.딟(0.25f, 0.7333333f);
        땥.떀 떀10 = new 땥.떀(딺10, (땺.땏) 떅9);
        떀10.딟(0.4f);
        떀10.땄(0.1f);
        딺10.땄(new 땥.떁((float) (((double) num1 + 8.0) / 30.0), (float) (((double) num2 - 85.0) / 30.0)));
        딺10.딟(땥.땎.딧);
        땥.딺 딺11 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅10 = new 땺.떅(1f);
        떅10.딟(0.25f, 0.7333333f);
        땥.떀 떀11 = new 땥.떀(딺11, (땺.땏) 떅10);
        떀11.딟(0.4f);
        떀11.땄(0.1f);
        딺11.땄(new 땥.떁((float) (((double) num1 - 8.0) / 30.0), (float) (((double) num2 - 120.0) / 30.0)));
        딺11.딟(땥.땎.딧);
        땥.딺 딺12 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅11 = new 땺.떅(1f);
        떅11.딟(0.25f, 0.7333333f);
        땥.떀 떀12 = new 땥.떀(딺12, (땺.땏) 떅11);
        떀12.딟(0.4f);
        떀12.땄(0.1f);
        딺12.땄(new 땥.떁((float) (((double) num1 + 8.0) / 30.0), (float) (((double) num2 - 120.0) / 30.0)));
        딺12.딟(땥.땎.딧);
        땥.떒 떒1 = 떂.딟(FSWorldComponent.딟(), 딺2, 딺1, 딺1.땺(new 땥.떁(num1 / 30f, (float) (((double) num2 - 15.0) / 30.0))));
        떒1.딢(-0.6981317f);
        떒1.땃(0.6981317f);
        떒1.딟(true);
        ((딝.땺) 떒1).딟(false);
        땥.떒 떒2 = 떂.딟(FSWorldComponent.딟(), 딺2, 딺5, 딺5.땺(new 땥.떁((float) (((double) num1 - 18.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0))));
        떒2.딢(-1.48353f);
        떒2.땃(2.268928f);
        떒2.딟(true);
        ((딝.땺) 떒2).딟(false);
        땥.떒 떒3 = 떂.딟(FSWorldComponent.딟(), 딺2, 딺6, 딺6.땺(new 땥.떁((float) (((double) num1 + 18.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0))));
        떒3.딢(-2.268928f);
        떒3.땃(1.48353f);
        떒3.딟(true);
        ((딝.땺) 떒3).딟(false);
        땥.떒 떒4 = 떂.딟(FSWorldComponent.딟(), 딺5, 딺7, 딺7.땺(new 땥.떁((float) (((double) num1 - 45.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0))));
        떒4.딢(-2.268928f);
        떒4.땃(0.1745329f);
        떒4.딟(true);
        ((딝.땺) 떒4).딟(false);
        땥.떒 떒5 = 떂.딟(FSWorldComponent.딟(), 딺6, 딺8, 딺8.땺(new 땥.떁((float) (((double) num1 + 45.0) / 30.0), (float) (((double) num2 - 20.0) / 30.0))));
        떒5.딢(-0.1745329f);
        떒5.땃(2.268928f);
        떒5.딟(true);
        ((딝.땺) 떒5).딟(false);
        땥.떒 떒6 = 떂.딟(FSWorldComponent.딟(), 딺2, 딺3, 딺3.땺(new 땥.떁(num1 / 30f, (float) (((double) num2 - 35.0) / 30.0))));
        떒6.딢(-0.2617994f);
        떒6.땃(0.2617994f);
        떒6.딟(true);
        ((딝.땺) 떒6).딟(false);
        땥.떒 떒7 = 떂.딟(FSWorldComponent.딟(), 딺3, 딺4, 딺4.땺(new 땥.떁(num1 / 30f, (float) (((double) num2 - 50.0) / 30.0))));
        떒7.딢(-0.2617994f);
        떒7.땃(0.2617994f);
        떒7.딟(true);
        ((딝.땺) 떒7).딟(false);
        땥.떒 떒8 = 떂.딟(FSWorldComponent.딟(), 딺4, 딺9, 딺9.땺(new 땥.떁((float) (((double) num1 - 8.0) / 30.0), (float) (((double) num2 - 72.0) / 30.0))));
        떒8.딢(-5f * (float) Math.PI / 36f);
        떒8.땃(0.7853982f);
        떒8.딟(true);
        ((딝.땺) 떒8).딟(false);
        땥.떒 떒9 = 떂.딟(FSWorldComponent.딟(), 딺4, 딺10, 딺10.땺(new 땥.떁((float) (((double) num1 + 8.0) / 30.0), (float) (((double) num2 - 72.0) / 30.0))));
        떒9.딢(-0.7853982f);
        떒9.땃(5f * (float) Math.PI / 36f);
        떒9.딟(true);
        ((딝.땺) 떒9).딟(false);
        땥.떒 떒10 = 떂.딟(FSWorldComponent.딟(), 딺9, 딺11, 딺11.땺(new 땥.떁((float) (((double) num1 - 8.0) / 30.0), (float) (((double) num2 - 105.0) / 30.0))));
        떒10.딢(-5f * (float) Math.PI / 36f);
        떒10.땃(2.007129f);
        떒10.딟(true);
        ((딝.땺) 떒10).딟(false);
        땥.떒 떒11 = 떂.딟(FSWorldComponent.딟(), 딺10, 딺12, 딺12.땺(new 땥.떁((float) (((double) num1 + 8.0) / 30.0), (float) (((double) num2 - 105.0) / 30.0))));
        떒11.딢(-2.007129f);
        떒11.땃(5f * (float) Math.PI / 36f);
        떒11.딟(true);
        ((딝.땺) 떒11).딟(false);
      }
      땥.떀 떀;
      for (int index = 1; index <= 10; ++index)
      {
        땥.딺 딺 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅 = new 땺.떅(1f);
        떅.딟((float) (10.0 * (double) index / 30.0), 0.3333333f);
        떀 = new 땥.떀(딺, (땺.땏) 떅);
        딺.땄(new 땥.떁((float) (10.0 * (double) index / 30.0), (float) ((150.0 + 20.0 * (double) index) / 30.0 * -1.0)));
      }
      for (int index = 1; index <= 10; ++index)
      {
        땥.딺 딺 = new 땥.딺(FSWorldComponent.딟());
        땺.떅 떅 = new 땺.떅(1f);
        떅.딟((float) (10.0 * (double) index / 30.0), 0.3333333f);
        떀 = new 땥.떀(딺, (땺.땏) 떅);
        딺.땄(new 땥.떁((float) ((640.0 - 10.0 * (double) index) / 30.0), (float) ((150.0 + 20.0 * (double) index) / 30.0 * -1.0)));
      }
      땥.딺 딺13 = new 땥.딺(FSWorldComponent.딟());
      땺.떅 떅12 = new 땺.떅(1f);
      떅12.딟(1f, 1.333333f);
      떀 = new 땥.떀(딺13, (땺.땏) 떅12);
      딺13.땄(new 땥.떁(10.66667f, -10.66667f));
    }
  }
}
