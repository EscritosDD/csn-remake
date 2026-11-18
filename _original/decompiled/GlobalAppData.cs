// Decompiled with JetBrains decompiler
// Type: GlobalAppData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[AddComponentMenu("Scripts/Application/Global App Data")]
public class GlobalAppData : MonoBehaviour
{
  public static GlobalAppState 딟;
  public static bool 딟 = true;
  private static GameObject 딟;
  private static StoreKitManager 딟;
  private static SocialNetworkingManager 딟;
  private static EtceteraManager 딟;
  private static MusicComponent 딟;
  private static MusicComponent 땄;
  private AudioReverbZone 딟;
  public GlobalAppState State;
  private static float 딟;
  public static VersionedGameData 딟;

  public static void 딟([In] string obj0) => 딧.땓.딟(obj0, string.Empty, (Action<object>) null);

  public static void 딟([In] string obj0, [In] string obj1) => 딧.땓.딟(obj0, obj1, (Action<object>) null);

  public static void 딟([In] string obj0, [In] string obj1, [In] Action<object> obj2) => 딧.땓.딟(obj0, obj1, obj2);

  public static void 딟([In] string obj0, [In] string obj1, [In] Action<object> obj2, [In] bool obj3) => 딧.땓.딟(obj0, obj1, obj2, obj3);

  public void ExternalCallComplete(string responseStringBase64) => 딧.땓.딟(responseStringBase64);

  private void Start()
  {
    if (GlobalAppData.딟 != null)
      return;
    this.InitStaticState();
  }

  public void InitStaticState()
  {
    딧.땾.딟((딧.딗) new 땓.땜());
    딧.땾.딟((딧.딾) new 땓.땪());
    GlobalAppData.딟 = this.State;
    GlobalAppData.딟();
    if (GlobalAppData.떏() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.딟(new 땓.땀((EnvironmentSettingsBase) GlobalAppData.딟.EnvSettings));
    }
    if (GlobalAppData.땼() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.딟(new 딢.딛(GlobalAppData.딟.EnvSettings.BuildManifest.BaseJson, GlobalAppData.딟.EnvSettings.BuildManifest.Json, GlobalAppData.딟.EnvSettings.딟()));
      GlobalAppData.땼().딟();
    }
    if (GlobalAppData.땽() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.땄(new 딢.떇());
    }
    if (GlobalAppData.땢() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.딟(new 딢.땐());
    }
    if (GlobalAppData.딷() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.딟(딧.땇.딟("331497870234244", new string[3]
      {
        "publish_actions",
        "publish_stream",
        "email"
      }));
    }
    if (GlobalAppData.떁() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.딟(딧.떃.딟());
    }
    if (Object.op_Equality((Object) GlobalAppData.딟, (Object) null))
    {
      GameObject gameObject = new GameObject("StoreKitManager");
      ((Object) gameObject).hideFlags = (HideFlags) 13;
      GlobalAppData.딟 = gameObject.AddComponent<StoreKitManager>();
    }
    if (Object.op_Equality((Object) GlobalAppData.딟, (Object) null))
    {
      GameObject gameObject = new GameObject("SocialNetworkingManager");
      ((Object) gameObject).hideFlags = (HideFlags) 13;
      GlobalAppData.딟 = gameObject.AddComponent<SocialNetworkingManager>();
    }
    if (Object.op_Equality((Object) GlobalAppData.딟, (Object) null))
    {
      GameObject gameObject = new GameObject("EteceteraManager");
      ((Object) gameObject).hideFlags = (HideFlags) 13;
      GlobalAppData.딟 = gameObject.AddComponent<EtceteraManager>();
    }
    if (GlobalAppData.땋() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.딟(딢.딫.딟((딟.땇) GlobalAppData.떏()));
    }
    if (GlobalAppData.땲() == null)
    {
      // ISSUE: reference to a compiler-generated method
      GlobalAppData.딟(new 땓.땚());
    }
    AudioShader2.딟();
    if (!string.IsNullOrEmpty(GlobalAppData.딧().Fireteam.GoogleAnalyticsAppId))
      딟.딦.딟((딟.땋) new 딟.땺(GlobalAppData.딧().Fireteam.GoogleAnalyticsAppId));
    GlobalAppData.딟("unity_add_fullscreeen_callbacks", string.Empty, new Action<object>(this.OnFullScreenChanged), true);
  }

