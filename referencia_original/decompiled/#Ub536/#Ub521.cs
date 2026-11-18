// Decompiled with JetBrains decompiler
// Type: 딶.딡
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace 딶
{
  public class 딡
  {
    private SendingTurnOverlayHandler 딟;
    private AIThinkingOverlayHandler 딟;
    private FakeLoadingScreen 딟;
    public CameraController 딟;
    public AudioController 딟;
    private float 딟;

    public void 딟([In] 땖 obj0, [In] GameplayHUDHandler obj1, [In] bool obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(obj1);
      // ISSUE: reference to a compiler-generated method
      this.딟(obj0);
      if (this.떁() == null)
      {
        // ISSUE: reference to a compiler-generated method
        this.딟(new 땃.딗(this));
      }
      obj0.딟(this);
      if (!obj2)
        return;
      this.딟(true);
    }

    [SpecialName]
    public bool 딟() => this.땼().떁();

    public void 딟([In] bool obj0)
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(new 땯(this));
      this.딷().딟(obj0);
      this.땄(true);
    }

    public void 땄([In] bool obj0)
    {
      if (!obj0)
        return;
      this.딷().딝();
    }

    public void 땄()
    {
      if (this.딗())
        return;
      if (this.딷() != null)
        this.딷().땤();
      if (!Object.op_Inequality((Object) this.딟, (Object) null))
        return;
      this.딟.UpdateAudio();
    }

    public void 딟([In] GameTileComponent obj0) => this.딷().딟(obj0);

    public void 땄([In] GameTileComponent obj0) => this.딷().딶(obj0);

    public void 딟([In] 땓.땦 obj0, [In] bool obj1) => this.딷().딟(obj0, obj1, false);

    public void 딟([In] 땓.땦 obj0) => this.딷().딧(obj0);

    public void 땄([In] 땓.땦 obj0) => this.딷().딢(obj0);

    public void 딟([In] int obj0, [In] 땮 obj1) => this.딷().딟(obj0, obj1);

    public void 딧() => this.땄(false);

    public void 딢() => this.땄(true);

    public void 딟([In] bool obj0, [In] bool obj1)
    {
      // ISSUE: reference to a compiler-generated method
      this.딝(obj0);
      if (!obj1)
        return;
      this.딧(this.딗());
    }

    public void 딧([In] bool obj0)
    {
      if (obj0)
      {
        this.딟 = Time.timeScale;
        Time.timeScale = 0.0f;
      }
      else
        Time.timeScale = this.딟;
    }

    public void 땃()
    {
      Time.timeScale += 0.05f;
      Debug.Log((object) ("Incr Timescale: " + Time.timeScale.ToString()));
    }

    public void 딶()
    {
      Time.timeScale -= 0.05f;
      Debug.Log((object) ("Decr Timescale: " + Time.timeScale.ToString()));
    }

    [SpecialName]
    public GameGridComponent 땓() => this.땼().땹();

    public bool 땺() => Object.op_Inequality((Object) this.딟, (Object) null);

    private void 땥()
    {
      GameObject gameObject = GameObject.Find("UICamera");
      this.땼().떔().딝();
      this.딟 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.SendingTurnOverlayPrefab) as SendingTurnOverlayHandler;
      ((Component) this.딟).transform.parent = gameObject.transform;
      if (this.땼().떔() is 딖)
        ((Component) this.딟).transform.localPosition = new Vector3(0.0f, 0.0f, 0.8f);
      else
        ((Component) this.딟).transform.localPosition = new Vector3(0.0f, -0.362f, 0.75f);
    }

    private void 딝()
    {
      GameObject gameObject = GameObject.Find("UICamera");
      this.땼().떔().딝();
      if (this.땼().떔() is 딖)
        return;
      this.딟 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.FakeLoadingScreen) as FakeLoadingScreen;
      this.딟.ActivateMenu(this.땼(), false);
      ((Component) this.딟).transform.parent = gameObject.transform;
      ((Component) this.딟).transform.localPosition = new Vector3(0.0f, 0.0f, 1.75f);
    }

    public void 딟([In] 땙 obj0, [In] 땙 obj1, [In] bool obj2)
    {
      this.딝();
      this.땥();
      땓.땈 MsgType = !obj2 ? 땓.땈.딟 : 땓.땈.땄;
      this.딟.Init(this.땼(), MsgType, obj0, obj1, obj2);
      this.딟.SaveSettings();
    }

    public void 떎()
    {
      this.딝();
      this.땥();
      this.딟.Init(this.땼(), 땓.땈.땄, true);
      this.딟.SaveSettings();
    }

    private void 딟([In] GlobalAppState.땊 obj0)
    {
      if (Object.op_Inequality((Object) this.땢(), (Object) null))
        this.땢().CloseAllHUDGridsOnEndTurn();
      this.딝();
      this.땥();
      this.딟.Init(this.땼(), obj0);
    }

    public void 딢([In] bool obj0)
    {
      if (Object.op_Inequality((Object) this.땢(), (Object) null))
        this.땢().CloseAllHUDGridsOnEndTurn();
      EventTimelineManager.딟().RunToEnd(false);
      this.딝();
      this.땥();
      this.딟.Init(this.땼(), 땓.땈.딧, false, !obj0);
      this.땼().땺();
      this.딟.SaveSettings();
    }

    public void 떂()
    {
      if (Object.op_Inequality((Object) this.땢(), (Object) null))
        this.땢().CloseAllHUDGridsOnEndTurn();
      this.땼().딶();
      this.딷().딢();
    }

    public void 땭() => this.딢(false);

    public void 딦()
    {
      this.딝();
      this.땥();
      this.딟.InitEndGame(this.땼(), 땓.땈.딧);
    }

    public bool 땤() => Object.op_Inequality((Object) this.딟, (Object) null);

    public void 땽()
    {
      GameObject gameObject = GameObject.Find("UICamera");
      this.딟 = Object.Instantiate((Object) GlobalAppData.딟.GameAssets.AIThinkingOverlayPrefab) as AIThinkingOverlayHandler;
      ((Component) this.딟).transform.parent = gameObject.transform;
      ((Component) this.딟).transform.localPosition = new Vector3(0.0f, 0.0f, 0.75f);
      this.딟.Init();
      this.땢().DeactivateGameplayHUD();
    }

    public void 땋()
    {
      if (!this.땤())
        return;
      this.딟.Close();
    }

    public void 땲()
    {
      if (this.딷() == null)
        return;
      this.딷().딗();
      // ISSUE: reference to a compiler-generated method
      this.딟((땯) null);
    }

    public bool 떏() => this.딷() == null;

    public static void 딟([In] string obj0_1)
    {
      Dictionary<string, int> dictionary1 = new Dictionary<string, int>();
      int num = 0;
      foreach (object obj in Resources.FindObjectsOfTypeAll(typeof (Object)))
      {
        string key1 = obj.GetType().ToString();
        if (string.IsNullOrEmpty(obj0_1) || obj0_1 == key1)
        {
          if (dictionary1.ContainsKey(key1))
          {
            Dictionary<string, int> dictionary2;
            string key2;
            (dictionary2 = dictionary1)[key2 = key1] = dictionary2[key2] + 1;
          }
          else
            dictionary1.Add(key1, 1);
          ++num;
        }
      }
      List<KeyValuePair<string, int>> keyValuePairList = new List<KeyValuePair<string, int>>((IEnumerable<KeyValuePair<string, int>>) dictionary1);
      keyValuePairList.Sort((Comparison<KeyValuePair<string, int>>) ((obj0_2, obj1) => obj1.Value.CompareTo(obj0_2.Value)));
      Debug.Log((object) "-----------------------------------------------------------------------------------------------------");
      Debug.Log((object) ("TOTAL OBJECT TYPES: " + (object) dictionary1.Count));
      if (!string.IsNullOrEmpty(obj0_1))
        Debug.Log((object) ("REQUIRED TYPE: " + obj0_1));
      Debug.Log((object) ("TOTAL OBJECT COUNT: " + (object) num));
      for (int index = 0; index < keyValuePairList.Count; ++index)
      {
        KeyValuePair<string, int> keyValuePair = keyValuePairList[index];
        Debug.Log((object) ("\t\t " + keyValuePair.Key.ToString() + "Count: " + keyValuePair.Value.ToString()));
      }
    }

    public void 딟([In] 딟.딽 obj0)
    {
      if (obj0 != 딟.딽.딟)
        return;
      Debug.Log((object) ("In-Game Notification: " + (object) obj0));
    }

    [CompilerGenerated]
    [SpecialName]
    public 땖 땼() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public GameplayHUDHandler 땢() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땯 딷() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public 땃.딗 떁() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public Vector3 땟() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 딟([In] Vector3 obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땂() => this.딟;

    [CompilerGenerated]
    [SpecialName]
    public void 땃([In] bool obj0) => this.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 딱() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public void 딶([In] bool obj0) => this.땄 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 때() => this.딧;

    [CompilerGenerated]
    [SpecialName]
    public void 땓([In] bool obj0) => this.딧 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땩() => this.딢;

    [CompilerGenerated]
    [SpecialName]
    public void 땺([In] bool obj0) => this.딢 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 땠() => this.땃;

    [CompilerGenerated]
    [SpecialName]
    public void 땥([In] bool obj0) => this.땃 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public static 딡 땴() => 딡.딟;

    [CompilerGenerated]
    [SpecialName]
    public static void 딟([In] 딡 obj0) => 딡.딟 = obj0;

    [CompilerGenerated]
    [SpecialName]
    public bool 딗() => this.딶;
  }
}
