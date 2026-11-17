// Decompiled with JetBrains decompiler
// Type: 딝.땼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using 땥;

namespace 딝
{
  public class 땼 : 땲
  {
    private new float 딟;
    private new 땥.떁 딟 = new 땥.떁(0.0f, 0.0f);
    private 딺 딟;
    private 딺 땄;
    private 떒 딟;
    private bool 딟 = true;
    private new float 땄;

    public 땼([In] Transform obj0)
      : base(obj0)
    {
      base.딟 = "Theo Jansen Walker";
    }

    public override void 딟()
    {
      base.딟();
      this.딟 = 60f;
      this.딟 = new 땥.떁(6f, -6.666667f);
      this.땄 = 2f;
      this.딟 = true;
      땥.떁 떁1 = new 땥.떁(0.0f, 24f / this.딟);
      for (int index = 0; index < 50; ++index)
        딝.딝.딟(FSWorldComponent.딟(), 0.125f, 1f, new 땥.떁((float) (((double) Random.value * 620.0 + 10.0) / 30.0), -11.33333f)).딟(땥.땎.딧);
      this.딟 = 딝.딝.딟(FSWorldComponent.딟(), 땥.떁.땄(떁1, this.딟));
      this.딟.딟(땥.땎.딧);
      떀 떀1 = 떎.딟(150f / this.딟, 60f / this.딟, 1f, 땥.떁.딟(), this.딟);
      떀1.땄(땑.떂);
      떀1.딟(땑.딧);
      this.땄 = 딝.딝.딟(FSWorldComponent.딟(), 땥.떁.땄(떁1, this.딟));
      this.땄.딟(땥.땎.딧);
      떀 떀2 = 떎.딟(48f / this.딟, 1f, this.땄);
      떀2.땄(땑.떂);
      떀2.딟(땑.딧);
      this.딟 = 떂.딟(FSWorldComponent.딟(), this.땄, this.딟, 땥.떁.딟());
      this.딟.딶(this.땄);
      this.딟.땓(400f);
      ((땺) this.딟).딟(false);
      this.딟.땄(this.딟);
      땥.떁 떁2 = new 땥.떁(0.0f, -24f / this.딟) + 떁1;
      this.딟(-1f, 떁2);
      this.딟(1f, 떁2);
      this.땄.땃(2.094395f);
      this.딟(-1f, 떁2);
      this.딟(1f, 떁2);
      this.땄.땃(-2.094395f);
      this.딟(-1f, 떁2);
      this.딟(1f, 떁2);
    }

    private void 딟([In] float obj0, [In] 땥.떁 obj1)
    {
      땥.떁 떁1 = new 땥.떁(162f * obj0 / this.딟, -183f / this.딟);
      땥.떁 떁2 = new 땥.떁(216f * obj0 / this.딟, -36f / this.딟);
      땥.떁 떁3 = new 땥.떁(129f * obj0 / this.딟, -57f / this.딟);
      땥.떁 떁4 = new 땥.떁(93f * obj0 / this.딟, 24f / this.딟);
      땥.떁 떁5 = new 땥.떁(180f * obj0 / this.딟, 45f / this.딟);
      땥.떁 떁6 = new 땥.떁(75f * obj0 / this.딟, 111f / this.딟);
      딺 딺1 = 딝.딝.딟(FSWorldComponent.딟(), this.딟);
      딺1.딟(땥.땎.딧);
      딺 딺2 = 딝.딝.딟(FSWorldComponent.딟(), 땥.떁.땄(떁4, this.딟));
      딺2.딟(땥.땎.딧);
      List<땥.땨> 땨List1 = new List<땥.땨>();
      List<땥.땨> 땨List2 = new List<땥.땨>();
      땨List1.Add(new 땥.땨());
      땨List2.Add(new 땥.땨());
      if ((double) obj0 > 0.0)
      {
        땨List1[0].Add(떁1);
        땨List1[0].Add(떁2);
        땨List1[0].Add(떁3);
        땨List2[0].Add(땥.떁.딟());
        땨List2[0].Add(땥.떁.딝(떁5, 떁4));
        땨List2[0].Add(땥.떁.딝(떁6, 떁4));
      }
      else
      {
        땨List1[0].Add(떁1);
        땨List1[0].Add(떁3);
        땨List1[0].Add(떁2);
        땨List2[0].Add(땥.떁.딟());
        땨List2[0].Add(땥.떁.딝(떁6, 떁4));
        땨List2[0].Add(땥.떁.딝(떁5, 떁4));
      }
      떀 떀1 = 떎.딟(땨List1, 1f, 딺1)[0];
      떀 떀2 = 떎.딟(땨List2, 1f, 딺2)[0];
      떀1.땄(땑.떂);
      떀1.딟(땑.딧);
      떀2.땄(땑.떂);
      떀2.딟(땑.딧);
      딺1.딢(10f);
      딺2.딢(10f);
      float num1 = 0.5f;
      float num2 = 10f;
      땧 땧1 = 떂.딢(FSWorldComponent.딟(), 딺1, 딺2, 딺1.땺(땥.떁.땄(떁2, this.딟)), 딺2.땺(땥.떁.땄(떁5, this.딟)));
      땧1.땃(num1);
      땧1.딢(num2);
      땧 땧2 = 떂.딢(FSWorldComponent.딟(), 딺1, 딺2, 딺1.땺(땥.떁.땄(떁3, this.딟)), 딺2.땺(땥.떁.땄(떁4, this.딟)));
      땧2.땃(num1);
      땧2.딢(num2);
      땧 땧3 = 떂.딢(FSWorldComponent.딟(), 딺1, this.땄, 딺1.땺(땥.떁.땄(떁3, this.딟)), this.땄.땺(땥.떁.땄(obj1, this.딟)));
      땧3.땃(num1);
      땧3.딢(num2);
      땧 땧4 = 떂.딢(FSWorldComponent.딟(), 딺2, this.땄, 딺2.땺(땥.떁.땄(떁6, this.딟)), this.땄.땺(땥.떁.땄(obj1, this.딟)));
      땧4.땃(num1);
      땧4.딢(num2);
      떂.딟(FSWorldComponent.딟(), 딺2, this.딟, this.딟.땺(땥.떁.땄(떁4, this.딟)));
    }

    public override void 땄()
    {
      if ((double) this.딟.땼().딟 > 16.6666660308838 && (double) this.땄 > 0.0)
      {
        this.땄 = -2f;
        this.딟.딶(this.땄);
      }
      if ((double) this.딟.땼().딟 < 4.0 && (double) this.땄 < 0.0)
      {
        this.땄 = 2f;
        this.딟.딶(this.땄);
      }
      base.땄();
    }
  }
}
