// Decompiled with JetBrains decompiler
// Type: 땄.땉
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Fireteam;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땄
{
  public class 땉
  {
    public 땉([In] TurnBasedSessionTurnData obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Index);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.NextUserId);
      if (this.딧() == "None")
      {
        // ISSUE: reference to a compiler-generated method
        this.딟((string) null);
      }
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0.UserId);
      // ISSUE: reference to a compiler-generated method
      this.딧(딟.딥.딧(obj0.Data));
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.CompletionTime);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0.Inventory != null ? obj0.Inventory : new Dictionary<string, int>());
      // ISSUE: reference to a compiler-generated method
      this.딟(this.딟(obj0.Ops));
      // ISSUE: reference to a compiler-generated method
      this.땄(this.딟(obj0.ExpireOps));
    }

    private List<딟.떀> 딟([In] object[][] obj0)
    {
      List<딟.떀> 떀List = new List<딟.떀>();
      if (obj0 != null)
      {
        foreach (object[] objArray in obj0)
        {
          object obj = objArray[1];
          switch (딧.땾.딟<딟.딲>(objArray[0]))
          {
            case 딟.딲.딟:
              떀List.Add((딟.떀) 딧.땾.딟<TurnOp_AddToInventory>(obj));
              break;
            case 딟.딲.땄:
              떀List.Add((딟.떀) 딧.땾.딟<TurnOp_Consume>(obj));
              break;
          }
        }
      }
      return 떀List;
    }

    [CompilerGenerated]
    [SpecialName]
    public int 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public DateTime 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딧() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public string 딢() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public string 땃() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public Dictionary<string, int> 딶() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딟.떀> 땓() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public List<딟.떀> 땺() => this.땄;
  }
}
