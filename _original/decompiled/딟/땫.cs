// Decompiled with JetBrains decompiler
// Type: 딟.땫
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딟
{
  public class 땫 : IDisposable
  {
    private Dictionary<string, 땆> 딟 = new Dictionary<string, 땆>();
    private float 딟;
    private float 땄 = 1024f;

    public 땫([In] int obj0, [In] 땇 obj1)
    {
      if (obj1 == null)
        throw new ArgumentNullException("Connection");
      this.땄 = (float) obj0;
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
    }

    private float 딟([In] TextureFormat obj0)
    {
      TextureFormat textureFormat = obj0;
      switch (textureFormat - 30)
      {
        case 0:
          return 0.25f;
        case 1:
          return 0.25f;
        case 2:
          return 0.5f;
        case 3:
          return 0.5f;
        case 5:
          return 0.5f;
        case 6:
          return 1f;
        case 7:
          return 16f;
        case 8:
label_8:
          return 0.5f;
        default:
          switch (textureFormat - 1)
          {
            case 0:
              return 1f;
            case 1:
              return 2f;
            case 4:
              return 4f;
            default:
              switch (textureFormat - 10)
              {
                case 0:
                  goto label_8;
                case 2:
                  return 1f;
                default:
                  return 4f;
              }
          }
      }
    }

    public void Dispose()
    {
      foreach (KeyValuePair<string, 땆> keyValuePair in this.딟)
        keyValuePair.Value.Dispose();
      this.딟.Clear();
      this.딟 = 0.0f;
    }

    public void 딟([In] string obj0)
    {
      땆 땆;
      if (!this.딟.TryGetValue(obj0, out 땆))
        return;
      if (Object.op_Inequality((Object) 땆.딟(), (Object) null))
        this.딟 -= (float) ((double) (((Texture) 땆.딟()).width * ((Texture) 땆.딟()).height) * (double) this.딟(땆.딟().format) / 1024.0);
      땆.Dispose();
      this.딟.Remove(obj0);
    }

    public bool 딟() => true;

    public bool 땄() => !this.딟() && (double) this.딟 > (double) this.땄;

    public void 딟([In] string obj0, [In] Action obj1, [In] Action<Texture2D> obj2)
    {
      if (obj1 == null)
        throw new ArgumentNullException("OnRequestFailure");
      if (obj2 == null)
        throw new ArgumentNullException("OnRequestSuccess");
      if (!Uri.IsWellFormedUriString(obj0, UriKind.Absolute))
      {
        Debug.LogWarning((object) ("URL not well formed: " + obj0));
        obj1();
      }
      else
      {
        땆 땆1;
        if (!this.딟.TryGetValue(obj0, out 땆1))
        {
          땆 땆2 = new 땆(this);
          땆2.딟(obj1);
          땆2.딟(obj2);
          땆2.딟(obj0);
          this.딟.Add(obj0, 땆2);
        }
        else if (Object.op_Equality((Object) 땆1.딟(), (Object) null))
        {
          땆1.딟(obj1);
          땆1.딟(obj2);
        }
        else
          obj2(땆1.딟());
      }
    }

    internal void 딟([In] 땆 obj0)
    {
      if (this.딧(obj0).Value == null)
        obj0.Dispose();
      else
        this.딟 += (float) ((double) (((Texture) obj0.딟()).width * ((Texture) obj0.딟()).height) * (double) this.딟(obj0.딟().format) / 1024.0);
    }

    internal void 땄([In] 땆 obj0)
    {
      KeyValuePair<string, 땆> keyValuePair = this.딧(obj0);
      if (keyValuePair.Value == null)
        return;
      this.딟.Remove(keyValuePair.Key);
    }

    private KeyValuePair<string, 땆> 딧([In] 땆 obj0) => this.딟.FirstOrDefault<KeyValuePair<string, 땆>>(new Func<KeyValuePair<string, 땆>, bool>(new 땫.딼()
    {
      딟 = obj0
    }.딟));

    [CompilerGenerated]
    [SpecialName]
    internal 땇 딧() => this.딟;
  }
}
