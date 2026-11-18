// Decompiled with JetBrains decompiler
// Type: 땓.딼
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 딼 : 딧.떒
  {
    private UnitWeapon 딟;
    private UnitBodyType 딟;
    private UnitVoicePack 딟;
    private Transform 딟;

    public 딼([In] UnitWeapon obj0, [In] UnitBodyType obj1, [In] UnitVoicePack obj2, [In] Transform obj3)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      this.딟 = obj2;
      this.딟 = obj3;
    }

    private Transform 딟([In] string obj0) => 땦.딟(this.딟, obj0);

    public void 딟([In] 딶.땮 obj0)
    {
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        switch (obj0)
        {
          case 딶.땮.딟:
            this.딟(this.딟.FireSoundShader);
            break;
          case 딶.땮.땄:
            this.딟(this.딟.CockSoundShader);
            break;
          case 딶.땮.땺:
            this.딟(this.딟.HitSoundShader);
            break;
          case 딶.땮.떎:
          case 딶.땮.떂:
            딶.땦.딟(this.딟, new 딶.땦.떃(this.딟), obj0);
            break;
          case 딶.땮.땭:
            this.딟(this.딟.BulletBySoundShader);
            break;
          case 딶.땮.딷:
            this.딟(this.딟.ProjectileBySoundShader);
            break;
        }
      }
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        switch (obj0)
        {
          case 딶.땮.딧:
            this.딟(this.딟.FootStepShader);
            break;
          case 딶.땮.딢:
            this.딟(this.딟.FoleyShader);
            break;
          case 딶.땮.땃:
            this.딟(this.딟.SwishShader);
            break;
          case 딶.땮.딶:
            this.딟(this.딟.BodyFallShader);
            break;
          case 딶.땮.땓:
            this.딟(this.딟.WeaponDropShader);
            break;
        }
      }
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      switch (obj0)
      {
        case 딶.땮.딦:
          this.딟(this.딟.DeathShader);
          break;
        case 딶.땮.땤:
          this.딟(this.딟.PainShader);
          break;
        case 딶.땮.땽:
          this.딟(this.딟.AppreciationShader);
          break;
        case 딶.땮.땋:
          this.딟(this.딟.ExertionShader);
          break;
        case 딶.땮.땲:
          this.딟(this.딟.IdleShader);
          break;
        case 딶.땮.떏:
          this.딟(this.딟.FiringShader);
          break;
        case 딶.땮.땼:
          this.딟(this.딟.UpsetShader);
          break;
      }
    }

    private void 딟([In] AudioShader2 obj0)
    {
      if (!Object.op_Inequality((Object) obj0, (Object) null))
        return;
      double num = (double) obj0.PlayOneShot(((Component) this.딟).gameObject);
    }
  }
}
