// Decompiled with JetBrains decompiler
// Type: 딢.떊
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 딢
{
  internal class 떊 : 땬
  {
    private 땄.딴 딟;

    public 떊([In] SquadSelectionScreenHandlerNew obj0, [In] 딧.땧 obj1, [In] 땄.땞[] obj2, [In] List<땓.떀> obj3)
      : base(obj0, obj1, obj2, obj3)
    {
    }

    public override void 딧()
    {
      if (this.딟 != null)
      {
        if (!this.딟.땄())
          return;
        bool flag = this.딟.딧();
        this.딟 = (땄.딴) null;
        if (flag)
        {
          this.딟(땍.딢);
          base.딟.DeactivateMenu(true);
          FrontendHub.딟.MultiPlayerScreen.ActivateMenu();
          return;
        }
      }
      this.딢();
    }

    [SpecialName]
    public override 딬 땄() => (딬) new 땮(base.딟, base.딟, base.딟);

    protected override void 딟([In] 땄.땞 obj0, [In] string obj1, [In] Dictionary<string, int> obj2) => this.딟 = GlobalAppData.떏().딟(obj0.딟, 1, obj0.딟[0].딧(), obj1, obj2, false, (List<딟.떀>) null, (List<딟.떀>) null);
  }
}
