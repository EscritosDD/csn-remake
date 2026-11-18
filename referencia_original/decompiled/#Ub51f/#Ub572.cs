// Decompiled with JetBrains decompiler
// Type: 딟.땲
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Analytics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace 딟
{
  public class 땲 : 땋
  {
    private const string 딟 = "http://api.mixpanel.com/track/?data={0}&ip=1";
    private const string 땄 = "http://api.mixpanel.com/track/?data={0}&ip=1&test=1";
    private string 딧;
    private bool 딟;

    public 땲([In] string obj0, [In] bool obj1)
    {
      this.딧 = obj0;
      this.딟 = obj1;
    }

    private static string 딧() => ((long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds).ToString();

    private void 땄([In] string obj0, [In] Dictionary<string, string> obj1)
    {
      obj1["token"] = this.딧;
      obj1["distinct_id"] = SystemInfo.deviceUniqueIdentifier;
      obj1["time"] = 땲.딧();
      byte[] bytes = Encoding.UTF8.GetBytes(딧.땾.땄((object) new MixPanelEventData()
      {
        Event = obj0,
        Properties = obj1
      }));
      WWW www = new WWW(string.Format(!this.딟 ? "http://api.mixpanel.com/track/?data={0}&ip=1" : "http://api.mixpanel.com/track/?data={0}&ip=1&test=1", (object) Convert.ToBase64String(bytes)));
    }

    public void 딟()
    {
    }

    public void 땄()
    {
    }

    private Dictionary<string, string> 딟([In] Dictionary<string, string> obj0) => obj0 == null ? new Dictionary<string, string>() : new Dictionary<string, string>((IDictionary<string, string>) obj0);

    public void 딟([In] string obj0, [In] Dictionary<string, string> obj1)
    {
      Dictionary<string, string> dictionary = this.딟(obj1);
      dictionary.Add("Counter", "1");
      this.땄(obj0, dictionary);
    }

    public void 딟([In] string obj0, [In] double obj1, [In] Dictionary<string, string> obj2)
    {
      Dictionary<string, string> dictionary = this.딟(obj2);
      dictionary.Add("Average", obj1.ToString());
      this.땄(obj0, dictionary);
    }

    public void 딟([In] string obj0) => this.땄(obj0, new Dictionary<string, string>());

    public void 딟([In] string obj0, [In] string obj1, [In] string obj2, [In] string obj3) => this.땄("ECommerce", new Dictionary<string, string>()
    {
      {
        "orderId",
        obj0
      },
      {
        "name",
        obj1
      },
      {
        "price",
        obj2
      },
      {
        "currencyCode",
        obj3
      }
    });

    public void 딟([In] string obj0, [In] int obj1, [In] string obj2, [In] string obj3) => this.땄("Timing", new Dictionary<string, string>()
    {
      {
        "category",
        obj0
      },
      {
        "valueMS",
        obj1.ToString()
      },
      {
        "name",
        obj2
      },
      {
        "label",
        obj3
      }
    });
  }
}
