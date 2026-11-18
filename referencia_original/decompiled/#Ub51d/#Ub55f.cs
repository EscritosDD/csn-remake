// Decompiled with JetBrains decompiler
// Type: 딝.땟
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Runtime.InteropServices;
using UnityEngine;

namespace 딝
{
  public static class 땟
  {
    private static Vector3 딟 = new Vector3(-5f, 5f, 0.0f);
    private static Vector3 땄 = new Vector3(5f, 5f, 0.0f);
    private static Vector3 딧 = new Vector3(-5f, 0.0f, 0.0f);
    private static Vector3 딢 = new Vector3(5f, 0.0f, 0.0f);
    private static Vector3 땃 = new Vector3(-5f, -5f, 0.0f);
    private static Vector3 딶 = new Vector3(5f, -5f, 0.0f);

    public static void 딟([In] Vector3 obj0, [In] string obj1) => 땟.딟(obj0, Vector3.one, obj1);

    public static void 딟([In] Vector3 obj0, [In] Vector3 obj1, [In] string obj2)
    {
      Vector3 zero = Vector3.zero;
      for (int index = 0; index < obj2.Length; ++index)
      {
        switch (obj2[index])
        {
          case '0':
            땟.딟(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '1':
            땟.땄(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '2':
            땟.딧(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '3':
            땟.딢(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '4':
            땟.땃(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '5':
            땟.딶(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '6':
            땟.땓(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '7':
            땟.땺(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '8':
            땟.땥(Vector3.op_Addition(obj0, zero), obj1);
            break;
          case '9':
            땟.딝(Vector3.op_Addition(obj0, zero), obj1);
            break;
        }
        ref Vector3 local = ref zero;
        local.x = (__Null) (local.x + 0.300000011920929 * obj1.x);
      }
    }

    private static void 딟([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[4, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.땄,
          땟.딶
        },
        {
          땟.딶,
          땟.땃
        },
        {
          땟.땃,
          땟.딟
        }
      };
      땟.딟(obj0, ref vector3Array, 4, obj1);
    }

    private static void 땄([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[2, 2]
      {
        {
          땟.딧,
          땟.땄
        },
        {
          땟.땄,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 2, obj1);
    }

    private static void 딧([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[5, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.땄,
          땟.딢
        },
        {
          땟.딢,
          땟.딧
        },
        {
          땟.딧,
          땟.땃
        },
        {
          땟.땃,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 5, obj1);
    }

    private static void 딢([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[4, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.땄,
          땟.딶
        },
        {
          땟.딧,
          땟.딢
        },
        {
          땟.땃,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 4, obj1);
    }

    private static void 땃([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[3, 2]
      {
        {
          땟.딢,
          땟.딧
        },
        {
          땟.딧,
          땟.땄
        },
        {
          땟.땄,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 3, obj1);
    }

    private static void 딶([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[5, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.딟,
          땟.딧
        },
        {
          땟.딢,
          땟.딧
        },
        {
          땟.딢,
          땟.딶
        },
        {
          땟.땃,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 5, obj1);
    }

    private static void 땓([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[6, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.딟,
          땟.딧
        },
        {
          땟.딢,
          땟.딧
        },
        {
          땟.딢,
          땟.딶
        },
        {
          땟.땃,
          땟.딶
        },
        {
          땟.땃,
          땟.딧
        }
      };
      땟.딟(obj0, ref vector3Array, 6, obj1);
    }

    private static void 땺([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[2, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.땄,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 2, obj1);
    }

    private static void 땥([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[7, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.딧,
          땟.딢
        },
        {
          땟.땃,
          땟.딶
        },
        {
          땟.딟,
          땟.딧
        },
        {
          땟.땄,
          땟.딢
        },
        {
          땟.딧,
          땟.땃
        },
        {
          땟.딢,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 7, obj1);
    }

    private static void 딝([In] Vector3 obj0, [In] Vector3 obj1)
    {
      Vector3[,] vector3Array = new Vector3[6, 2]
      {
        {
          땟.딟,
          땟.땄
        },
        {
          땟.딧,
          땟.딢
        },
        {
          땟.땃,
          땟.딶
        },
        {
          땟.딟,
          땟.딧
        },
        {
          땟.땄,
          땟.딢
        },
        {
          땟.딢,
          땟.딶
        }
      };
      땟.딟(obj0, ref vector3Array, 6, obj1);
    }

    private static void 딟([In] Vector3 obj0, [In] ref Vector3[,] obj1, [In] int obj2, [In] Vector3 obj3)
    {
      for (int index = 0; index < obj2; ++index)
      {
        ((Vector3) ref obj1.Address(index, 0)).Scale(obj3);
        ((Vector3) ref obj1.Address(index, 1)).Scale(obj3);
        Gizmos.DrawLine(Vector3.op_Addition(obj0, Vector3.op_Multiply(obj1[index, 0], 0.025f)), Vector3.op_Addition(obj0, Vector3.op_Multiply(obj1[index, 1], 0.025f)));
      }
    }
  }
}
