// Decompiled with JetBrains decompiler
// Type: 땺.땴
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 땺
{
  public static class 땴
  {
    private static Dictionary<string, string> 딟;

    public static string 딟([In] this string obj0)
    {
      땴.딟();
      return 땴.딟[obj0];
    }

    public static Color 땄([In] this string obj0)
    {
      if (obj0 == string.Empty)
        return Color.black;
      if (obj0.Length == 3)
      {
        char[] charArray = obj0.ToCharArray();
        obj0 = charArray[0].ToString() + string.Empty + (object) charArray[0] + string.Empty + (object) charArray[1] + string.Empty + (object) charArray[1] + string.Empty + (object) charArray[2] + string.Empty + (object) charArray[2] + string.Empty;
      }
      float num1 = (float) (땴.딟(obj0[0]) * 16 + 땴.딟(obj0[1])) / (float) byte.MaxValue;
      float num2 = (float) (땴.딟(obj0[2]) * 16 + 땴.딟(obj0[3])) / (float) byte.MaxValue;
      float num3 = (float) (땴.딟(obj0[4]) * 16 + 땴.딟(obj0[5])) / (float) byte.MaxValue;
      return new Color()
      {
        r = (__Null) (double) num1,
        g = (__Null) (double) num2,
        b = (__Null) (double) num3,
        a = (__Null) 1.0
      };
    }

    private static int 딟([In] char obj0)
    {
      string upper = obj0.ToString().ToUpper();
      if (upper != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (땴.딟 == null)
        {
          // ISSUE: reference to a compiler-generated field
          땴.딟 = new Dictionary<string, int>(16)
          {
            {
              "0",
              0
            },
            {
              "1",
              1
            },
            {
              "2",
              2
            },
            {
              "3",
              3
            },
            {
              "4",
              4
            },
            {
              "5",
              5
            },
            {
              "6",
              6
            },
            {
              "7",
              7
            },
            {
              "8",
              8
            },
            {
              "9",
              9
            },
            {
              "A",
              10
            },
            {
              "B",
              11
            },
            {
              "C",
              12
            },
            {
              "D",
              13
            },
            {
              "E",
              14
            },
            {
              "F",
              15
            }
          };
        }
        int num;
        // ISSUE: reference to a compiler-generated field
        if (땴.딟.TryGetValue(upper, out num))
        {
          switch (num)
          {
            case 0:
              return 0;
            case 1:
              return 1;
            case 2:
              return 2;
            case 3:
              return 3;
            case 4:
              return 4;
            case 5:
              return 5;
            case 6:
              return 6;
            case 7:
              return 7;
            case 8:
              return 8;
            case 9:
              return 9;
            case 10:
              return 10;
            case 11:
              return 11;
            case 12:
              return 12;
            case 13:
              return 13;
            case 14:
              return 14;
            case 15:
              return 15;
          }
        }
      }
      return 0;
    }

    public static bool 땄([In] this char obj0) => char.IsLetter(obj0) && obj0 != 'e' && obj0 != 'E';

    private static void 딟()
    {
      if (땴.딟 != null)
        return;
      땴.딟 = new Dictionary<string, string>()
      {
        {
          "aliceblue",
          "F0F8FF"
        },
        {
          "antiquewhite",
          "FAEBD7"
        },
        {
          "aqua",
          "00FFFF"
        },
        {
          "aquamarine",
          "7FFFD4"
        },
        {
          "azure",
          "F0FFFF"
        },
        {
          "beige",
          "F5F5DC"
        },
        {
          "bisque",
          "FFE4C4"
        },
        {
          "black",
          "000000"
        },
        {
          "blanchedalmond",
          "FFEBCD"
        },
        {
          "blue",
          "0000FF"
        },
        {
          "blueviolet",
          "8A2BE2"
        },
        {
          "brown",
          "A52A2A"
        },
        {
          "burlywood",
          "DEB887"
        },
        {
          "cadetblue",
          "5F9EA0"
        },
        {
          "chartreuse",
          "7FFF00"
        },
        {
          "chocolate",
          "D2691E"
        },
        {
          "coral",
          "FF7F50"
        },
        {
          "cornflowerblue",
          "6495ED"
        },
        {
          "cornsilk",
          "FFF8DC"
        },
        {
          "crimson",
          "DC143C"
        },
        {
          "cyan",
          "00FFFF"
        },
        {
          "darkblue",
          "00008B"
        },
        {
          "darkcyan",
          "008B8B"
        },
        {
          "darkgoldenrod",
          "B8860B"
        },
        {
          "darkgray",
          "A9A9A9"
        },
        {
          "darkgreen",
          "006400"
        },
        {
          "darkgrey",
          "A9A9A9"
        },
        {
          "darkkhaki",
          "BDB76B"
        },
        {
          "darkmagenta",
          "8B008B"
        },
        {
          "darkolivegreen",
          "556B2F"
        },
        {
          "darkorange",
          "FF8C00"
        },
        {
          "darkorchid",
          "9932CC"
        },
        {
          "darkred",
          "8B0000"
        },
        {
          "darksalmon",
          "E9967A"
        },
        {
          "darkseagreen",
          "8FBC8F"
        },
        {
          "darkslateblue",
          "483D8B"
        },
        {
          "darkslategray",
          "2F4F4F"
        },
        {
          "darkslategrey",
          "2F4F4F"
        },
        {
          "darkturquoise",
          "00CED1"
        },
        {
          "darkviolet",
          "9400D3"
        },
        {
          "deeppink",
          "FF1493"
        },
        {
          "deepskyblue",
          "00BFFF"
        },
        {
          "dimgray",
          "696969"
        },
        {
          "dimgrey",
          "696969"
        },
        {
          "dodgerblue",
          "1E90FF"
        },
        {
          "firebrick",
          "B22222"
        },
        {
          "floralwhite",
          "FFFAF0"
        },
        {
          "forestgreen",
          "228B22"
        },
        {
          "fuchsia",
          "FF00FF"
        },
        {
          "gainsboro",
          "DCDCDC"
        },
        {
          "ghostwhite",
          "F8F8FF"
        },
        {
          "gold",
          "FFD700"
        },
        {
          "goldenrod",
          "DAA520"
        },
        {
          "gray",
          "808080"
        },
        {
          "grey",
          "808080"
        },
        {
          "green",
          "008000"
        },
        {
          "greenyellow",
          "ADFF2F"
        },
        {
          "honeydew",
          "F0FFF0"
        },
        {
          "hotpink",
          "FF69B4"
        },
        {
          "indianred",
          "CD5C5C"
        },
        {
          "indigo",
          "4B0082"
        },
        {
          "ivory",
          "FFFFF0"
        },
        {
          "khaki",
          "F0E68C"
        },
        {
          "lavender",
          "E6E6FA"
        },
        {
          "lavenderblush",
          "FFF0F5"
        },
        {
          "lawngreen",
          "7CFC00"
        },
        {
          "lemonchiffon",
          "FFFACD"
        },
        {
          "lightblue",
          "ADD8E6"
        },
        {
          "lightcoral",
          "F08080"
        },
        {
          "lightcyan",
          "E0FFFF"
        },
        {
          "lightgoldenrodyellow",
          "FAFAD2"
        },
        {
          "lightgray",
          "D3D3D3"
        },
        {
          "lightgreen",
          "90EE90"
        },
        {
          "lightgrey",
          "D3D3D3"
        },
        {
          "lightpink",
          "FFB6C1"
        },
        {
          "lightsalmon",
          "FFA07A"
        },
        {
          "lightseagreen",
          "20B2AA"
        },
        {
          "lightskyblue",
          "87CEFA"
        },
        {
          "lightslategray",
          "778899"
        },
        {
          "lightslategrey",
          "778899"
        },
        {
          "lightsteelblue",
          "B0C4DE"
        },
        {
          "lightyellow",
          "FFFFE0"
        },
        {
          "lime",
          "00FF00"
        },
        {
          "limegreen",
          "32CD32"
        },
        {
          "linen",
          "FAF0E6"
        },
        {
          "magenta",
          "FF00FF"
        },
        {
          "maroon",
          "800000"
        },
        {
          "mediumaquamarine",
          "66CDAA"
        },
        {
          "mediumblue",
          "0000CD"
        },
        {
          "mediumorchid",
          "BA55D3"
        },
        {
          "mediumpurple",
          "9370DB"
        },
        {
          "mediumseagreen",
          "3CB371"
        },
        {
          "mediumslateblue",
          "7B68EE"
        },
        {
          "mediumspringgreen",
          "00FA9A"
        },
        {
          "mediumturquoise",
          "48D1CC"
        },
        {
          "mediumvioletred",
          "C71585"
        },
        {
          "midnightblue",
          "191970"
        },
        {
          "mintcream",
          "F5FFFA"
        },
        {
          "mistyrose",
          "FFE4E1"
        },
        {
          "moccasin",
          "FFE4B5"
        },
        {
          "navajowhite",
          "FFDEAD"
        },
        {
          "navy",
          "000080"
        },
        {
          "oldlace",
          "FDF5E6"
        },
        {
          "olive",
          "808000"
        },
        {
          "olivedrab",
          "6B8E23"
        },
        {
          "orange",
          "FFA500"
        },
        {
          "orangered",
          "FF4500"
        },
        {
          "orchid",
          "DA70D6"
        },
        {
          "palegoldenrod",
          "EEE8AA"
        },
        {
          "palegreen",
          "98FB98"
        },
        {
          "paleturquoise",
          "AFEEEE"
        },
        {
          "palevioletred",
          "DB7093"
        },
        {
          "papayawhip",
          "FFEFD5"
        },
        {
          "peachpuff",
          "FFDAB9"
        },
        {
          "peru",
          "CD853F"
        },
        {
          "pink",
          "FFC0CB"
        },
        {
          "plum",
          "DDA0DD"
        },
        {
          "powderblue",
          "B0E0E6"
        },
        {
          "purple",
          "800080"
        },
        {
          "red",
          "FF0000"
        },
        {
          "rosybrown",
          "BC8F8F"
        },
        {
          "royalblue",
          "4169E1"
        },
        {
          "saddlebrown",
          "8B4513"
        },
        {
          "salmon",
          "FA8072"
        },
        {
          "sandybrown",
          "F4A460"
        },
        {
          "seagreen",
          "2E8B57"
        },
        {
          "seashell",
          "FFF5EE"
        },
        {
          "sienna",
          "A0522D"
        },
        {
          "silver",
          "C0C0C0"
        },
        {
          "skyblue",
          "87CEEB"
        },
        {
          "slateblue",
          "6A5ACD"
        },
        {
          "slategray",
          "708090"
        },
        {
          "slategrey",
          "708090"
        },
        {
          "snow",
          "FFFAFA"
        },
        {
          "springgreen",
          "00FF7F"
        },
        {
          "steelblue",
          "4682B4"
        },
        {
          "tan",
          "D2B48C"
        },
        {
          "teal",
          "008080"
        },
        {
          "thistle",
          "D8BFD8"
        },
        {
          "tomato",
          "FF6347"
        },
        {
          "turquoise",
          "40E0D0"
        },
        {
          "violet",
          "EE82EE"
        },
        {
          "wheat",
          "F5DEB3"
        },
        {
          "white",
          "FFFFFF"
        },
        {
          "whitesmoke",
          "F5F5F5"
        },
        {
          "yellow",
          "FFFF00"
        },
        {
          "yellowgreen",
          "9ACD32"
        }
      };
    }

    public static float 딟([In] Vector2 obj0, [In] Vector2 obj1)
    {
      float num1;
      if (obj1.x - obj0.x == 0.0)
      {
        num1 = obj1.y <= obj0.y ? 3.141593f : 0.0f;
      }
      else
      {
        float num2 = Mathf.Atan((float) ((obj1.y - obj0.y) / (obj1.x - obj0.x)));
        num1 = obj1.x <= obj0.x ? 4.712389f - num2 : 1.570796f - num2;
      }
      return (float) ((double) num1 * 180.0 / 3.14159274101257);
    }
  }
}
