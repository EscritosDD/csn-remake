// Decompiled with JetBrains decompiler
// Type: 딶.땊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땊 : 떒
  {
    protected string 딟;
    protected GameObject 딟;
    protected new float 딟;
    protected Quaternion 딟;
    protected Transform 딟;
    protected new bool 딟;
    public GameObject 땄;

    public 땊([In] int obj0, [In] GameObject obj1, [In] float obj2, [In] float obj3)
      : base(obj2)
    {
      this.딟(obj0, (string) null, (Transform) null, 땩.딟, obj1, obj3, false);
    }

    public 땊([In] int obj0, [In] GameObject obj1, [In] float obj2, [In] float obj3, [In] bool obj4)
      : base(obj2)
    {
      this.딟(obj0, (string) null, (Transform) null, 땩.딟, obj1, obj3, obj4);
    }

    public 땊([In] int obj0, [In] string obj1, [In] GameObject obj2, [In] float obj3, [In] float obj4, [In] bool obj5)
      : base(obj3)
    {
      this.딟(obj0, obj1, (Transform) null, 땩.딟, obj2, obj4, obj5);
    }

    public 땊([In] 땩 obj0, [In] GameObject obj1, [In] float obj2, [In] float obj3)
      : base(obj2)
    {
      this.딟(-1, (string) null, (Transform) null, obj0, obj1, obj3, false);
    }

    public 땊([In] Transform obj0, [In] GameObject obj1, [In] float obj2, [In] float obj3)
      : base(obj2)
    {
      this.딟(-1, (string) null, obj0, 땩.딟, obj1, obj3, false);
    }

    private void 딟(
      [In] int obj0,
      [In] string obj1,
      [In] Transform obj2,
      [In] 땩 obj3,
      [In] GameObject obj4,
      [In] float obj5,
      [In] bool obj6)
    {
      ((땏) this).딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      ((땏) this).딟 = obj3;
      this.딟 = obj4;
      this.딟 = obj5;
      if (obj6)
        this.딟 = Quaternion.Euler(0.0f, Random.Range(0.0f, 360f), 0.0f);
      else
        this.딟 = Quaternion.identity;
    }

    protected override void 딟()
    {
      base.딟();
      this.땄(false);
    }

    private new void 땄([In] bool obj0)
    {
      this.딢();
      if ((double) this.딟 < 0.0)
      {
        this.땃();
      }
      else
      {
        if (obj0)
          return;
        if (Object.op_Inequality((Object) this.딟, (Object) null))
        {
          this.땄 = Object.Instantiate((Object) this.딟, Vector3.zero, Quaternion.identity) as GameObject;
          this.땄.transform.parent = this.딟;
          this.땄.transform.localPosition = Vector3.zero;
        }
        else
          this.땄 = Object.Instantiate((Object) this.딟, ((Component) 딡.땴().땓().GetTile(((땏) this).딟.딟, ((땏) this).딟.땄)).transform.position, this.딟) as GameObject;
        Object.Destroy((Object) this.땄, this.딟);
      }
    }

    private void 딢()
    {
      if (((땏) this).딟 < 0)
        return;
      땓.땊 땊 = 딡.땴().딷().딟(((땏) this).딟).땴();
      if (this.딟 != null)
        this.딟 = 딡.땴().딷().딟(((땏) this).딟).땄(this.딟);
      if (!Object.op_Equality((Object) this.딟, (Object) null))
        return;
      ((땏) this).딟 = new 땩(땊.땃, 땊.딶);
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      if ((double) this.딟 >= 0.0 || !Object.op_Equality((Object) this.땄, (Object) null))
        return;
      this.땃();
    }

    private void 땃()
    {
      if (!(((땏) this).딟 != 땩.딟))
        return;
      this.딢();
      this.땄 = Object.Instantiate((Object) this.딟, ((Component) 딡.땴().땓().GetTile(((땏) this).딟.딟, ((땏) this).딟.땄)).transform.position, this.딟) as GameObject;
      EventTimelineManager.딟().AddTempVisualEffect(this.땄);
    }

    public override string ToString() => string.Format("[SpawnGameObjectCinematicEvent]: Spawning {0} at pos {1} - UnitIndex:{2} - Parent:{3} - Bone:{4}. LifeTime: {5} Instance:{6}", (object) ((Object) this.딟).name, (object) ((땏) this).딟, (object) ((땏) this).딟, !Object.op_Inequality((Object) this.딟, (Object) null) ? (object) string.Empty : (object) ((Object) this.딟).name, (object) this.딟, (object) this.딟, !Object.op_Inequality((Object) this.땄, (Object) null) ? (object) "No longer exists" : (object) ((Object) this.땄).name);
  }
}
