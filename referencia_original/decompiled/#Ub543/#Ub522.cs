// Decompiled with JetBrains decompiler
// Type: 땃.딢
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  internal class 딢 : 딢.딬
  {
    private 딢.딳.땝 딟;
    private SquadSelectionScreenHandlerNew 딟;

    public 딢([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] List<땓.떀> obj2)
    {
      this.딟 = obj0;
      if (!딶.땖.땄(obj1.딝()))
      {
        this.딢();
        obj0.DeactivateMenu(true);
        FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
      }
      else
      {
        string[] strArray = new string[2]
        {
          string.Empty,
          string.Empty
        };
        for (int index = 0; index < obj1.딝().딟.Length && index < 2; ++index)
        {
          땄.땣 땣 = GlobalAppData.떏().땄(obj1.딝().딟[index].딧(), false);
          if (땣.땄() && 땣.딧())
            strArray[index] = 땣.딟.땄();
        }
        Dictionary<string, int> dictionary = 딢.딛.딟(obj2, GlobalAppData.땽());
        this.딟 = 딢.딳.딟(obj1.딝(), (IEnumerable<땓.떀>) obj2, dictionary, strArray, ((딟.땇) GlobalAppData.떏()).땓());
        if (this.딟 != null)
          return;
        this.딢();
      }
    }

    private void 딢()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(딢.땍.딧);
      (Object.Instantiate((Object) FrontendHub.딟.ErrorMessage) as ErrorMessagehandler).Init(ErrorMessagehandler.땶.땋, 딟.땑.딟);
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
