// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.HTTP.JSRequest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using 딧;

namespace SplashDamage.Mobile.HTTP
{
  [딷]
  [Serializable]
  public sealed class JSRequest
  {
    [떁(Name = "body")]
    public string Body;
    [떁(Name = "headers")]
    public List<JSRequestHeader> Headers;
    [떁(Name = "method")]
    public string Method;
    [떁(Name = "unique_id")]
    public string UniqueId;
    [떁(Name = "url")]
    public string Url;
  }
}