  private void OnFullScreenChanged(object isFullScreenObj) => GlobalAppData.딧(딧.땾.딟<bool>(isFullScreenObj));

  private void LogToJavaScriptConsole(string message, string stackTrace, LogType type) => GlobalAppData.딟("unity_log_to_js_console", message, (Action<object>) null, false);

  private static bool 땄([In] string obj0)
  {
    string str1 = Application.absoluteURL;
    if (Application.isEditor || Application.absoluteURL.StartsWith("file://"))
      return true;
    if (str1.StartsWith("http://") || str1.StartsWith("https://"))
    {
      if (str1.StartsWith("http://"))
        str1 = str1.Remove(0, 7);
      else if (str1.StartsWith("https://"))
        str1 = str1.Remove(0, 8);
      int startIndex1 = str1.IndexOf("/");
      if (startIndex1 != -1)
        str1 = str1.Remove(startIndex1, str1.Length - startIndex1);
      int startIndex2 = str1.IndexOf(":");
      if (startIndex2 != -1)
        str1 = str1.Remove(startIndex2, str1.Length - startIndex2);
      if (str1 == "localhost")
        return true;
      string str2 = obj0.Remove(0, 7);
      int startIndex3 = str2.IndexOf("/");
      if (startIndex3 != -1)
        str2 = str2.Remove(startIndex3, str2.Length - startIndex3);
      string str3 = str1.Remove(0, str1.Length - str2.Length);
      return str2 == str3;
    }
    Debug.LogError((object) "Failed to parse Application.absoluteURL. This is unexpected and unhandled.");
    return false;
  }

  private static void 딟()
  {
  }

  private void Update()
  {
    GlobalAppData.땄();
    딢.딼.딧();
  }

  public static void 땄()
  {
    ((딟.딗) GlobalAppData.땼()).땭();
    GlobalAppData.떏().딟();
    GlobalAppData.땽().딷();
    GlobalAppData.땢().땄();
    if ((double) Time.time <= (double) GlobalAppData.딟)
      return;
    AudioShader2.딢();
    GlobalAppData.딟 = Time.time + 5f;
  }

  [SpecialName]
  public static EnvironmentSettings 딧() => GlobalAppData.딟.EnvSettings;

  [SpecialName]
  public static VersionedGameData 딢() => GlobalAppData.딟;

  public static UnitBodyType 딧([In] string obj0)
  {
    foreach (UnitBodyType bodyType in GlobalAppData.딟.BodyTypes)
    {
      if (bodyType.Id == obj0)
        return bodyType;
    }
    Debug.LogWarning((object) ("Unknown Bodytype: " + obj0));
    return (UnitBodyType) null;
  }

  public static Transform 딢([In] string obj0)
  {
    foreach (SkeletonInfo skeleton in GlobalAppData.딟.Skeletons)
    {
      if (skeleton.Id == obj0)
        return skeleton.Skel;
    }
    Debug.LogWarning((object) ("Unknown Skeleton: " + obj0));
    return (Transform) null;
  }

  public static void 딟([In] GameObject obj0)
  {
    if (Object.op_Equality((Object) GlobalAppData.딟, (Object) null))
    {
      GlobalAppData.딟 = new GameObject();
      GlobalAppData.딟.AddComponent<DestroyOnLoad>();
    }
    GlobalAppData.딟.GetComponent<DestroyOnLoad>().get_Objects().Add(obj0);
  }

  public static void 땃()
  {
    if (!Object.op_Inequality((Object) GlobalAppData.딟, (Object) null))
      return;
    GlobalAppData.딟.GetComponent<DestroyOnLoad>().Flush();
  }

  public static void 딟([In] 딢.떇 obj0)
  {
    if (GlobalAppData.땽() != null)
      GlobalAppData.땽().Dispose();
    obj0.딟(GlobalAppData.땽().땳());
    GlobalAppData.땽().딟((땄.땙) null);
    // ISSUE: reference to a compiler-generated method
    GlobalAppData.땄(obj0);
  }

