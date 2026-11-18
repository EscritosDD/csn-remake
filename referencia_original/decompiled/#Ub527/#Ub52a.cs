// Decompiled with JetBrains decompiler
// Type: 딧.딪
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딧
{
  public class 딪
  {
    public const string 딟 = "<unknown>";
    private static 땗 딟 = 땗.땤;

    public static string 딟([In] LocalisationEntry obj0, params object[] Args) => Object.op_Equality((Object) obj0, (Object) null) ? "<unknown>" : obj0.딟(딪.땄(), Args);

    public static void 딟()
    {
      int num = (int) (딪.딟 + 1);
      if (num == 14)
        num = 0;
      딪.딟 = (땗) num;
      떀.딟(딪.딟.ToString());
    }

    public static string 딟([In] 땗 obj0)
    {
      switch (obj0)
      {
        case 땗.딟:
        case 땗.땺:
          return "en";
        case 땗.땄:
        case 땗.땥:
          return "fr";
        case 땗.딧:
        case 땗.딝:
          return "de";
        case 땗.딢:
        case 땗.떎:
          return "it";
        case 땗.땃:
        case 땗.떂:
          return "es";
        case 땗.딶:
        case 땗.땭:
          return "ru";
        case 땗.땓:
        case 땗.딦:
          return "pt-BR";
        default:
          throw new ArgumentException("Unknown Language", "Language");
      }
    }

    public static void 딟([In] SystemLanguage obj0)
    {
      SystemLanguage systemLanguage = obj0;
      switch (systemLanguage - 10)
      {
        case 0:
label_10:
          딪.땄(땗.땺);
          break;
        case 4:
          딪.땄(땗.땥);
          break;
        case 5:
          딪.땄(땗.딝);
          break;
        default:
          switch (systemLanguage - 28)
          {
            case 0:
              딪.땄(땗.딦);
              return;
            case 2:
              딪.땄(땗.땭);
              return;
            default:
              if (systemLanguage != 21)
              {
                if (systemLanguage == 34)
                {
                  딪.땄(땗.떂);
                  return;
                }
                goto label_10;
              }
              else
              {
                딪.땄(땗.떎);
                return;
              }
          }
      }
    }

    [SpecialName]
    public static 땗 땄()
    {
      if (딪.딟 == 땗.땤)
        딪.딟(Application.systemLanguage);
      return 딪.딟;
    }

    [SpecialName]
    public static void 땄([In] 땗 obj0) => 딪.딟 = obj0;
  }
}
