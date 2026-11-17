// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.HTTP.JSResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using 딧;

namespace SplashDamage.Mobile.HTTP
{
  [딷]
  [Serializable]
  public sealed class JSResponse
  {
    [떁(Name = "headers")]
    public string HeadersText;
    [떁(Name = "response")]
    public string Response;
    [떁(Name = "status")]
    public int Status;
    [떁(Name = "status_text")]
    public string StatusText;
    [떁(Name = "unique_id")]
    public string UniqueId;
  }
}
