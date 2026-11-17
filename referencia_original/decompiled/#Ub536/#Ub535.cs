// Decompiled with JetBrains decompiler
// Type: 딶.딵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딵 : 떒
  {
    private new const int 딟 = 2;
    private new const float 딟 = 3f;
    private new float 땄;
    private int 땄;
    private float 딧;
    private List<땃.딬> 딟;

    public 딵([In] int obj0, [In] 딢.딯 obj1, [In] List<땃.딬> obj2, [In] int obj3)
      : base(obj0, 0.0f)
    {
      this.땄 = obj3;
      this.딟 = obj2;
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      string str = 땇.딟().땼().땻()[((땏) this).딟].딟(땇.딟(((땏) this).딟).땴(), 땓.딺.딶);
      if (str == null)
        return;
      double num = (double) 땇.딟(((땏) this).딟).딟(str, (WrapMode) 2);
    }

    protected override void 땄()
    {
      땇 땇 = (땇) 딡.땴().딷();
      this.딧 += Time.deltaTime;
      this.땄 = this.딧 * 3f;
      땇.딟(((땏) this).딟).땄(this.딟[this.땄].딟.딟(this.땄));
      땇.딟(((땏) this).딟).딟(this.딟(this.땄, this.땄));
      if ((double) this.땄 + (double) Time.deltaTime * 3.0 < 1.0)
        return;
      this.딧(true);
    }

    public override string ToString() => string.Format("[MoveCinematicEvent] ");

    public override void 딟([In] bool obj0) => base.딟(obj0);

    private Quaternion 딟([In] int obj0, [In] float obj1)
    {
      int index = obj0 != 0 ? obj0 - 1 : 0;
      Quaternion quaternion1 = this.딟[obj0].딟.땄(obj1);
      if ((double) obj1 >= 1.0)
        return quaternion1;
      if ((double) obj1 < 0.5)
      {
        float num = obj1 / 0.5f;
        return Quaternion.Lerp(this.딟[index].딟.땄(0.0f), quaternion1, num);
      }
      float num1 = (float) (((double) obj1 - 0.5) / 0.5);
      Quaternion quaternion2 = this.딟[obj0].딟.땄(1f);
      return Quaternion.Lerp(quaternion1, quaternion2, num1);
    }
  }
}
