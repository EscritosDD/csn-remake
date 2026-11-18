// Decompiled with JetBrains decompiler
// Type: 딶.땾
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 땾 : 떒
  {
    private new const float 딟 = 20f;
    private new const float 땄 = 40f;
    private new int 딟;
    private int 땄;
    private 딢.딴 딟;
    private List<int> 딟;
    private float 딧;
    private Transform 딟;
    private bool[] 딟;
    private float[] 딟;
    private float 딢;
    private float 땃;

    public 땾([In] int obj0, [In] int obj1, [In] 딢.딴 obj2, [In] List<int> obj3)
    {
      this.딟 = obj0;
      this.땄 = obj1;
      this.딟 = obj2;
      this.딟 = obj3;
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      this.딢 = 0.0f;
      this.땃 = 2f;
      Transform transform = (Transform) null;
      this.딟 = (Transform) null;
      float num1 = 0.0f;
      딢.딴 딟 = this.딟;
      switch (딟)
      {
        case 딢.딴.딢:
          num1 = GlobalAppData.딟.GameAssets.DetectionAuraDuration;
          transform = GlobalAppData.딟.GameAssets.DetectionAuraEffect;
          this.딟 = GlobalAppData.딟.GameAssets.DetectionAuraUnitEffect;
          this.딧 = GlobalAppData.딟.GameAssets.DetectionAuraUnitEffectDuration;
          break;
        case 딢.딴.딶:
          transform = GlobalAppData.딟.GameAssets.BacklashAuraEffect;
          num1 = GlobalAppData.딟.GameAssets.BacklashAuraDuration;
          this.딟 = GlobalAppData.딟.GameAssets.BacklashAuraUnitEffect;
          this.딧 = GlobalAppData.딟.GameAssets.BacklashAuraUnitDuration;
          break;
        default:
          if (딟 != 딢.딴.딷)
          {
            if (딟 == 딢.딴.땚)
              goto case 딢.딴.딢;
            else
              break;
          }
          else
          {
            num1 = GlobalAppData.딟.GameAssets.HealingAuraDuration;
            transform = GlobalAppData.딟.GameAssets.HealingAuraEffect;
            break;
          }
      }
      if (Object.op_Inequality((Object) transform, (Object) null))
      {
        Vector3 tileCentre = 땇.딟().땓().GetTileCentre(this.딟, this.땄);
        float num2 = Random.Range(0.0f, 360f);
        Object.Destroy((Object) ((Component) (Object.Instantiate((Object) transform, tileCentre, Quaternion.Euler(0.0f, num2, 0.0f)) as Transform)).gameObject, num1);
        this.땃 = Mathf.Max(this.땃, num1 + 0.2f);
      }
      if (this.딟 != null && this.딟.Count > 0 && Object.op_Inequality((Object) this.딟, (Object) null))
      {
        this.땃 = Mathf.Max(this.땃, 0.4f);
        this.딟 = new bool[this.딟.Count];
        this.딟 = new float[this.딟.Count];
        for (int index = 0; index < this.딟.Count; ++index)
        {
          this.딟[index] = false;
          this.딟[index] = Random.Range(0.2f, this.땃 - 0.2f);
        }
        Vector3 focusOnTargets = 땇.딟().딟.CalculateFocusOnTargets(this.딟, false, out int _, out 딢.땘 _, out bool _);
        땇.딟().딟.MoveToPos(focusOnTargets, 0.0f);
      }
      else
        땇.딟().딟.MoveToPos(new 땩(this.딟, this.땄), -1f);
    }

    public override void 딟([In] bool obj0) => 딡.땴().딟.ClearCinematics();

    protected override void 땄()
    {
      this.딢 += Time.deltaTime;
      if (딡.땴() == null)
        return;
      땇 땇 = (땇) 딡.땴().딷();
      if (this.딟 != null)
      {
        for (int index = 0; index < this.딟.Length; ++index)
        {
          if (!this.딟[index] && (double) this.딟[index] < (double) this.딢)
          {
            this.딟[index] = true;
            Object.Destroy((Object) ((Component) (Object.Instantiate((Object) this.딟, 땇.딟(this.딟[index]).딗(), Quaternion.Euler(0.0f, Random.Range(0.0f, 360f), 0.0f)) as Transform)).gameObject, this.딧);
            if (this.딟 == 딢.딴.딢 || this.딟 == 딢.딴.땚)
            {
              땓.땦 땦 = 땇.딟(this.딟[index]);
              땇.딟(this.딟[index], 땦.땴().땃, 땦.땴().딶);
            }
          }
        }
      }
      if ((double) this.딢 <= 2.0)
        return;
      this.딧(true);
    }
  }
}
