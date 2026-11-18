// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.TurnOp_AddToInventory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class TurnOp_AddToInventory : 딟.떀
  {
    [딧.떁(Name = "user_id")]
    public string UserId;
    [딧.떁(Name = "item_id")]
    public string ItemId;
    [딧.떁(Name = "quantity")]
    public int Quantity;

    public TurnOp_AddToInventory([In] string obj0, [In] string obj1, [In] int obj2)
    {
      this.UserId = obj0;
      this.ItemId = obj1;
      this.Quantity = obj2;
    }

    public TurnOp_AddToInventory()
    {
    }

    public override object[] 딟() => new object[2]
    {
      (object) 딟.딲.딟,
      (object) this
    };
  }
}
