// Decompiled with JetBrains decompiler
// Type: 딢.딱
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 딢
{
  public class 딱 : 땂<때, UnitOutfit, BuildManifestOutfitData>
  {
    private Dictionary<string, List<때>> 딟;

    public List<때> 딟([In] string obj0)
    {
      if (string.IsNullOrEmpty(obj0))
        return (List<때>) null;
      this.딟();
      List<때> 때List;
      return !this.딟.TryGetValue(obj0, out 때List) ? (List<때>) null : 때List;
    }

    private new void 딟()
    {
      if (this.딟 != null)
        return;
      this.딟 = new Dictionary<string, List<때>>();
      foreach (때 때 in this.딧())
      {
        List<때> 때List;
        if (!this.딟.TryGetValue(때.땓(), out 때List))
        {
          때List = new List<때>();
          this.딟.Add(때.땓(), 때List);
        }
        때List.Add(때);
      }
    }
  }
}
