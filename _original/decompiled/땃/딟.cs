// Decompiled with JetBrains decompiler
// Type: 땃.딟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땃
{
  internal class 딟 : 딢.딬
  {
    private SquadSelectionScreenHandlerNew 딟;
    private 딢.딳.땝 딟;

    public 딟([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] List<땓.떀> obj2)
    {
      this.딟 = obj0;
      Dictionary<string, int> dictionary = 딢.딛.딟(obj2, GlobalAppData.땽());
      this.딟 = 딢.딳.딟(obj1.딧(), 0, obj1.땓(), (IEnumerable<땓.떀>) obj2, dictionary, string.Empty, ((딟.땇) GlobalAppData.떏()).땓(), obj1.땥(), obj1.땃());
      if (this.딟 != null)
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(딢.땍.딧);
    }

    public void 딧()
    {
      if (this.딟 == null || !this.딟.땄())
        return;
      // ISSUE: reference to a compiler-generated method
      this.딟(딢.땍.딢);
      딶.땖 GameToLoad = this.딟.딟();
      this.딟 = (딢.딳.땝) null;
      this.딟.DeactivateMenu(true);
      FrontendHub.딟.LoadingScreen.ActivateMenu(GameToLoad, true);
    }

    [CompilerGenerated]
    [SpecialName]
    public 딢.땍 딟() => this.딟;

    [SpecialName]
    public 딢.딬 땄() => (딢.딬) null;
  }
}
