// Decompiled with JetBrains decompiler
// Type: 딟.딗
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using SplashDamage.Mobile.Build;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace 딟
{
  public abstract class 딗
  {
    private const string 딟 = "manifestcache";
    private List<땟> 딟 = new List<땟>();
    private List<땩> 딟 = new List<땩>();
    private List<땩> 땄 = new List<땩>();
    private List<땟> 땄 = new List<땟>();
    private 딗.땳 딟 = new 딗.땳();
    private string 땄;
    private int 딟;
    private 땻 딟;
    private BuildManifestDataJson 딟;
    private string 딧;
    protected 때 딟 = new 때();

    public 딗([In] BuildManifestDataJson obj0, [In] 땻 obj1)
    {
      this.딟 = obj0;
      this.딟 = obj1;
      if (!obj1.딢())
        return;
      this.딟 = obj0.Version;
      string str = 딧.땱.딧("manifestcache");
      if (string.IsNullOrEmpty(str))
        return;
      BuildManifestDataWrapper manifestDataWrapper = 딧.땾.딟<BuildManifestDataWrapper>(str);
      int num = manifestDataWrapper == null || manifestDataWrapper.Base == null || manifestDataWrapper.Game == null ? int.MinValue : manifestDataWrapper.Base.Version;
      if (num <= this.딟)
      {
        딧.땱.땄("manifestcache");
      }
      else
      {
        this.딟(manifestDataWrapper.Base);
        this.딟(manifestDataWrapper.Game);
        this.딟 = num;
      }
    }

    public virtual void 딟()
    {
      this.땃();
      this.땺();
    }

    protected abstract void 땄();

    protected abstract void 딧();

    protected abstract void 딢();

    protected virtual void 딟([In] 땩 obj0)
    {
    }

    protected virtual void 땄([In] 땩 obj0)
    {
    }

    protected abstract void 딟([In] Dictionary<string, object> obj0);

    private void 딟([In] BuildManifestDataJson obj0) => this.딟 = obj0;

    private void 땃()
    {
      this.딟.딟(this.딟.Bundles, this.딟.딧());
      this.딧 = this.딟.CDNUrl + "/" + this.딟.딟();
      this.땄();
    }

    public void 딟([In] string obj0)
    {
      if (!this.딟.딢())
        return;
      this.땄 = obj0;
    }

    private void 딶()
    {
      if (!this.딟.딢() || string.IsNullOrEmpty(this.땄) || this.땤())
        return;
      BuildManifestDataWrapper manifestDataWrapper = 딧.땾.딟<BuildManifestDataWrapper>(this.땄);
      if (manifestDataWrapper == null || manifestDataWrapper.Base == null || manifestDataWrapper.Game == null)
      {
        딧.떀.땄("Invalid Update Manifest");
        this.땄 = (string) null;
      }
      else if (manifestDataWrapper.Base.Version <= this.딟)
      {
        this.땄 = (string) null;
      }
      else
      {
        if (this.딟.딟 != null)
        {
          this.딟.딟.Dispose();
          this.딟.딟();
        }
        딧.땱.땄("manifestcache", this.땄);
        this.땄 = (string) null;
        this.땓();
        this.딟(manifestDataWrapper.Base);
        this.딟(manifestDataWrapper.Game);
        this.땃();
        this.땺();
        this.딢();
      }
    }

    private void 땓()
    {
      this.딧();
      this.딟.딟();
    }

    private void 땺()
    {
      if (!this.딟.딢())
        return;
      this.땄.Clear();
      foreach (땟 땟 in this.딟.딧())
      {
        if (!this.땃(땟))
          this.땄.Add(땟);
      }
    }

    public void 딟<딟>([In] IEnumerable<딟> obj0) where 딟 : 땩
    {
      foreach (딟 딟 in obj0)
        딟.땃();
    }

    public int 딟<딟>([In] IEnumerable<딟> obj0, [In] List<땩> obj1) where 딟 : 땩
    {
      int num = 0;
      foreach (딟 딟 in obj0)
      {
        if (obj1 != null && !obj1.Contains((땩) 딟))
          딟.땃();
        else
          ++num;
      }
      return num;
    }

    public abstract void 딟([In] List<땩> obj0);

    [SpecialName]
    public string 땥() => Application.absoluteURL.Substring(0, Application.absoluteURL.LastIndexOf('/')) + "/StreamingAssets";

    private void 딟([In] 땟 obj0)
    {
      if (this.딟.땃() && obj0.딟)
        this.땄(obj0);
      else
        this.딧(obj0);
      obj0.딟 = DateTime.Now;
    }

    private void 땄([In] 땟 obj0)
    {
      TextAsset textAsset = Resources.Load(obj0.딟, typeof (TextAsset)) as TextAsset;
      if (Object.op_Equality((Object) textAsset, (Object) null))
        return;
      obj0.딟 = new 딱(textAsset);
    }

    private void 딧([In] 땟 obj0)
    {
      string str = !obj0.딟 ? this.딶(obj0) : string.Format("{0}/{1}.assetbundle", (object) this.땥(), (object) obj0.딟);
      딧.떀.딟("Started fetching bundle: " + obj0.딟 + " from " + str + (!obj0.딟 ? " (cdn)" : " (internal)"));
      if (obj0.딟)
        obj0.딟 = new 딱(new WWW(str));
      else
        obj0.딟 = new 딱(WWW.LoadFromCacheOrDownload(str, this.딢(obj0)));
    }

    private int 딢([In] 땟 obj0) => obj0.딟 + this.딟.땄();

    private void 딟([In] 땟 obj0, [In] bool obj1)
    {
      if (!this.딟.딢() || obj0.땄 > 0)
        return;
      ++obj0.땄;
      if (this.딟.Count == 0)
        this.딟(obj0);
      this.딟.Add(obj0);
    }

    public bool 딧([In] 땩 obj0)
    {
      if (obj0.딢())
        return true;
      if (this.딟.딢())
      {
        땟 땟 = obj0.딟();
        if (땟 == null)
          return false;
        this.딟(땟, false);
        if (this.땄.Contains(obj0))
          return true;
        if (!this.딟.Contains(obj0))
          this.딟.Add(obj0);
        if (Object.op_Inequality((Object) 땟.딟, (Object) null))
          this.땥(땟);
        return true;
      }
      this.딟(obj0);
      obj0.딟((땟) null, this);
      obj0.딟(this);
      this.땄(obj0);
      return true;
    }

    public bool 딟([In] IEnumerable<땩> obj0)
    {
      if (obj0 == null)
        return false;
      foreach (땩 땩 in obj0)
      {
        if (땩 != null && !this.딢(땩))
          return false;
      }
      return true;
    }

    public 땟 땄([In] string obj0) => this.딟.딟(obj0);

    public 땟[] 딝() => this.딟.딧().ToArray();

    public bool 딢([In] 땩 obj0) => obj0.딟() != null && this.땃(obj0.딟());

    public bool 땃([In] 땟 obj0) => obj0.딟;

    private string 딶([In] 땟 obj0) => this.딧 + obj0.땄;

    public bool 딟(params 땩[] Items) => this.땄((IEnumerable<땩>) Items);

    public bool 땄([In] IEnumerable<땩> obj0)
    {
      bool flag = true;
      foreach (땩 땩 in obj0)
      {
        if (땩 != null)
          flag &= this.딧(땩);
      }
      return flag;
    }

    public static bool 딟([In] Dictionary<string, int> obj0, [In] Dictionary<string, int> obj1)
    {
      if ((obj0 != null ? obj0.Count : 0) < (obj1 != null ? obj1.Count : 0))
        return false;
      foreach (KeyValuePair<string, int> keyValuePair in obj1)
      {
        int num;
        obj0.TryGetValue(keyValuePair.Key, out num);
        if (num < keyValuePair.Value)
          return false;
      }
      return true;
    }

    [DebuggerHidden]
    private IEnumerable 딟([In] WWW obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      딗.\u003CFinishLoadRequest\u003Ec__Iterator3 requestCIterator3 = new 딗.\u003CFinishLoadRequest\u003Ec__Iterator3()
      {
        딟 = obj0,
        땄 = obj0
      };
      // ISSUE: reference to a compiler-generated field
      requestCIterator3.딟 = -2;
      return (IEnumerable) requestCIterator3;
    }

    private bool 떎()
    {
      List<땩> 땩List = (List<땩>) null;
      for (int index = 0; index < this.땄.Count; ++index)
      {
        if (this.땄[index].딟(this))
        {
          this.땄(this.땄[index]);
          if (땩List == null)
            땩List = new List<땩>();
          땩List.Add(this.땄[index]);
        }
      }
      if (땩List != null)
      {
        foreach (땩 땩 in 땩List)
          this.땄.Remove(땩);
      }
      return this.땄.Count == 0;
    }

    public void 떂()
    {
      WWW 딟 = this.딟.딟;
      if (!string.IsNullOrEmpty(딟.error))
      {
        this.땄.Remove(this.딟.딟);
        this.땄.Add(this.딟.딟);
        딧.떀.땄(딟.error);
        딟.딦.딟("PackageDownloadError", new Dictionary<string, string>()
        {
          {
            "error",
            딟.error
          },
          {
            "url",
            딟.url
          },
          {
            "reach",
            ((int) Application.internetReachability).ToString()
          }
        });
        this.딟.딟();
        this.딟.딟 = DateTime.Now + new TimeSpan(0, 1, 0);
      }
      else
      {
        if ((double) 딟.progress == 1.0)
          this.딟(딟);
        if (!딟.isDone)
          return;
        if (Object.op_Inequality((Object) 딟.assetBundle, (Object) null))
          딟.assetBundle.Unload(true);
        this.땄.Remove(this.딟.딟);
        딧.떀.딟("Completed download for " + this.딟.딟.딟 + " @ " + this.딟.딟.url);
        this.딟.딟();
      }
    }

    public void 땭()
    {
      if (!this.딟.딢())
        return;
      this.딶();
      if (this.딟.딟 != null)
        this.떂();
      else
        this.딦();
      if (this.딟.Count <= 0)
        return;
      this.땺(this.딟[0]);
    }

    private void 딦()
    {
      if (this.땄.Count == 0 || DateTime.Now < this.딟.딟)
        return;
      this.딟.딟 = this.땄[0];
      this.딟.딟 = WWW.LoadFromCacheOrDownload(this.딶(this.딟.딟), this.딢(this.딟.딟));
      딟.딦.딟("PackageDownloadStart", new Dictionary<string, string>()
      {
        {
          "url",
          this.딟.딟.url
        },
        {
          "reach",
          ((int) Application.internetReachability).ToString()
        }
      });
      딧.떀.딟("Starting download for " + this.딟.딟.딟 + " @ " + this.딟.딟.url);
    }

    private void 땓([In] 땟 obj0)
    {
      --obj0.땄;
      if (obj0.땄 != 0)
        return;
      obj0.딟.Unload(false);
      obj0.딟 = (AssetBundle) null;
    }

    private void 땺([In] 땟 obj0)
    {
      if (Object.op_Inequality((Object) obj0.딟, (Object) null))
      {
        if (!this.떎())
          return;
        this.땓(obj0);
        this.딟.Remove(obj0);
        if (this.딟.Count <= 0)
          return;
        this.딟(this.딟[0]);
      }
      else
      {
        if (!obj0.딟.딟())
          return;
        obj0.땄 = DateTime.Now;
        obj0.딟 = obj0.딟.땄();
        obj0.딟.Dispose();
        obj0.딟 = (딱) null;
        this.땥(obj0);
      }
    }

    private void 땥([In] 땟 obj0)
    {
      int index = 0;
      while (index < this.딟.Count)
      {
        if (this.딟[index].딟() == obj0)
        {
          this.딟(this.딟[index]);
          this.딟[index].딟(obj0, this);
          this.땄.Add(this.딟[index]);
          this.딟.RemoveAt(index);
        }
        else
          ++index;
      }
    }

    [SpecialName]
    private bool 땤() => this.딟.Count > 0 || this.땄.Count > 0 || this.딟.Count > 0;

    [SpecialName]
    public bool 땽()
    {
      if (!this.딟.딢())
        return false;
      return this.땤() || !string.IsNullOrEmpty(this.땄);
    }

    [SpecialName]
    public bool 땋() => this.딟.딢() && this.딟.딟 != null;

    public static byte[] 딧([In] string obj0) => new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(obj0));

    public static int 딢([In] string obj0)
    {
      byte[] numArray = 딗.딧(obj0);
      return (int) numArray[0] + ((int) numArray[1] << 8) + ((int) numArray[2] << 16) + ((int) numArray[3] << 24);
    }

    public static string 땃([In] string obj0) => "A" + ((uint) 딗.딢(obj0)).ToString();

    public struct 땳
    {
      public WWW 딟;
      public 땟 딟;
      public DateTime 딟;

      public void 딟()
      {
        if (this.딟 != null)
        {
          this.딟.Dispose();
          this.딟 = (WWW) null;
        }
        this.딟 = (땟) null;
      }
    }
  }
}
