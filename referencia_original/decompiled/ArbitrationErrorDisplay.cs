// Decompiled with JetBrains decompiler
// Type: ArbitrationErrorDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using 딶;

public class ArbitrationErrorDisplay : MonoBehaviour
{
  private List<KeyValuePair<string, string>> 딟 = new List<KeyValuePair<string, string>>();

  public void AddError(string sessionId, string error) => this.딟.Add(new KeyValuePair<string, string>(sessionId, error));

  private void OnGUI()
  {
    foreach (KeyValuePair<string, string> keyValuePair in this.딟)
      GUILayout.Box(string.Format("Validation error on session {0} with error {1}", (object) keyValuePair.Key, (object) keyValuePair.Value), new GUILayoutOption[0]);
  }

  public static void 딟([In] 땖 obj0)
  {
    string error = obj0.딟(obj0.딟.딟[0], obj0.딟.딟[1]);
    if (string.IsNullOrEmpty(error))
      return;
    GameObject gameObject = GameObject.Find(nameof (ArbitrationErrorDisplay));
    if (Object.op_Equality((Object) gameObject, (Object) null))
    {
      gameObject = new GameObject(nameof (ArbitrationErrorDisplay));
      gameObject.AddComponent<ArbitrationErrorDisplay>();
    }
    gameObject.GetComponent<ArbitrationErrorDisplay>().AddError(obj0.딟.딧, error);
  }
}
