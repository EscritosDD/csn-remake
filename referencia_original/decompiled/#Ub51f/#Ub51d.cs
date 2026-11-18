// Decompiled with JetBrains decompiler
// Type: 딟.딝
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Analytics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace 딟
{
  public abstract class 딝 : 땋
  {
    public 딝([In] string obj0)
    {
    }

    public void 딟()
    {
    }

    public void 땄()
    {
    }

    private void 딟([In] string obj0, [In] Dictionary<string, string> obj1, [In] double obj2)
    {
      GAEvent gaEvent = new GAEvent();
      gaEvent.Category = obj0;
      gaEvent.Value = obj2;
      딝.떎 떎 = 딝.떎.딟;
      if (obj1 != null)
      {
        foreach (KeyValuePair<string, string> keyValuePair in obj1)
        {
          switch (떎)
          {
            case 딝.떎.딟:
              gaEvent.Action = keyValuePair.Value;
              떎 = 딝.떎.땄;
              continue;
            case 딝.떎.땄:
              gaEvent.Label = keyValuePair.Value;
              떎 = 딝.떎.딧;
              continue;
            default:
              continue;
          }
        }
      }
      this.딟(gaEvent);
    }

    protected abstract void 딟([In] GAEvent obj0);

    public abstract void 딟([In] string obj0);

    public abstract void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3);

    public abstract void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3);

    public void 딟([In] string obj0, [In] Dictionary<string, string> obj1) => this.딟(obj0, obj1, 0.0);

    public void 딟([In] string obj0, [In] double obj1, [In] Dictionary<string, string> obj2) => this.딟(obj0, obj2, obj1);

    private enum 떎
    {
      딟,
      땄,
      딧,
    }
  }
}