  public static void 딶()
  {
    if (!Object.op_Equality((Object) GlobalAppData.딟, (Object) null))
      return;
    GlobalAppData.땥();
    GlobalAppData.딟 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.MusicShaders.MainTheme) as MusicComponent;
    GlobalAppData.딟.Play();
    Object.DontDestroyOnLoad((Object) GlobalAppData.딟);
  }

  public static void 땓()
  {
    if (!Object.op_Equality((Object) GlobalAppData.땄, (Object) null))
      return;
    GlobalAppData.땄 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.MusicShaders.SubTheme) as MusicComponent;
    GlobalAppData.땄.Play();
    Object.DontDestroyOnLoad((Object) GlobalAppData.땄);
  }

  public static void 땺()
  {
    if (!Object.op_Inequality((Object) GlobalAppData.딟, (Object) null) || !GlobalAppData.딝())
      return;
    GlobalAppData.딟.StartFadeOut();
  }

  public static void 땥()
  {
    if (!Object.op_Inequality((Object) GlobalAppData.땄, (Object) null) || !GlobalAppData.떎())
      return;
    GlobalAppData.땄.StartFadeOut();
  }

  public static bool 딝() => Object.op_Inequality((Object) GlobalAppData.딟, (Object) null) && GlobalAppData.딟.IsPlaying();

  public static bool 떎() => Object.op_Inequality((Object) GlobalAppData.땄, (Object) null) && GlobalAppData.땄.IsPlaying();

  public static void 땄([In] GameObject obj0)
  {
    if (!Object.op_Implicit((Object) obj0) || !Object.op_Implicit((Object) obj0.renderer))
      return;
    Object.Destroy((Object) obj0.renderer.material);
  }

  public static void 딟([In] Material obj0) => Object.Destroy((Object) obj0);

  public static void 딟([In] VersionedGameData obj0)
  {
    if (Object.op_Inequality((Object) GlobalAppData.딟, (Object) null) && GlobalAppData.딟.Version > obj0.Version)
      return;
    GlobalAppData.딟 = obj0;
  }

  public static void 딟<딟>([In] 딟[] obj0)
  {
    for (int index1 = 0; index1 < obj0.Length; ++index1)
    {
      int index2 = Random.Range(index1, obj0.Length);
      딟 딟 = obj0[index1];
      obj0[index1] = obj0[index2];
      obj0[index2] = 딟;
    }
  }

  private void OnApplicationPause(bool IsPaused)
  {
    if (!IsPaused)
      return;
    GlobalAppData.땽().땃();
    if (딶.딡.땴() == null)
      return;
    딶.딡.땴().땼().땺();
  }

  public static SinglePlayerMissionAsset 땃([In] string obj0)
  {
    딢.땓 땓 = GlobalAppData.땼().떔(obj0);
    return 땓 != null && 땓.딢() ? 땓.땓() : (SinglePlayerMissionAsset) null;
  }

  public static float 떂() => Input.GetAxis("Mouse ScrollWheel") * -0.01f;

  public static void 딶([In] string obj0) => GlobalAppData.딟("unity_open_url", obj0);

  public static void 땭() => GlobalAppData.딶(GlobalAppData.딧().Fireteam.RequestPasswordURL);

  public static void 딦() => GlobalAppData.딶(GlobalAppData.딧().Fireteam.LostUserNameURL);

  public static void 땤() => GlobalAppData.딟("unity_toggle_fullscreen", string.Empty, (Action<object>) delegate { });

  [CompilerGenerated]
  [SpecialName]
  public static 딢.떇 땽() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static 딢.떅 땋() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static 땓.땚 땲() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static 땓.땀 떏() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static 딢.딛 땼() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static 딢.땐 땢() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static 딧.딨 딷() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static 딧.땦 떁() => GlobalAppData.딟;

  [CompilerGenerated]
  [SpecialName]
  public static bool 땟() => GlobalAppData.땄;

  [CompilerGenerated]
  [SpecialName]
  public static void 딟([In] bool obj0) => GlobalAppData.땄 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public static bool 땂() => GlobalAppData.딧;

  [CompilerGenerated]
  [SpecialName]
  public static void 땄([In] bool obj0) => GlobalAppData.딧 = obj0;

  [CompilerGenerated]
  [SpecialName]
  public static bool 딱() => GlobalAppData.딢;
}
