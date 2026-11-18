// Decompiled with JetBrains decompiler
// Type: 딶.딻
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 딻 : 떒
  {
    public 딻([In] int obj0)
      : base(obj0)
    {
    }

    protected override void 딟()
    {
      base.딟();
      딡.땴().딟.FollowUnit(((땏) this).딟);
    }

    public override string ToString() => string.Format("[CameraFollowCinematicEvent]: Following {0} -> ", (object) ((땏) this).딟);
  }
}
