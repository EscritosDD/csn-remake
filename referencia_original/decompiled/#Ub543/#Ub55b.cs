// Decompiled with JetBrains decompiler
// Type: 땃.땛
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땃
{
  public class 땛
  {
    private 떉 딟;
    private 떈 딟;
    private 떄 딟;
    private List<떈> 딟;
    private float 딟 = 0.015f;
    private float 땄;
    private float 딧 = 0.1f;
    private float 딢;
    private 땛.땵 딟;
    private 땛.떐 딟;

    public void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 딹 obj2, [In] 땨 obj3, [In] 떈 obj4)
    {
      this.딟(obj0, obj1, obj4);
      this.딢 = Time.realtimeSinceStartup;
      if (obj2 == 딹.딟)
        this.딟 = new 땛.땵(딙.딟);
      if (obj3 != 땨.딟)
        return;
      this.딟 = new 땛.떐(땒.딟);
    }

    public 떌 딟()
    {
      this.땄 = 0.0f;
      while (this.딧() && !this.땃())
      {
        this.딟 = new List<떈>();
        this.딟.Add(this.딟.딟);
        this.딟 = this.딟(this.딟.딟);
        this.딟 = this.땄(this.딟);
        this.딟(this.딟);
        this.땄 += Time.deltaTime;
      }
      if (this.딧())
        return (떌) null;
      Debug.Log((object) ("Time used: " + (object) (float) ((double) Time.realtimeSinceStartup - (double) this.딢)));
      return this.땄();
    }

    private 떌 땄()
    {
      int index1 = -1;
      float num1 = -1f;
      for (int index2 = 0; index2 < this.딟.딟.딟().Count; ++index2)
      {
        float num2 = this.딟.딟.딟()[index2].딟.딶();
        if ((double) num2 > (double) num1)
        {
          index1 = index2;
          num1 = num2;
        }
      }
      return this.딟.딟.딟()[index1];
    }

    private void 딟([In] 떉 obj0)
    {
      for (int index = this.딟.Count - 1; index >= 0; --index)
        this.딟[index].땄(obj0);
    }

    private 떈 딟([In] 떈 obj0)
    {
      if (obj0 == null)
        return (떈) null;
      List<떌> 떌List = obj0.땓();
      if (떌List.Count > 0)
      {
        int index = Random.Range(0, 떌List.Count - 1);
        떈 딟 = 떌List[index].딟;
        this.딟.Add(딟);
        return 딟;
      }
      떈 떈 = this.딟(obj0);
      if (떈 == null)
        return obj0;
      this.딟.Add(떈);
      return this.딟(떈);
    }

    private 떉 땄([In] 떈 obj0) => this.딟.딟(this.딧(obj0));

    private 떈 딧([In] 떈 obj0)
    {
      if (obj0.땃())
        return obj0;
      떈 떈 = this.딟(obj0);
      return 떈 != null ? this.딧(떈) : obj0;
    }

    private bool 딧() => !this.딢();

    private bool 딢() => (double) this.딢 + (double) this.딧 < (double) Time.realtimeSinceStartup;

    private bool 땃() => (double) this.땄 > (double) this.딟;

    private void 딟([In] 딶.땖 obj0, [In] 딶.땙 obj1, [In] 떈 obj2) => this.딟 = new 떄(obj0, obj1, obj2);

    [CompilerGenerated]
    [SpecialName]
    public 떌 딶() => this.딟;

    private delegate 떈 땵([In] 떈 obj0);

    private delegate 떈 떐([In] 떈 obj0);
  }
}
