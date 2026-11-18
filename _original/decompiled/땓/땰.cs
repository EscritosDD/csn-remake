// Decompiled with JetBrains decompiler
// Type: 땓.땰
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  internal class 땰 : IDisposable
  {
    private Vector3 딟;
    private Transform 딟;

    public 땰([In] 딶.딡 obj0, [In] 땦 obj1)
    {
      Vector3 tileCentre = obj0.땓().GetTileCentre(obj1.땴().땃, obj1.땴().딶);
      ref Vector3 local = ref tileCentre;
      local.y = (__Null) (local.y + 0.100000001490116);
      Quaternion quaternion = Quaternion.Euler(0.0f, GlobalAppData.딟.GameAssets.FriendlyDisplayInfo.StartAngle, 0.0f);
      this.딟 = (Transform) Object.Instantiate((Object) GlobalAppData.딟.GameAssets.FriendlyDisplayInfo.ModelPrefab, tileCentre, quaternion);
      this.딟 = this.딟.localScale;
    }

    public void Dispose()
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      Object.Destroy((Object) ((Component) this.딟).gameObject);
      this.딟 = (Transform) null;
    }

    public void 딟([In] 딶.딡 obj0, [In] Vector3 obj1, [In] Quaternion obj2, [In] float obj3)
    {
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      ref Vector3 local = ref obj1;
      local.y = (__Null) (local.y + 0.100000001490116);
      this.딟.position = obj1;
      Quaternion flatRotation = obj0.딟.GetFlatRotation(90f);
      this.딟.rotation = Quaternion.Euler(0.0f, (float) ((Quaternion) ref flatRotation).eulerAngles.y + GlobalAppData.딟.GameAssets.FriendlyDisplayInfo.StartAngle, 0.0f);
      this.딟.localScale = Vector3.op_Multiply(this.딟, (float) (0.5 * (double) obj3 * (double) obj0.딟.GetZoom() + 1.0));
    }
  }
}
