// Decompiled with JetBrains decompiler
// Type: EnvironmentSettings_Game
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnvironmentSettings_Game : ScriptableObject
{
  public string CurrencyWarBucksId;
  public string CurrencyCoinsId;
  public string CurrencyQuatlooId;
  public string CurrencyKeysId;
  public string XPBoostId;
  public string CoinsBoostId;
  public string MPTurnBonusVoucherId;
  public string FriendAddedOfferVoucherId;
  public string FreeCharacterVoucherId;
  public string BlindBoxProductId;
  public string KeyBundleProductId;
  public string FreeKeysVoucherId;
  public GameSettingsVoucher[] MiscVouchers;
  public string ChromeBlindBoxProductId;

  public string 딟([In] string obj0)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: reference to a compiler-generated method
    GameSettingsVoucher gameSettingsVoucher = ((IEnumerable<GameSettingsVoucher>) this.MiscVouchers).Where<GameSettingsVoucher>(new Func<GameSettingsVoucher, bool>(new EnvironmentSettings_Game.떓()
    {
      딟 = obj0
    }.딟)).FirstOrDefault<GameSettingsVoucher>();
    if (gameSettingsVoucher != null)
      return gameSettingsVoucher.VoucherId;
    Debug.LogWarning((object) ("Unknown voucher " + gameSettingsVoucher.Id));
    return (string) null;
  }
}
