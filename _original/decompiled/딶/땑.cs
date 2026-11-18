// Decompiled with JetBrains decompiler
// Type: 딶.땑
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땑 : 떒
  {
    private Vector3 딟;
    private AutoPositionText 딟;
    private string 딟;
    private new float 딟;
    private Transform 딟;

    public 땑([In] AutoPositionText obj0, [In] Vector3 obj1, [In] string obj2, [In] float obj3, [In] float obj4)
      : base(obj4)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      this.딟 = obj3;
      ((땏) this).딟 = -1;
    }

    public 땑([In] AutoPositionText obj0, [In] int obj1, [In] string obj2, [In] float obj3, [In] float obj4)
      : base(obj4)
    {
      this.딟 = obj0;
      ((땏) this).딟 = obj1;
      this.딟 = obj2;
      this.딟 = obj3;
    }

    public 땑([In] AutoPositionText obj0, [In] Transform obj1, [In] string obj2, [In] float obj3, [In] float obj4)
      : base(obj4)
    {
      this.딟 = obj0;
      ((땏) this).딟 = -1;
      this.딟 = obj2;
      this.딟 = obj3;
      this.딟 = obj1;
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      Camera camera = ((Component) 땇.딟().딟).camera;
      AutoPositionText autoPositionText = Object.Instantiate((Object) this.딟) as AutoPositionText;
      bool flag = true;
      if (((땏) this).딟 >= 0)
      {
        땓.땦 땦 = 땇.딟(((땏) this).딟);
        flag = Object.op_Inequality((Object) 땦.딣(), (Object) null);
        땩 땩 = 땦.땴().딟(true);
        this.딟 = 땇.딟().땓().GetTileCentre(땩.딟, 땩.땄);
      }
      if (!flag)
        return;
      float num = this.딟 / (float) Screen.width;
      if (Object.op_Inequality((Object) this.딟, (Object) null))
        autoPositionText.Init(camera, this.딟, Vector3.zero, new Vector3(num, 0.0f, 0.0f), this.딟);
      else
        autoPositionText.Init(camera, this.딟, this.딟, new Vector3(num, 0.0f, 0.0f), (Transform) null);
    }

    public override string ToString() => string.Format("[DisplayHealthTextCinematicEvent] - String:{0} - Wait Time:{1}", (object) this.딟, (object) base.딟);
  }
}
