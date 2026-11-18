// Decompiled with JetBrains decompiler
// Type: 딶.땗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 땗 : 떒
  {
    private new float 딟;
    private new float 땄;

    public 땗([In] float obj0, [In] float obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    protected override void 딟()
    {
      CameraController 딟 = 딡.땴().딟;
      base.딟();
      딟.ShakeCamera(this.딟, this.땄);
    }

    public override string ToString() => "[CameraShakeCinematicEvent]";
  }
}
