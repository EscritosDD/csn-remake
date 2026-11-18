// Decompiled with JetBrains decompiler
// Type: 땓.땵
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace 땓
{
  public class 땵
  {
    public 땵([In] NewsDataEntry obj0)
    {
      string type = obj0.Type;
      if (type != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (땵.딟 == null)
        {
          // ISSUE: reference to a compiler-generated field
          땵.딟 = new Dictionary<string, int>(3)
          {
            {
              "news",
              0
            },
            {
              "store",
              1
            },
            {
              "update",
              2
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (땵.딟.TryGetValue(type, out num))
        {
          switch (num)
          {
            case 0:
              // ISSUE: reference to a compiler-generated method
              this.딟(땛.땄);
              goto label_9;
            case 1:
              // ISSUE: reference to a compiler-generated method
              this.딟(땛.딧);
              goto label_9;
            case 2:
              // ISSUE: reference to a compiler-generated method
              this.딟(땛.딢);
              goto label_9;
          }
        }
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(땛.딟);
label_9:
      DateTime? nullable = 딟.땇.딶(obj0.Date);
      // ISSUE: reference to a compiler-generated method
      this.딟(!nullable.HasValue ? DateTime.Now : nullable.Value);
      if (obj0.Text != null)
      {
        switch (딧.딪.땄())
        {
          case 딧.땗.딟:
          case 딧.땗.땺:
            // ISSUE: reference to a compiler-generated method
            this.딟(obj0.Text.English);
            break;
          case 딧.땗.땄:
          case 딧.땗.땥:
            // ISSUE: reference to a compiler-generated method
            this.딟(obj0.Text.French);
            break;
          case 딧.땗.딧:
          case 딧.땗.딝:
            // ISSUE: reference to a compiler-generated method
            this.딟(obj0.Text.German);
            break;
          case 딧.땗.딢:
          case 딧.땗.떎:
            // ISSUE: reference to a compiler-generated method
            this.딟(obj0.Text.Italian);
            break;
          case 딧.땗.땃:
          case 딧.땗.떂:
            // ISSUE: reference to a compiler-generated method
            this.딟(obj0.Text.Spanish);
            break;
          case 딧.땗.딶:
          case 딧.땗.땭:
            // ISSUE: reference to a compiler-generated method
            this.딟(obj0.Text.Russian);
            break;
          case 딧.땗.땓:
          case 딧.땗.딦:
            // ISSUE: reference to a compiler-generated method
            this.딟(obj0.Text.Portuguese);
            break;
        }
      }
      else
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(string.Empty);
      }
    }

    [CompilerGenerated]
    [SpecialName]
    public string 딟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public DateTime 땄() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땛 딧() => this.딟;
  }
}
