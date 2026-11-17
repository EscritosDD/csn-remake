// Decompiled with JetBrains decompiler
// Type: EventTimelineManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EventTimelineManager : MonoBehaviour
{
  private 땓.딟 딟;
  private List<GameObject> 딟;

  [CompilerGenerated]
  [SpecialName]
  public static EventTimelineManager 딟() => EventTimelineManager.딟;

  public void AddEvent(딶.땏 evt)
  {
    if (evt == null)
      return;
    if (this.딟 == null)
      this.딟 = new 땓.딟();
    this.딟.딟(evt);
  }

  public void AddEventTimeline(땓.딟 timeline)
  {
    if (this.딟 != null)
    {
      this.딟.딟(timeline);
      this.딟.딟(timeline.땄());
    }
    else
      this.딟 = timeline;
  }

  public bool IsRunning() => this.딟 != null;

  public bool IsEmpty() => this.딟 == null || this.딟.딧();

  public void RunToEnd(bool inGame)
  {
    if (this.딟 == null)
      return;
    this.딟.땄(inGame);
    this.딟 = (땓.딟) null;
  }

  public void OnCinematicEvent(int gameObjectIndex, 딶.땮 eventType)
  {
    if (this.딟 == null)
      return;
    this.딟.딟(gameObjectIndex, eventType);
  }

  public void AddTempVisualEffect(GameObject GO) => this.딟.Add(GO);

  public void DestroyTempVisualEffects()
  {
    for (int index = 0; index != this.딟.Count; ++index)
    {
      if (Object.op_Inequality((Object) this.딟[index], (Object) null))
        Object.Destroy((Object) this.딟[index]);
    }
    this.딟.Clear();
  }

  public bool IsCurrentTimelineSkippable() => this.딟 == null || this.딟.땄();

  private void Awake()
  {
    if (Object.op_Inequality((Object) EventTimelineManager.딟(), (Object) null))
    {
      Debug.LogError((object) "There is already an EventTimelineManager running, aborting");
      Object.Destroy((Object) ((Component) this).gameObject);
    }
    else
    {
      // ISSUE: reference to a compiler-generated method
      EventTimelineManager.딟(this);
      this.딟 = new List<GameObject>();
    }
  }

  private void Update()
  {
    if (this.딟 == null)
      return;
    this.딟.땃();
    if (!this.딟.딶())
      return;
    this.딟.딢();
    this.딟 = (땓.딟) null;
    딶.딡.땴().딟.ClearCinematics();
  }
}
