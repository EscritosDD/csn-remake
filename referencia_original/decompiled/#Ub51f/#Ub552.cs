// Decompiled with JetBrains decompiler
// Type: 딟.땒
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  internal class 땒 : 땨
  {
    private 땯 딟;

    public 땒([In] 땇 obj0, [In] 땯 obj1, [In] string obj2, [In] string obj3)
      : base(obj0, obj2, obj3)
    {
      this.딟 = obj1;
    }

    public override void 딟()
    {
      if (base.딟())
      {
        AccessTokenData accessTokenData = this.땓<AccessTokenData>();
        this.딟.딟 = accessTokenData.AccessToken;
        this.딟.땄 = accessTokenData.RefreshToken;
        this.딟.딧(true);
      }
      else if (base.땄())
        this.딟.딟 = true;
      this.딟.땄(true);
    }

    public override void 땄() => this.딟.땄(true);

    [SpecialName]
    public override 땄.땘 딧() => (땄.땘) this.딟;
  }
}
