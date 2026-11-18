// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.CatalogEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

namespace SplashDamage.Mobile.Fireteam
{
  [딧.딷]
  [Serializable]
  public sealed class CatalogEntry
  {
    [딧.떁(Name = "id")]
    public string Id;
    [딧.떁(Name = "type")]
    public 딟.딪 Type;
    [딧.떁(Name = "flags")]
    public 딟.떕 Flags;
    [딧.떁(Name = "category")]
    public string Category;
    [딧.떁(Name = "tags")]
    public string[] Tags;
    [딧.떁(Name = "dependencies")]
    public string[] Dependencies;
    [딧.떁(Name = "data")]
    public Dictionary<string, object> Data;
    [딧.떁(Name = "name")]
    public string Name;
    [딧.떁(Name = "description")]
    public string Description;
    [딧.떁(Name = "icon_url")]
    public string IconURL;
    [딧.떁(Name = "preview_urls")]
    public string[] PreviewURLs;
    [딧.떁(Name = "video_url")]
    public string VideoURL;
    [딧.떁(Name = "info")]
    public Dictionary<string, object> Info;
    [딧.떁(Name = "owned_quantity")]
    public int OwnedQuantity;
    [딧.떁(Name = "items")]
    public Dictionary<string, int> Items;
    [딧.떁(Name = "offers")]
    public OfferData[] Offers;
  }
}
