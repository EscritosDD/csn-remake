// Decompiled with JetBrains decompiler
// Type: 딧.떑
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace 딧
{
  public static class 떑
  {
    public static readonly Guid 딟 = new Guid("6ba7b810-9dad-11d1-80b4-00c04fd430c8");
    public static readonly Guid 땄 = new Guid("6ba7b811-9dad-11d1-80b4-00c04fd430c8");
    public static readonly Guid 딧 = new Guid("6ba7b812-9dad-11d1-80b4-00c04fd430c8");

    public static Guid 딟([In] Guid obj0, [In] string obj1) => 떑.딟(obj0, obj1, 땎.땄);

    private static HashAlgorithm 딟([In] 땎 obj0)
    {
      switch (obj0)
      {
        case 땎.딟:
          return (HashAlgorithm) MD5.Create();
        default:
          return (HashAlgorithm) SHA1.Create();
      }
    }

    public static Guid 딟([In] Guid obj0, [In] string obj1, [In] 땎 obj2)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(obj1);
      byte[] inputBuffer = obj0.딟();
      byte[] hash;
      using (HashAlgorithm hashAlgorithm = 떑.딟(obj2))
      {
        hashAlgorithm.TransformBlock(inputBuffer, 0, inputBuffer.Length, (byte[]) null, 0);
        hashAlgorithm.TransformFinalBlock(bytes, 0, bytes.Length);
        hash = hashAlgorithm.Hash;
      }
      return 떑.딟(hash, (int) obj2);
    }

    public static Guid 딟([In] byte[] obj0, [In] int obj1)
    {
      byte[] numArray = obj0.Clone() as byte[];
      numArray[6] = (byte) ((int) numArray[6] & 15 | obj1 << 4);
      numArray[8] = (byte) ((int) numArray[8] & 63 | 128);
      return 딺.땄(numArray);
    }
  }
}
