// Decompiled with JetBrains decompiler
// Type: 딶.딘
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딘 : 떒
  {
    private new int 딟;
    private int 땄;
    private new float 딟;
    private 딢.떍 딟;
    private AudioShader2 딟;

    public 딘([In] int obj0, [In] int obj1, [In] 딢.떍 obj2)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딟 = obj2;
      switch (obj2)
      {
        case 딢.떍.땓:
          this.딟 = GlobalAppData.딟.PoisonShader;
          break;
        case 딢.떍.땔:
          this.딟 = GlobalAppData.딟.BeeShader;
          break;
        case 딢.떍.떈:
          this.딟 = GlobalAppData.딟.FireShader;
          break;
      }
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      땓.땦 땦 = 땇.딟(this.딟);
      if (!Object.op_Inequality((Object) 땦.딣(), (Object) null))
        return;
      this.딟 = 1f;
      Vector3 Position = 땦.딗();
      CameraController 딟 = 땇.딟().딟;
      Camera camera = ((Component) 딟).camera;
      Transform transform = (Transform) null;
      float num1 = 0.0f;
      AutoPositionText autoPositionText = (AutoPositionText) null;
      switch (this.딟)
      {
        case 딢.떍.땓:
          if (Object.op_Inequality((Object) GlobalAppData.딟.PosisonEffectPrefab, (Object) null))
          {
            transform = GlobalAppData.딟.PosisonEffectPrefab;
            num1 = GlobalAppData.딟.PoisonEffectDuration;
          }
          autoPositionText = GlobalAppData.딟.GameAssets.PoisonDamageText;
          break;
        case 딢.떍.땔:
          if (Object.op_Inequality((Object) GlobalAppData.딟.BeeEffectPrefab, (Object) null))
          {
            transform = GlobalAppData.딟.BeeEffectPrefab;
            num1 = GlobalAppData.딟.BeeEffectDuration;
          }
          autoPositionText = GlobalAppData.딟.GameAssets.BeeDamageText;
          break;
        case 딢.떍.떈:
          if (Object.op_Inequality((Object) GlobalAppData.딟.FireEffectPrefab, (Object) null))
          {
            transform = GlobalAppData.딟.FireEffectPrefab;
            num1 = GlobalAppData.딟.FireEffectDuration;
          }
          autoPositionText = GlobalAppData.딟.GameAssets.FireDamageText;
          break;
      }
      if (Object.op_Inequality((Object) transform, (Object) null))
      {
        float num2 = Random.Range(0.0f, 360f);
        Object.Destroy((Object) ((Component) (Object.Instantiate((Object) transform, Position, Quaternion.Euler(0.0f, num2, 0.0f)) as Transform)).gameObject, num1);
      }
      if (Object.op_Inequality((Object) this.딟, (Object) null))
      {
        땓.땊 땊 = 땇.딟(this.딟).땴();
        this.딟 = Mathf.Max(this.딟, this.딟.PlayOneShot(((Component) 땇.딟().땓().get_Tiles()[땊.땃, 땊.딶]).gameObject));
      }
      딟.FollowUnit(this.딟);
      if (Object.op_Inequality((Object) autoPositionText, (Object) null))
        (Object.Instantiate((Object) autoPositionText) as AutoPositionText).Init(camera, (-this.땄).ToString(), Position, Vector3.zero, (Transform) null);
      base.딟 = this.딟;
    }

    public override void 딟([In] bool obj0)
    {
      base.딟(obj0);
      딡.땴().딟.ClearCinematics();
    }

    public override string ToString() => string.Format("[ActionDisplayDamageOverTime]");
  }
}
