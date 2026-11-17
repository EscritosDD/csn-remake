// Decompiled with JetBrains decompiler
// Type: 딶.딲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딲 : 떒
  {
    private GameResultOverlayHandler 딟;
    private GameResultOverlayHandler 땄;

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      땇.딟().딟.ClearCinematics();
      this.땄 = 땇.딟().땢().GameResultOverlay;
      if (Object.op_Equality((Object) this.딟, (Object) null))
      {
        Camera uiCamera = 땇.딟().땢().UICamera;
        this.딟 = Object.Instantiate((Object) this.땄) as GameResultOverlayHandler;
        this.딟.Init(땇.딟().땼());
        ((Component) this.딟).transform.parent = ((Component) uiCamera).transform;
        ((Component) this.딟).transform.localPosition = new Vector3(0.0f, 0.0f, 1f);
      }
      땇.딟().땼().떔().땄();
    }

    protected override void 땄()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딧(this.딟.get_IsDone());
    }

    public override void 딟([In] bool obj0)
    {
      딡.땴().딷().딟().딟.ClearCinematics();
      Object.Destroy((Object) ((Component) this.딟).gameObject);
    }
  }
}
