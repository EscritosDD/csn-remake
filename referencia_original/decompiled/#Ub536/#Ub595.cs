// Decompiled with JetBrains decompiler
// Type: 딶.떕
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 떕 : 떒
  {
    private 딢.딴 딟;

    public 떕([In] int obj0, [In] 딢.딴 obj1)
    {
      ((땏) this).딟 = obj0;
      this.딟 = obj1;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      딡.땴().딷().딟(((땏) this).딟).딟(this.딟);
    }

    public override string ToString() => string.Format("[ChangeWeaponCinematicEvent] Unit:{0} WeaponAbility:{1}", (object) ((땏) this).딟, (object) this.딟);
  }
}
