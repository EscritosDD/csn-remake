// Decompiled with JetBrains decompiler
// Type: 땓.떅
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 떅 : 땶
  {
    private 딢.딧 딟;

    public 떅([In] string obj0) => this.딟(obj0);

    public 떅([In] Uri obj0) => this.딟(obj0.Host);

    private void 딟([In] string obj0)
    {
      this.딟 = GlobalAppData.땼().땘(obj0);
      if (this.딟 == null)
        return;
      GlobalAppData.땼().떎(obj0);
    }

    [SpecialName]
    public override bool 딟() => this.딟 == null || this.딟.딢();

    [SpecialName]
    public override bool 땄() => this.딟 != null;

    [SpecialName]
    public override Material 딧() => this.딟.땓().Material;
  }
}
