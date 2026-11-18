// Decompiled with JetBrains decompiler
// Type: AutoLanguageSelection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class AutoLanguageSelection : MonoBehaviour
{
  private void Start() => GlobalAppData.딟("unity_request_language", string.Empty, new Action<object>(this.OnGotLanguage));

  private void OnGotLanguage(object response)
  {
    if (response is string key)
    {
      // ISSUE: reference to a compiler-generated field
      if (AutoLanguageSelection.딟 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AutoLanguageSelection.딟 = new Dictionary<string, int>(11)
        {
          {
            "en",
            0
          },
          {
            "en_GB",
            0
          },
          {
            "en_US",
            0
          },
          {
            "de",
            1
          },
          {
            "es",
            2
          },
          {
            "es_419",
            2
          },
          {
            "fr",
            3
          },
          {
            "it",
            4
          },
          {
            "pt-BR",
            5
          },
          {
            "pt-PT",
            5
          },
          {
            "ru",
            6
          }
        };
      }
      int num;
      // ISSUE: reference to a compiler-generated field
      if (AutoLanguageSelection.딟.TryGetValue(key, out num))
      {
        switch (num)
        {
          case 1:
            딧.딪.딟((SystemLanguage) 15);
            goto label_12;
          case 2:
            딧.딪.딟((SystemLanguage) 34);
            goto label_12;
          case 3:
            딧.딪.딟((SystemLanguage) 14);
            goto label_12;
          case 4:
            딧.딪.딟((SystemLanguage) 21);
            goto label_12;
          case 5:
            딧.딪.딟((SystemLanguage) 28);
            goto label_12;
          case 6:
            딧.딪.딟((SystemLanguage) 30);
            goto label_12;
        }
      }
    }
    딧.딪.딟((SystemLanguage) 10);
label_12:
    Application.LoadLevel(GlobalAppData.딟.EnvSettings.ScenesAsset.Data.땄());
  }
}
