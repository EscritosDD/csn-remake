// Decompiled with JetBrains decompiler
// Type: 딟.딩
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 딩
  {
    public 딩([In] 떋 obj0)
    {
      switch (obj0)
      {
        case 떋.딟:
          // ISSUE: reference to a compiler-generated method
          this.딟((object) "dynamic");
          break;
        case 떋.땄:
          // ISSUE: reference to a compiler-generated method
          this.딟((object) "float");
          break;
        case 떋.딧:
          // ISSUE: reference to a compiler-generated method
          this.딟((object) "integer");
          break;
        case 떋.딢:
          // ISSUE: reference to a compiler-generated method
          this.딟((object) "string");
          break;
      }
    }

    public 딩([In] object[] obj0) => this.딟((object) obj0);

    [CompilerGenerated]
    [SpecialName]
    public object 딟() => this.딟;
  }
}
