// Decompiled with JetBrains decompiler
// Type: 딶.딼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딼 : 떒
  {
    private new int 딟;
    private int 땄;
    private new float 딟;
    private new float 땄;

    public 딼([In] int obj0, [In] int obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      this.딟 = 0.0f;
      CameraController 딟 = 땇.딟().딟;
      Camera camera = ((Component) 딟).camera;
      if (!Object.op_Inequality((Object) 땇.딟(this.딟).딣(), (Object) null))
        return;
      딟.MoveToPos(땇.딟(this.딟).딣().transform.position, -1f);
      땓.땦 땦 = 땇.딟(this.딟);
      if (this.땄 > 0)
        return;
      string str1 = 땇.딟().땼().땻()[this.딟].딟(땇.딟(this.딟).땴(), 땓.딺.떂);
      if (str1 != null)
      {
        double num = (double) 땦.딟(str1, (WrapMode) 1);
        this.땄 = 땇.딟(this.딟).딟(str1);
      }
      string str2 = 땇.딟().땼().땻()[this.딟].딟(땇.딟(this.딟).땴(), 땓.딺.딟);
      if (str2 == null)
        return;
      double num1 = (double) 땦.땄(str2, (WrapMode) 1);
    }

    public override void 딟([In] bool obj0) => 딡.땴().딷().딟().딟.ClearCinematics();

    protected override void 땄()
    {
      this.딟 += Time.deltaTime;
      if ((double) this.딟 <= (double) this.땄)
        return;
      this.딧(true);
    }
  }
}
