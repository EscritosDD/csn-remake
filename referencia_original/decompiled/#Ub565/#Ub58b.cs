// Decompiled with JetBrains decompiler
// Type: 땥.떋
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땥
{
  public class 떋
  {
    public 떋([In] Stream obj0)
    {
      using (StreamReader streamReader = new StreamReader(obj0))
        this.딟(streamReader.ReadToEnd());
      this.딟(0);
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] string obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public int 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] int obj0) => this.딟 = obj0;

    [SpecialName]
    public int 딧() => this.딟().Length;

    [SpecialName]
    public char 딢()
    {
      char ch = this.딟()[this.땄()];
      떋 떋 = this;
      떋.딟(떋.땄() + 1);
      return ch;
    }

    [SpecialName]
    public char 땃() => this.딟()[this.땄()];

    [SpecialName]
    public bool 딶() => this.땄() == this.딧();
  }
}
