// Decompiled with JetBrains decompiler
// Type: 땄.딽
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 딽
  {
    public 딽([In] UserData obj0, [In] Func<Dictionary<string, object>, 땅> obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.UserId);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0.UserName);
      this.딧(obj0.Email);
      // ISSUE: reference to a compiler-generated method
      this.딢((string) null);
      this.딟(obj1(obj0.PublicProfileData));
    }

    public 딽([In] FacebookFriendData obj0, [In] Func<Dictionary<string, object>, 땅> obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.UserId);
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0.UserName);
      this.딧((string) null);
      // ISSUE: reference to a compiler-generated method
      this.딢(obj0.FacebookId);
      this.딟(obj1(obj0.PublicProfileData));
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 땄() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public string 딧() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 딧([In] string obj0) => this.딧 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public string 딢() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public 땅 땃() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 땅 obj0) => this.딟 = obj0;
  }
}
