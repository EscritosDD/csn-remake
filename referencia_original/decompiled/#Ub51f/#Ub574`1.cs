// Decompiled with JetBrains decompiler
// Type: 딟.땴`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  public class 땴<딟> where 딟 : Object
  {
    private string 딟;

    public void 딟()
    {
      if (!Object.op_Inequality((Object) (object) this.딧(), (Object) null))
        return;
      if ((object) this.딧() is GameObject)
      {
        if (Application.isEditor)
          Object.DestroyImmediate((Object) (object) this.딧());
        else
          Object.Destroy((Object) (object) this.딧());
      }
      this.딟((딟) null);
    }

    [DebuggerHidden]
    private IEnumerable 딟([In] AssetBundleRequest obj0)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      땴<딟>.\u003CFinishManifestItemLoad\u003Ec__Iterator2 itemLoadCIterator2 = new 땴<딟>.\u003CFinishManifestItemLoad\u003Ec__Iterator2()
      {
        딟 = obj0,
        땄 = obj0
      };
      // ISSUE: reference to a compiler-generated field
      itemLoadCIterator2.딟 = (AssetBundleRequest) -2;
      return (IEnumerable) itemLoadCIterator2;
    }

    private 딟 딟([In] string obj0) => (딟) null;

    public void 딟([In] string obj0, [In] 땟 obj1)
    {
      this.딟 = obj0;
      if (obj1 == null)
      {
        this.딟(this.딟(obj0));
        if (Object.op_Equality((Object) (object) this.딧(), (Object) null))
        {
          Debug.LogWarning((object) ("Failed: " + obj0));
        }
        else
        {
          if (!((object) this.딧() is GameObject))
            return;
          this.딟(Object.Instantiate((Object) (object) this.딧()) as 딟);
          Object.DontDestroyOnLoad((Object) (object) this.딧());
          ((object) this.딧() as GameObject).SetActive(false);
        }
      }
      else if (Object.op_Equality((Object) obj1.딟, (Object) null))
      {
        딧.떀.땄(string.Format("Tried to start load on item({0}) without loading the package({1}) first", (object) obj0, (object) obj1.딟));
      }
      else
      {
        string withoutExtension = Path.GetFileNameWithoutExtension(obj0);
        this.땄(obj1.딟.LoadAsync(withoutExtension, typeof (딟)));
      }
    }

    public bool 땄()
    {
      if (this.딢() == null)
        return true;
      if ((double) ((AsyncOperation) this.딢()).progress == 1.0)
        this.딟(this.딢());
      if (!((AsyncOperation) this.딢()).isDone)
        return false;
      if (Object.op_Equality(this.딢().asset, (Object) null))
      {
        딧.떀.딧(string.Format("Asset({0}) is null", (object) this.딟));
        this.땄((AssetBundleRequest) null);
      }
      else
      {
        if (this.딢().asset is GameObject)
        {
          this.딟(Object.Instantiate(this.딢().asset) as 딟);
          Object.DontDestroyOnLoad((Object) (object) this.딧());
          ((object) this.딧() as GameObject).SetActive(false);
        }
        else
          this.딟(this.딢().asset as 딟);
        this.땄((AssetBundleRequest) null);
      }
      return true;
    }

    [CompilerGenerated]
    [SpecialName]
    public 딟 딧() => (딟) this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] 딟 obj0) => this.딟 = (string) obj0;

    [CompilerGenerated]
    [SpecialName]
    public AssetBundleRequest 딢() => (AssetBundleRequest) this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 땄([In] AssetBundleRequest obj0) => this.딟 = (string) obj0;
  }
}
