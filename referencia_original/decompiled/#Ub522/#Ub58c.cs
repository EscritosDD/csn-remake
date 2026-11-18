// Decompiled with JetBrains decompiler
// Type: 딢.떌
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 떌 : IDisposable
  {
    private 땓.땶 딟;

    public 떌([In] 땄.딽 obj0, [In] FireTeamUserProfileChallengeJsonData obj1)
    {
      땓.땇 땇 = obj0.땃() as 땓.땇;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      this.딟 = 땇.딧();
    }

    public bool 딟()
    {
      bool flag = false;
      if (this.딟 != null && this.딟.딟())
      {
        if (this.딟.땄())
        {
          // ISSUE: reference to a compiler-generated method
          this.딟(new Material(this.딟.딧()));
          flag = true;
        }
        this.딟 = (땓.땶) null;
      }
      return flag;
    }

    public void Dispose()
    {
      if (!Object.op_Inequality((Object) this.땄(), (Object) null))
        return;
      Object.Destroy((Object) this.땄());
      // ISSUE: reference to a compiler-generated method
      this.딟((Material) null);
    }

    [CompilerGenerated]
    [SpecialName]
    public Material 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땄.딽 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public FireTeamUserProfileChallengeJsonData 딢() => this.딟;
  }
}
