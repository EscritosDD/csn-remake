// Decompiled with JetBrains decompiler
// Type: 땄.땁
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 땁 : 딧.땽
  {
    protected byte[] 딟;

    public 땁([In] 딟.땇 obj0, [In] 딧.땥 obj1)
      : base((딧.땃) obj0, obj1)
    {
      base.딟 = obj1;
      base.딟 = (딧.땃) obj0;
    }

    [SpecialName]
    public 딟.땇 땄() => base.딟 as 딟.땇;

    [SpecialName]
    public override byte[] 딟()
    {
      if (this.딟 == null)
        this.딟 = !(base.딟.딟("Content-Encoding") == "x-fireteam-aes") ? base.딟.딧() : 딟.떓.땄(this.땄().땢(), base.딟.딧());
      return this.딟;
    }
  }
}
