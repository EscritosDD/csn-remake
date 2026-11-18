// Decompiled with JetBrains decompiler
// Type: 딟.떂
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Analytics;
using System.Runtime.InteropServices;

namespace 딟
{
  public class 떂 : 딝
  {
    private string 딟;

    public 떂([In] string obj0)
      : base(obj0)
    {
      this.딟 = obj0;
      땭.딟(obj0);
    }

    public override void 딟([In] string obj0) => 땭.딟(this.딟, obj0);

    public override void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3)
    {
      double result;
      if (!double.TryParse(obj2, out result))
      {
        result = 0.0;
        딧.떀.딟("Invalid price '{0}'", (object) obj2);
      }
      땭.딟(this.딟, obj0, obj1, result, obj3);
    }

    protected override void 딟([In] GAEvent obj0) => 땭.딟(this.딟, obj0.Category, obj0.Action, obj0.Label, (int) obj0.Value);

    public override void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => 땭.딟(this.딟, obj0, obj1, obj2, obj3);
  }
}
