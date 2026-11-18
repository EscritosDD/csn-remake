// Decompiled with JetBrains decompiler
// Type: 딶.딜
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딜 : 떒
  {
    private Vector3 딟 = new Vector3(-100f, -100f, -100f);
    private 딢.땘 딟;
    private new bool 딟;
    private bool 땄;
    private bool 딧 = true;

    public 딜([In] 땩 obj0)
      : base(obj0, 0.0f)
    {
    }

    public 딜([In] int obj0)
      : base(obj0)
    {
    }

    public 딜([In] int obj0, [In] bool obj1, [In] bool obj2)
      : base(obj0)
    {
      this.딟 = obj1;
      this.땄 = obj2;
    }

    public 딜([In] int obj0, [In] bool obj1, [In] bool obj2, [In] bool obj3)
      : this(obj0, obj1, obj2)
    {
      this.딧 = obj3;
    }

    public 딜([In] 땩 obj0, [In] float obj1)
      : base(obj0, obj1)
    {
    }

    public 딜([In] 땩 obj0, [In] float obj1, [In] bool obj2)
      : this(obj0, obj1)
    {
      this.딟 = obj2;
    }

    public 딜([In] Vector3 obj0, [In] float obj1)
      : base(obj1)
    {
      this.딟 = obj0;
    }

    public 딜([In] Vector3 obj0, [In] bool obj1)
      : this(obj0, -1f)
    {
      this.딧 = obj1;
    }

    public 딜([In] Vector3 obj0, [In] float obj1, [In] bool obj2)
      : this(obj0, obj1)
    {
      this.딟 = obj2;
    }

    public 딜([In] Vector3 obj0, [In] float obj1, [In] bool obj2, [In] bool obj3)
      : this(obj0, obj1, obj2)
    {
      this.딧 = obj3;
    }

    public 딜([In] Vector3 obj0, [In] float obj1, [In] 딢.땘 obj2)
      : this(obj0, obj1)
    {
      this.딟 = obj2;
    }

    protected override void 딟()
    {
      CameraController 딟 = 딡.땴().딟;
      if (((땏) this).딟 >= 0)
      {
        GameObject gameObject = 딡.땴().딷().딟(((땏) this).딟).딣();
        if (Object.op_Inequality((Object) gameObject, (Object) null))
          this.딟 = gameObject.transform.position;
        else if (this.땄)
        {
          땓.땊 땊 = 딡.땴().딷().딟(((땏) this).딟).땴();
          this.딟 = ((Component) 딡.땴().땼().땹().get_Tiles()[땊.땃, 땊.딶]).transform.position;
        }
        else
          this.딟 = 딟.get_TargetPos();
      }
      else if (((땏) this).딟 != 땩.딟)
        this.딟 = 딡.땴().땓().GetTileCentre(((땏) this).딟.딟, ((땏) this).딟.땄);
      if ((double) base.딟 < 0.0)
        base.딟 = Vector2.Distance(new Vector2((float) 딟.get_TargetPos().x, (float) 딟.get_TargetPos().z), new Vector2((float) this.딟.x, (float) this.딟.z)) / 딟.cinematicMoveSpeed;
      bool flag = !this.딟 || !딟.IsInActionFrustum(this.딟);
      if (!flag)
        base.딟 = 0.0f;
      base.딟();
      if (!flag)
        return;
      if (this.딧)
        딟.MoveToPos(this.딟, base.딟, this.딟);
      else
        딟.MoveTowardsPos(this.딟, this.딟);
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      if (!obj0 || !Vector3.op_Inequality(this.딟, new Vector3(-100f, -100f, -100f)))
        return;
      딡.땴().딟.MoveToPos(this.딟, -1f);
    }

    public override string ToString() => string.Format("[CameraMoveCinematicEvent]: Looking At {0} -> ", (object) this.딟);
  }
}
