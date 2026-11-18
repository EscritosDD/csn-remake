// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.TurnOp_Consume
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class TurnOp_Consume : 딟.떀
  {
    [딧.떁(Name = "item_id")]
    public string ItemId;
    [딧.떁(Name = "quantity")]
    public int Quantity;

    public TurnOp_Consume([In] string obj0, [In] int obj1)
    {
      this.ItemId = obj0;
      this.Quantity = obj1;
    }

    public TurnOp_Consume()
    {
    }

    public override object[] 딟() => new object[2]
    {
      (object) 딟.딲.땄,
      (object) this
    };
  }
}
