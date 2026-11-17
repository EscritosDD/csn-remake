// Decompiled with JetBrains decompiler
// Type: 딢.떉
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  public class 떉
  {
    public 떉([In] string obj0, [In] int obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(GlobalAppData.땼().떔(obj0).땓());
      // ISSUE: reference to a compiler-generated method
      this.딟(this.딧().땄());
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
    }

    [SpecialName]
    public int 딟() => GlobalAppData.땽().떎(this.딧().Id);

    [CompilerGenerated]
    [SpecialName]
    public int 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public SinglePlayerMissionAsset 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딟.땩> 딢() => this.딟;
  }
}
