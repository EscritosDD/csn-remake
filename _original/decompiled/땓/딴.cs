// Decompiled with JetBrains decompiler
// Type: 땓.딴
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땓
{
  public class 딴 : IDisposable
  {
    private GameObject 딟;
    private List<GameObject> 딟 = new List<GameObject>();

    public 딴([In] GameObject obj0, [In] int obj1)
    {
      this.딟 = obj0;
      this.땄(obj1);
    }

    public GameObject 딟() => this.딟(1)[0];

    public GameObject[] 딟([In] int obj0)
    {
      if (obj0 > this.딟.Count)
        this.땄(obj0 - this.딟.Count);
      GameObject[] gameObjectArray = new GameObject[obj0];
      for (int index = 0; index < obj0; ++index)
      {
        gameObjectArray[index] = this.딟[index];
        gameObjectArray[index].SetActive(true);
      }
      this.딟.RemoveRange(0, obj0);
      return gameObjectArray;
    }

    public void 딟([In] IEnumerable<GameObject> obj0)
    {
      foreach (GameObject gameObject in obj0)
        gameObject.SetActive(false);
      this.딟.AddRange(obj0);
    }

    private void 땄([In] int obj0)
    {
      for (int index = 0; index < obj0; ++index)
      {
        GameObject gameObject = Object.Instantiate((Object) this.딟) as GameObject;
        gameObject.SetActive(false);
        this.딟.Add(gameObject);
      }
    }

    public void Dispose()
    {
      foreach (Object @object in this.딟)
        Object.Destroy(@object);
      this.딟.Clear();
    }
  }
}
