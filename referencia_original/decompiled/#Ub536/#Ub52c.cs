// Decompiled with JetBrains decompiler
// Type: 딶.딬
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딬 : 땣
  {
    private 딢.딯 딟;
    private 딢.딯 땄;
    private GameObject 딟;

    public 딬([In] int obj0, [In] 딢.딯 obj1, [In] 딢.딯 obj2)
      : base(obj0, (string) null)
    {
      ((땏) this).딟 = obj0;
      this.딟 = obj1;
      this.땄 = obj2;
    }

    protected override void 딟()
    {
      if (this.딟 != this.땄)
      {
        땇 땇 = (땇) 딡.땴().딷();
        this.딟 = 땇.딟(((땏) this).딟).딟(땇.딟().땼().땻()[((땏) this).딟].딟(땓.딘.땋), 15f, -1f, -1f);
        float num = 땓.땊.딟(this.딟, this.땄);
        if ((double) num == 90.0)
          base.딟 = 땇.딟().땼().땻()[((땏) this).딟].딟(땇.딟(((땏) this).딟).땴(), 땓.딺.딧);
        else if ((double) num == -90.0)
          base.딟 = 땇.딟().땼().땻()[((땏) this).딟].딟(땇.딟(((땏) this).딟).땴(), 땓.딺.딢);
        else
          base.딟 = 땇.딟().땼().땻()[((땏) this).딟].딟(땇.딟(((땏) this).딟).땴(), 땓.딺.땃);
      }
      base.딟();
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        Object.Destroy((Object) this.딟, 0.0f);
        this.딟 = (GameObject) null;
      }
      땓.땦 땦 = 딡.땴().딷().딟(((땏) this).딟);
      if (!obj0)
        return;
      땦.떏();
    }

    protected override void 딧()
    {
      base.딧();
      if (this.딢())
        return;
      딡.땴().딷().딟(((땏) this).딟).딟(Quaternion.Euler(0.0f, 땓.땊.땄(this.땄), 0.0f));
    }

    public override string ToString() => string.Format("[ActionDisplayTurnUnit] Start Dir:{0} End Dir:{1} Unit:{2}", (object) this.딟, (object) this.땄, (object) ((땏) this).딟);

    private enum 땸
    {
      딟,
      땄,
    }
  }
}
