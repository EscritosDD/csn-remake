// Decompiled with JetBrains decompiler
// Type: 딟.딛
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace 딟
{
  public static class 딛
  {
    private const string 딟 = "SHA1withRSA";

    public static AsymmetricCipherKeyPair 딟([In] int obj0)
    {
      RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
      keyPairGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 1024));
      return keyPairGenerator.GenerateKeyPair();
    }

    public static string 딟<딟>([In] 딟 obj0) where 딟 : class
    {
      StringWriter stringWriter = new StringWriter();
      PemWriter pemWriter = new PemWriter((TextWriter) stringWriter);
      pemWriter.WriteObject((object) obj0);
      pemWriter.Writer.Flush();
      return stringWriter.ToString();
    }

    public static 딟 딟<딟>([In] string obj0) where 딟 : class => new PemReader((TextReader) new StringReader(obj0)).ReadObject() as 딟;

    private static ISigner 딟(
      [In] AsymmetricKeyParameter obj0,
      [In] bool obj1,
      [In] byte[] obj2,
      [In] string obj3)
    {
      ISigner signer = SignerUtilities.GetSigner(obj3);
      signer.Init(obj1, (ICipherParameters) obj0);
      signer.BlockUpdate(obj2, 0, obj2.Length);
      return signer;
    }

    public static byte[] 딟([In] AsymmetricKeyParameter obj0, [In] byte[] obj1) => !obj0.IsPrivate ? (byte[]) null : 딛.딟(obj0, true, obj1, "SHA1withRSA").GenerateSignature();

    public static bool 딟([In] AsymmetricKeyParameter obj0, [In] byte[] obj1, [In] byte[] obj2) => 딛.딟(obj0, false, obj1, "SHA1withRSA").VerifySignature(obj2);

    public static byte[] 딟([In] byte[] obj0, [In] AsymmetricKeyParameter obj1) => obj1.IsPrivate ? (byte[]) null : 딛.딧(obj0, obj1);

    public static byte[] 땄([In] byte[] obj0, [In] AsymmetricKeyParameter obj1) => !obj1.IsPrivate ? (byte[]) null : 딛.딧(obj0, obj1);

    private static byte[] 딧([In] byte[] obj0, [In] AsymmetricKeyParameter obj1)
    {
      RsaEngine rsaEngine = new RsaEngine();
      rsaEngine.Init(!obj1.IsPrivate, (ICipherParameters) obj1);
      int inputBlockSize = rsaEngine.GetInputBlockSize();
      List<byte> byteList = new List<byte>();
      for (int inOff = 0; inOff < obj0.Length; inOff += inputBlockSize)
      {
        int inLen = Math.Min(inputBlockSize, obj0.Length - inOff * inputBlockSize);
        byteList.AddRange((IEnumerable<byte>) rsaEngine.ProcessBlock(obj0, inOff, inLen));
      }
      return byteList.ToArray();
    }
  }
}
