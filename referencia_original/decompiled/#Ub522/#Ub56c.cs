// Decompiled with JetBrains decompiler
// Type: 딢.땬
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  internal abstract class 땬 : 딬
  {
    protected SquadSelectionScreenHandlerNew 딟;
    protected 땄.땞[] 딟;
    protected int 딟;
    protected List<땓.떀> 딟;
    protected 딧.땧 딟;

    public 땬([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] 땄.땞[] obj2, [In] List<땓.떀> obj3)
    {
      this.딟 = obj0;
      this.딟 = obj2;
      this.딟 = -1;
      this.딟 = obj3;
      this.딟 = obj1;
    }

    protected void 딢()
    {
      땄.땞 땞;
      do
      {
        ++this.딟;
        if (this.딟 >= this.딟.Length)
        {
          this.딟(땍.땄);
          return;
        }
        땞 = this.딟[this.딟];
      }
      while (땞.딟(((딟.땇) GlobalAppData.떏()).땓()));
      string str = 딶.땖.딟((IEnumerable<땓.떀>) this.딟);
      Dictionary<string, int> dictionary = 딛.딟(this.딟);
      this.딟(땞, str, dictionary);
    }

    public abstract void 딧();

    protected abstract void 딟([In] 땄.땞 obj0, [In] string obj1, [In] Dictionary<string, int> obj2);

    [CompilerGenerated]
    [SpecialName]
    public 땍 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    protected void 딟([In] 땍 obj0) => this.딟 = obj0;

    [SpecialName]
    public abstract 딬 땄();
  }
}
