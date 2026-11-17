// Decompiled with JetBrains decompiler
// Type: 딟.딮
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace 딟
{
  public static class 딮
  {
    public static Guid 딟([In] string obj0, params object[] pieces)
    {
      MD5 md5 = MD5.Create();
      List<byte[]> numArrayList = new List<byte[]>();
      numArrayList.Add(딮.딟(obj0));
      numArrayList.Add(딮.딟("|"));
      foreach (object piece in pieces)
      {
        switch (piece)
        {
          case Guid guid1:
            numArrayList.Add(딮.딟(guid1));
            break;
          case string str1:
            numArrayList.Add(딮.땄(str1));
            break;
          default:
            return Guid.Empty;
        }
      }
      for (int index = 0; index < numArrayList.Count - 1; ++index)
      {
        byte[] inputBuffer = numArrayList[index];
        md5.TransformBlock(inputBuffer, 0, inputBuffer.Length, (byte[]) null, 0);
      }
      byte[] inputBuffer1 = numArrayList[numArrayList.Count - 1];
      md5.TransformFinalBlock(inputBuffer1, 0, inputBuffer1.Length);
      return 딧.떑.딟(md5.Hash, 3);
    }

    private static byte[] 딟([In] string obj0) => Encoding.ASCII.GetBytes(obj0);

    private static byte[] 땄([In] string obj0) => MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(obj0));

    private static byte[] 딟([In] Guid obj0) => obj0.딟();
  }
}
