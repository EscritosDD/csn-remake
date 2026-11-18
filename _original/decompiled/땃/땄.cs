// Decompiled with JetBrains decompiler
// Type: 땃.땄
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  internal class 땄 : 딢.딬
  {
    private 땄.딴 딟;
    private SquadSelectionScreenHandlerNew 딟;

    public 땄([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] List<땓.떀> obj2)
    {
      this.딟 = obj0;
      string str = 딶.땖.딟((IEnumerable<땓.떀>) obj2);
      Dictionary<string, int> dictionary = 딢.딛.딟(obj2);
      this.딟 = GlobalAppData.떏().딟(obj1.딝().딟, 1, obj1.땥(), str, dictionary, obj1.떎(), (List<딟.떀>) null, (List<딟.떀>) null);
    }

    public void 딧()
    {
      if (this.딟 == null || !this.딟.땄())
        return;
      if (this.딟.딧())
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(딢.땍.딢);
        this.딟.DeactivateMenu(true);
        FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
      }
      else
      {
        this.딟.OnNetworkError((땄.땘) this.딟);
        // ISSUE: reference to a compiler-generated method
        this.딟(딢.땍.딧);
      }
      this.딟 = (땄.딴) null;
    }

    [CompilerGenerated]
    [SpecialName]
    public 딢.땍 딟() => this.딟;

    [SpecialName]
    public 딢.딬 땄() => (딢.딬) null;
  }
}
