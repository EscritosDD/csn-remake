// Decompiled with JetBrains decompiler
// Type: 딢.땮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  internal class 땮 : 딬
  {
    private 땄.딮 딟;
    private SquadSelectionScreenHandlerNew 딟;
    private 딧.땧 딟;

    public 땮([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] List<땓.떀> obj2)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      Dictionary<string, int> dictionary = 딛.딟(obj2, GlobalAppData.땽());
      string str = 딶.땖.딟((IEnumerable<땓.떀>) obj2);
      this.딟 = GlobalAppData.떏().딟(new 땓.땙()
      {
        땄 = obj1.떂(),
        딟 = 0,
        딟 = obj1.딧(),
        딧 = obj1.땓(),
        땄 = obj1.땥(),
        딢 = obj1.땃(),
        딧 = str,
        딟 = dictionary
      });
    }

    public void 딧()
    {
      if (!this.딟.땄())
        return;
      if (this.딟.딧())
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(땍.딢);
        땚.딟(this.딟.땥());
        this.딟.DeactivateMenu(true);
        FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(땍.딧);
        this.딟.OnNetworkError((땄.땘) this.딟);
      }
      this.딟 = (땄.딮) null;
    }

    [CompilerGenerated]
    [SpecialName]
    public 땍 딟() => this.딟;

    [SpecialName]
    public 딬 땄() => (딬) null;
  }
}
