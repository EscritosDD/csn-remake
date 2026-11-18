// Decompiled with JetBrains decompiler
// Type: 땓.땟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 땟 : IDisposable
  {
    private GameObject 딟;

    public 땟([In] 딶.딡 obj0, [In] Transform obj1, [In] int obj2, [In] int obj3)
    {
      Transform transform = Object.Instantiate((Object) obj1) as Transform;
      transform.position = Vector3.op_Addition(obj0.땓().GetTileCentre(obj2, obj3), new Vector3(0.0f, 0.02f, 0.0f));
      this.딟 = ((Component) transform).gameObject;
    }

    public void Dispose() => Object.Destroy((Object) this.딟);
  }
}
