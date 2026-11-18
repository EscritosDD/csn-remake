// Decompiled with JetBrains decompiler
// Type: 땺.떀
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땺
{
  [DefaultMember("Item")]
  public class 떀 : IEnumerable, ICollection<딲>, IEnumerable<딲>
  {
    private List<딲> 딟;
    private bool 딟;

    public 떀() => this.딟 = new List<딲>();

    IEnumerator IEnumerable.딟() => (IEnumerator) this.딟.GetEnumerator();

    [SpecialName]
    public 딲 딟([In] int obj0) => this.딟[obj0];

    [SpecialName]
    public void 딟([In] int obj0, [In] 딲 obj1)
    {
      if (obj1 == (딲) null)
        throw new ArgumentNullException();
      if (obj0 >= this.딟.Count)
        throw new IndexOutOfRangeException();
      if ((double) this.딟[obj0].땄() == (double) obj1.땄())
      {
        this.딟[obj0] = obj1;
      }
      else
      {
        this.딟.RemoveAt(obj0);
        this.딟.Add(obj1);
      }
    }

    [SpecialName]
    public int get_Count() => this.딟.Count;

    [SpecialName]
    public bool get_IsReadOnly() => this.딟;

    public void Add([In] 딲 obj0)
    {
      if (obj0 == (딲) null)
        throw new ArgumentNullException("Value cannot be null.", (Exception) null);
      if (this.딟.Count == 0)
      {
        this.딟.Add(obj0);
      }
      else
      {
        for (int index = 0; index < this.딟.Count; ++index)
        {
          if ((double) obj0.땄() < (double) this.딟[index].땄())
          {
            this.딟.Insert(index, obj0);
            return;
          }
        }
        this.딟.Add(obj0);
      }
    }

    public void Clear() => this.딟.Clear();

    public bool Contains([In] 딲 obj0) => this.딟.Contains(obj0);

    public void CopyTo([In] 딲[] obj0, [In] int obj1) => this.딟.CopyTo(obj0, obj1);

    public IEnumerator<딲> GetEnumerator() => (IEnumerator<딲>) this.딟.GetEnumerator();

    public bool Remove([In] 딲 obj0) => this.딟.Remove(obj0);

    public 떀 땄()
    {
      떀 떀 = new 떀();
      foreach (딲 딲 in this.딟)
        떀.Add(딲);
      return 떀;
    }

    public int 딟([In] 딲 obj0) => this.딟.IndexOf(obj0);

    public void 땄([In] int obj0)
    {
      if (obj0 == this.get_Count() || obj0 <= -1)
        throw new ArgumentOutOfRangeException("Index was out of range. Must be non-negative and less than the size of the collection.\r\nParameter name: index", (Exception) null);
      this.딟.RemoveAt(obj0);
    }
  }
}
