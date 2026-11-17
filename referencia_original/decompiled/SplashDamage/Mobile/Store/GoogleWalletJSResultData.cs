// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Store.GoogleWalletJSResultData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using 딧;

namespace SplashDamage.Mobile.Store
{
  [딷]
  [Serializable]
  public sealed class GoogleWalletJSResultData
  {
    [떁(Name = "request")]
    public GoogleWalletJSRequestData 딟 { get; [param: In] set; }

    [떁(Name = "response")]
    public GoogleWalletJSResponseData 땄 { get; [param: In] set; }
  }
}
