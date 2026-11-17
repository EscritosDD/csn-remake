// Decompiled with JetBrains decompiler
// Type: 딢.땇
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딢
{
  public class 땇
  {
    private FriendSelectionButton 딟;
    private 딟.땫 딟;

    public 땇([In] 딟.땫 obj0, [In] 땄.딽 obj1)
    {
      this.딟 = obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      this.딟();
    }

    public void 딟()
    {
      if (Object.op_Inequality((Object) this.딢(), (Object) null) || string.IsNullOrEmpty(this.딧().딢()))
        return;
      this.딟.딟("http://graph.facebook.com/" + this.딧().딢() + "/picture?type=normal", new Action(this.땄), new Action<Texture2D>(this.딟));
    }

    private void 땄()
    {
    }

    private void 딟([In] Texture2D obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.SetAvatarIcon(this.딢());
    }

    public void 딟([In] FriendSelectionButton obj0)
    {
      this.딟 = obj0;
      this.딟.SetAvatarIcon(this.딢());
    }

    [CompilerGenerated]
    [SpecialName]
    public 땄.딽 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Texture2D 딢() => this.딟;
  }
}
