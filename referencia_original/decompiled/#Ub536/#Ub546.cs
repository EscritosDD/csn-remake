// Decompiled with JetBrains decompiler
// Type: 딶.땆
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;

namespace 딶
{
  public class 땆 : 땣
  {
    protected 딢.딴 딟;
    protected new string 딟;

    public 땆([In] int obj0, [In] 딢.딴 obj1, [In] string obj2, [In] string obj3)
      : base(obj0, obj2)
    {
      this.딟 = obj1;
      this.딟 = obj3;
    }

    protected override void 딟()
    {
      base.딟();
      this.딧(true);
    }

    public override string ToString() => string.Format("[PlayHitAnimationCinematicEvent]: Playing Animation {0}", (object) base.딟);

    public override bool 딟([In] int obj0, [In] 땮 obj1)
    {
      if (obj0 != ((땏) this).딟)
        return false;
      땇 땇 = (땇) 딡.땴().딷();
      UnitWeapon unitWeapon = GlobalAppData.땼().땽(this.딟);
      땮 땮 = obj1;
      switch (땮)
      {
        case 땮.딶:
          딡.땴().딟.ClearCinematics();
          this.땄(false);
          return true;
        case 땮.땺:
          switch (땇.딟().땼().땻()[obj0].떁())
          {
            case 땓.땑.딧:
              땇.딟(obj0).딟(unitWeapon.HitMetalSoundShader);
              return true;
            case 땓.땑.딢:
              땇.딟(obj0).딟(unitWeapon.HitWoodSoundShader);
              return true;
            case 땓.땑.땃:
              땇.딟(obj0).딟(unitWeapon.HitConcreteSoundShader);
              return true;
            default:
              땇.딟(obj0).딟(unitWeapon.HitSoundShader);
              return true;
          }
        default:
          if (땮 != 땮.땭)
          {
            if (땮 != 땮.딷)
              return false;
            땇.딟(obj0).딟(unitWeapon.ProjectileBySoundShader);
            return true;
          }
          땇.딟(obj0).딟(unitWeapon.BulletBySoundShader);
          return true;
      }
    }
  }
}
