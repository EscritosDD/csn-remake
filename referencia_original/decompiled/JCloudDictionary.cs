// Decompiled with JetBrains decompiler
// Type: JCloudDictionary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("")]
public class JCloudDictionary : MonoBehaviour
{
  private static JCloudDictionary 딟;
  private static List<Component> 딟 = new List<Component>();

  public static void 딟([In] string obj0, [In] int obj1) => PlayerPrefs.SetInt(obj0, obj1);

  public static int 땄([In] string obj0, [In] int obj1) => PlayerPrefs.GetInt(obj0, obj1);

  public static int 딟([In] string obj0) => JCloudDictionary.땄(obj0, 0);

  public static void 딟([In] string obj0, [In] float obj1) => PlayerPrefs.SetFloat(obj0, obj1);

  public static float 땄([In] string obj0, [In] float obj1) => PlayerPrefs.GetFloat(obj0, obj1);

  public static float 땄([In] string obj0) => JCloudDictionary.땄(obj0, 0.0f);

  public static void 딟([In] string obj0, [In] string obj1) => PlayerPrefs.SetString(obj0, obj1);

  public static string 땄([In] string obj0, [In] string obj1) => PlayerPrefs.GetString(obj0, obj1);

  public static string 딧([In] string obj0) => JCloudDictionary.땄(obj0, string.Empty);

  public static bool 딢([In] string obj0) => PlayerPrefs.HasKey(obj0);

  public static void 땃([In] string obj0) => PlayerPrefs.DeleteKey(obj0);

  public static void 딟() => PlayerPrefs.DeleteAll();

  public static void 땄() => PlayerPrefs.Save();

  public static bool 딧() => false;

  public static bool 딟([In] Component obj0) => false;

  public static bool 땄([In] Component obj0) => false;

  private void KeyValueStoreDidChangeExternally(string keys)
  {
    if (JCloudDictionary.딟.Count == 0)
      return;
    List<string> stringList = new List<string>();
    string[] strArray = keys.Split('.');
    int length1 = int.Parse(strArray[0]);
    int[] numArray = new int[length1];
    for (int index = 0; index < length1; ++index)
      numArray[index] = int.Parse(strArray[index + 1]);
    int length2 = strArray[0].Length;
    for (int index = 0; index < length1; ++index)
      length2 += strArray[index + 1].Length;
    int startIndex = length2 + (length1 + 1);
    for (int index = 0; index < length1; ++index)
    {
      stringList.Add(keys.Substring(startIndex, numArray[index]));
      startIndex += numArray[index];
    }
    string[] array = stringList.ToArray();
    foreach (Component component in JCloudDictionary.딟)
    {
      if (Object.op_Inequality((Object) component, (Object) null))
        component.SendMessage("JCloudDictionaryDidChangeExternally", (object) array);
    }
  }
}
