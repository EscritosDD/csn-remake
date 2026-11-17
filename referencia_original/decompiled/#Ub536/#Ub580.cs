// Decompiled with JetBrains decompiler
// Type: 딶.떀
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 떀 : 떒
  {
    private new const float 딟 = 20f;
    private new const float 땄 = 40f;
    private List<int> 딟;
    private List<int> 땄;
    private float 딧;

    public 떀([In] List<int> obj0, [In] List<int> obj1) => this.딟(obj0, obj1);

    public 떀([In] int obj0, [In] int obj1)
    {
      List<int> intList1 = new List<int>();
      intList1.Add(obj0);
      List<int> intList2 = new List<int>();
      intList1.Add(obj1);
      this.딟(intList1, intList2);
    }

    private void 딟([In] List<int> obj0, [In] List<int> obj1)
    {
      this.딟 = obj0;
      this.땄 = obj1;
    }

    protected override void 딟()
    {
      base.딟();
      땇 땇 = (땇) 딡.땴().딷();
      CameraController 딟 = 땇.딟().딟;
      Camera camera = ((Component) 딟).camera;
      for (int index = 0; index < this.딟.Count; ++index)
      {
        Vector3 Position = 땇.딟(this.딟[index]).딗();
        if (Object.op_Inequality((Object) GlobalAppData.딟.HealEffectPrefab, (Object) null))
        {
          float num = Random.Range(0.0f, 360f);
          Object.Destroy((Object) ((Component) (Object.Instantiate((Object) GlobalAppData.딟.HealEffectPrefab, Position, Quaternion.Euler(0.0f, num, 0.0f)) as Transform)).gameObject, GlobalAppData.딟.HealEffectDuration);
        }
        (Object.Instantiate((Object) GlobalAppData.딟.GameAssets.HealingText) as AutoPositionText).Init(camera, this.땄[index].ToString(), Position, Vector3.zero, (Transform) null);
      }
      Vector3 focusOnTargets = 딟.CalculateFocusOnTargets(this.딟, false, out int _, out 딢.땘 _, out bool _);
      딟.MoveToPos(focusOnTargets, 0.0f);
    }

    public override void 딟([In] bool obj0) => 딡.땴().딷().딟().딟.ClearCinematics();

    protected override void 땄()
    {
      this.딧 += Time.deltaTime;
      if ((double) this.딧 <= 2.0)
        return;
      this.딧(true);
    }
  }
}
