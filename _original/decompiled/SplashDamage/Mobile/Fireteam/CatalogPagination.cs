// Decompiled with JetBrains decompiler
// Type: SplashDamage.Mobile.Fireteam.CatalogPagination
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using 딧;

namespace SplashDamage.Mobile.Fireteam
{
  [딷]
  [Serializable]
  public sealed class CatalogPagination
  {
    [떁(Name = "page")]
    public int Page;
    [떁(Name = "prev_page")]
    public int PrevPage;
    [떁(Name = "next_page")]
    public int NextPage;
    [떁(Name = "pages")]
    public int Pages;
    [떁(Name = "total_count")]
    public int TotalCount;
    [떁(Name = "items")]
    public CatalogEntry[] Items;
  }
}
