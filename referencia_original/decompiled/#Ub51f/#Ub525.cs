// Decompiled with JetBrains decompiler
// Type: 딟.딥
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace 딟
{
  public static class 딥
  {
    private const int 딟 = 14;
    private const int 땄 = 16384;
    private const int 딧 = 32;
    private const int 딢 = 8192;
    private const int 땃 = 264;
    private static readonly int[] 딟 = new int[16384];

    public static int 딟([In] byte[] obj0, [In] int obj1, [In] byte[] obj2, [In] int obj3, [In] int obj4)
    {
      for (int index = 0; index < 16384; ++index)
        딥.딟[index] = 0;
      int index1 = 0;
      int num1 = obj4;
      int num2 = (int) obj0[index1] << 8 | (int) obj0[index1 + 1];
      int num3 = 0;
label_4:
      do
      {
        if (index1 < obj1 - 2)
        {
          num2 = num2 << 8 | (int) obj0[index1 + 2];
          int index2 = (num2 ^ num2 << 5) >> 10 - num2 * 5 & 16383;
          int index3 = 딥.딟[index2];
          딥.딟[index2] = index1;
          int num4;
          if ((num4 = index1 - index3 - 1) < 8192 && index1 + 4 < obj1 && index3 > 0 && (int) obj0[index3] == (int) obj0[index1] && (int) obj0[index3 + 1] == (int) obj0[index1 + 1] && (int) obj0[index3 + 2] == (int) obj0[index1 + 2])
          {
            int num5 = 2;
            int num6 = obj1 - index1 - num5;
            int num7 = num6 <= 264 ? num6 : 264;
            if (num1 + num3 + 1 + 3 >= obj3)
              return 0;
            do
            {
              ++num5;
            }
            while (num5 < num7 && (int) obj0[index3 + num5] == (int) obj0[index1 + num5]);
            if (num3 != 0)
            {
              obj2[num1++] = (byte) (num3 - 1);
              num3 = -num3;
              do
              {
                obj2[num1++] = obj0[index1 + num3];
              }
              while (++num3 != 0);
            }
            int num8 = num5 - 2;
            int num9 = index1 + 1;
            int num10;
            if (num8 < 7)
            {
              byte[] numArray = obj2;
              int index4 = num1;
              num10 = index4 + 1;
              int num11 = (int) (byte) ((num4 >> 8) + (num8 << 5));
              numArray[index4] = (byte) num11;
            }
            else
            {
              byte[] numArray1 = obj2;
              int index5 = num1;
              int num12 = index5 + 1;
              int num13 = (int) (byte) ((num4 >> 8) + 224);
              numArray1[index5] = (byte) num13;
              byte[] numArray2 = obj2;
              int index6 = num12;
              num10 = index6 + 1;
              int num14 = (int) (byte) (num8 - 7);
              numArray2[index6] = (byte) num14;
            }
            byte[] numArray3 = obj2;
            int index7 = num10;
            num1 = index7 + 1;
            int num15 = (int) (byte) num4;
            numArray3[index7] = (byte) num15;
            int index8 = num9 + (num8 - 1);
            int num16 = ((int) obj0[index8] << 8 | (int) obj0[index8 + 1]) << 8 | (int) obj0[index8 + 2];
            딥.딟[(num16 ^ num16 << 5) >> 10 - num16 * 5 & 16383] = index8;
            int num17 = index8 + 1;
            num2 = num16 << 8 | (int) obj0[num17 + 2];
            딥.딟[(num2 ^ num2 << 5) >> 10 - num2 * 5 & 16383] = num17;
            index1 = num17 + 1;
            continue;
          }
        }
        else if (index1 == obj1)
          goto label_22;
        ++num3;
        ++index1;
      }
      while (num3 != 32);
      if (num1 + 1 + 32 >= obj3)
        return 0;
      obj2[num1++] = (byte) 31;
      num3 = -num3;
      do
      {
        obj2[num1++] = obj0[index1 + num3];
      }
      while (++num3 != 0);
      goto label_4;
label_22:
      if (num3 != 0)
      {
        if (num1 + num3 + 1 >= obj3)
          return 0;
        obj2[num1++] = (byte) (num3 - 1);
        int num18 = -num3;
        do
        {
          obj2[num1++] = obj0[index1 + num18];
        }
        while (++num18 != 0);
      }
      return num1;
    }

    public static int 딟([In] byte[] obj0, [In] int obj1, [In] int obj2, [In] byte[] obj3, [In] int obj4)
    {
      int num1 = obj2;
      int num2 = 0;
      do
      {
        int num3 = (int) obj0[num1++];
        if (num3 < 32)
        {
          int num4 = num3 + 1;
          if (num2 + num4 > obj4)
            return 0;
          do
          {
            obj3[num2++] = obj0[num1++];
          }
          while (--num4 != 0);
        }
        else
        {
          int num5 = num3 >> 5;
          int num6 = num2 - ((num3 & 31) << 8) - 1;
          if (num5 == 7)
            num5 += (int) obj0[num1++];
          int num7 = num6 - (int) obj0[num1++];
          if (num2 + num5 + 2 > obj4 || num7 < 0)
            return 0;
          byte[] numArray1 = obj3;
          int index1 = num2;
          int num8 = index1 + 1;
          byte[] numArray2 = obj3;
          int index2 = num7;
          int num9 = index2 + 1;
          int num10 = (int) numArray2[index2];
          numArray1[index1] = (byte) num10;
          byte[] numArray3 = obj3;
          int index3 = num8;
          num2 = index3 + 1;
          byte[] numArray4 = obj3;
          int index4 = num9;
          int num11 = index4 + 1;
          int num12 = (int) numArray4[index4];
          numArray3[index3] = (byte) num12;
          do
          {
            obj3[num2++] = obj3[num11++];
          }
          while (--num5 != 0);
        }
      }
      while (num1 < obj1);
      return num2;
    }

    public static string 딟([In] string obj0) => Convert.ToBase64String(딥.땄(obj0));

    public static byte[] 땄([In] string obj0)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(obj0);
      byte[] numArray1 = new byte[bytes.Length + 128];
      int length = bytes.Length;
      numArray1[0] = (byte) (length >> 24);
      numArray1[1] = (byte) (length >> 16);
      numArray1[2] = (byte) (length >> 8);
      numArray1[3] = (byte) length;
      int num = 딥.딟(bytes, bytes.Length, numArray1, numArray1.Length, 4);
      byte[] numArray2 = new byte[num + 4];
      Array.Copy((Array) numArray1, (Array) numArray2, num + 4);
      return numArray2;
    }

    public static string 딧([In] string obj0)
    {
      if (obj0 == null)
        return (string) null;
      byte[] numArray;
      try
      {
        numArray = Convert.FromBase64String(obj0);
      }
      catch (FormatException ex)
      {
        return string.Empty;
      }
      int length = ((int) numArray[0] << 24) + ((int) numArray[1] << 16) + ((int) numArray[2] << 8) + (int) numArray[3];
      if (length > 52428800)
        return string.Empty;
      byte[] bytes = new byte[length];
      try
      {
        딥.딟(numArray, numArray.Length - 4, 4, bytes, length);
      }
      catch (IndexOutOfRangeException ex)
      {
        return string.Empty;
      }
      return Encoding.UTF8.GetString(bytes);
    }
  }
}
