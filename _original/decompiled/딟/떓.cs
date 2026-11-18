// Decompiled with JetBrains decompiler
// Type: 딟.떓
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System.Runtime.InteropServices;

namespace 딟
{
  public static class 떓
  {
    public static byte[] 딟([In] byte[] obj0, [In] byte[] obj1)
    {
      PaddedBufferedBlockCipher bufferedBlockCipher = 떓.딟();
      byte[] numArray = new byte[16 + (obj1.Length / 16 + 1) * 16];
      new SecureRandom().NextBytes(numArray, 0, 16);
      ParametersWithIV parametersWithIv = new ParametersWithIV((ICipherParameters) new KeyParameter(obj0), numArray, 0, 16);
      bufferedBlockCipher.Init(true, (ICipherParameters) parametersWithIv);
      bufferedBlockCipher.DoFinal(obj1, numArray, 16);
      return numArray;
    }

    public static byte[] 땄([In] byte[] obj0, [In] byte[] obj1)
    {
      PaddedBufferedBlockCipher bufferedBlockCipher = 떓.딟();
      ParametersWithIV parametersWithIv = new ParametersWithIV((ICipherParameters) new KeyParameter(obj0), obj1, 0, 16);
      bufferedBlockCipher.Init(false, (ICipherParameters) parametersWithIv);
      return bufferedBlockCipher.DoFinal(obj1, 16, obj1.Length - 16);
    }

    private static PaddedBufferedBlockCipher 딟() => new PaddedBufferedBlockCipher((IBlockCipher) new CbcBlockCipher((IBlockCipher) new AesFastEngine()), (IBlockCipherPadding) new Pkcs7Padding());
  }
}
