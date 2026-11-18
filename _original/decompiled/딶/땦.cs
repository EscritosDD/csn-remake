// Decompiled with JetBrains decompiler
// Type: 딶.땦
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땦 : 땣
  {
    protected 딢.딴 딟;
    protected new string 딟;

    public 땦([In] int obj0, [In] 딢.딴 obj1, [In] string obj2)
      : base(obj0, (string) null)
    {
      this.딟 = obj1;
      this.딟 = obj2;
      base.딟 = (string) null;
      if (딡.땴() == null)
        return;
      UnitWeapon unitWeapon = GlobalAppData.땼().땽(obj2);
      if (!Object.op_Inequality((Object) unitWeapon, (Object) null))
        return;
      base.딟 = unitWeapon.딟(딡.땴().땼(), 땓.딺.땄);
    }

    public override string ToString() => string.Format("[PlayFireAnimationCinematicEvent]: Playing Animation {0}", (object) base.딟);

    public override bool 딟([In] int obj0, [In] 땮 obj1)
    {
      땇 땇 = (땇) 딡.땴().딷();
      UnitWeapon unitWeapon1 = GlobalAppData.땼().땽(this.딟);
      if (땦.딟(땇, obj0, obj1, obj0, this.딟, unitWeapon1))
        return true;
      if (obj0 == ((땏) this).딟)
      {
        UnitWeapon unitWeapon2 = 땓.땎.딢(this.딟, 땇.딟().땼().땻()[obj0]);
        switch (obj1)
        {
          case 땮.떎:
          case 땮.떂:
            땦.딟(unitWeapon2, new 땦.떃(땇.딟(obj0).땄), obj1);
            this.딧(true);
            return true;
        }
      }
      return false;
    }

    public static void 딟([In] UnitWeapon obj0, [In] 땦.떃 obj1, [In] 땮 obj2)
    {
      Transform transform1 = obj2 != 땮.떎 ? obj1(obj0.MuzzleJointNameB) : obj1(obj0.MuzzleJointName);
      Transform transform2 = obj2 != 땮.떎 ? obj0.MuzzleFlashPrefabB : obj0.MuzzleFlashPrefab;
      if (!Object.op_Inequality((Object) transform1, (Object) null) || !Object.op_Inequality((Object) transform2, (Object) null))
        return;
      Transform transform3 = (Transform) Object.Instantiate((Object) transform2);
      if (obj0.MuzzleFlashInWorldSpace)
      {
        transform3.position = transform1.position;
        transform3.rotation = transform1.rotation;
      }
      else
      {
        transform3.parent = transform1;
        transform3.localPosition = Vector3.zero;
        transform3.localRotation = Quaternion.identity;
      }
      float num = obj2 != 땮.떎 ? obj0.MuzzleFlashDurationB : obj0.MuzzleFlashDuration;
      Object.Destroy((Object) ((Component) transform3).gameObject, num);
    }

    private static bool 딟([In] 땇 obj0, [In] int obj1, [In] 땮 obj2, [In] int obj3, [In] 딢.딴 obj4, [In] UnitWeapon obj5)
    {
      switch (obj2)
      {
        case 땮.딟:
          obj0.딟(obj1).딟(obj5.FireSoundShader);
          return true;
        case 땮.땄:
          obj0.딟(obj1).딟(obj5.CockSoundShader);
          return true;
        case 땮.땺:
          switch (obj0.딟().땼().땻()[obj1].떁())
          {
            case 땓.땑.딧:
              obj0.딟(obj1).딟(obj5.HitMetalSoundShader);
              return true;
            case 땓.땑.딢:
              obj0.딟(obj1).딟(obj5.HitWoodSoundShader);
              return true;
            case 땓.땑.땃:
              obj0.딟(obj1).딟(obj5.HitConcreteSoundShader);
              return true;
            default:
              obj0.딟(obj1).딟(obj5.HitSoundShader);
              return true;
          }
        case 땮.땭:
          obj0.딟(obj1).딟(obj5.BulletBySoundShader);
          return true;
        case 땮.딷:
          obj0.딟(obj1).딟(obj5.ProjectileBySoundShader);
          return true;
        default:
          return false;
      }
    }

    public delegate Transform 떃([In] string obj0);
  }
}
