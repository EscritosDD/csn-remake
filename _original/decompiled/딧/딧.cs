// Decompiled with JetBrains decompiler
// Type: 딧.딧
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C4E058C3-52EE-49D9-9B60-4517452EDFF8
// Assembly location: C:\Users\Flo\Desktop\Neuer Ordner (2)\TacticsGame.unity3d_unpacked\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace 딧
{
  public class 딧 : IDisposable, 딝
  {
    public const string 딟 = "HTTP/1.1";
    public byte[] 딟;
    public static byte[] 땄 = new byte[2]
    {
      (byte) 13,
      (byte) 10
    };
    public int 딟 = 8;
    public Exception 딟;
    private Uri 딟;
    private bool 딟;
    private Dictionary<string, List<string>> 딟 = new Dictionary<string, List<string>>();

    public 딧([In] string obj0, [In] string obj1, [In] byte[] obj2)
    {
      // ISSUE: reference to a compiler-generated method
      this.땄(obj0);
      this.딟 = new Uri(obj1);
      this.딟 = obj2;
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
    }

    public string 딟([In] string obj0)
    {
      obj0 = obj0.ToLower().Trim();
      return !this.딟.ContainsKey(obj0) ? string.Empty : this.딟[obj0][0];
    }

    public void 딟([In] string obj0, [In] string obj1)
    {
      obj0 = obj0.ToLower().Trim();
      obj1 = obj1.Trim();
      if (!this.딟.ContainsKey(obj0))
        this.딟[obj0] = new List<string>();
      this.딟[obj0].Clear();
      this.딟[obj0].Add(obj1);
    }

    private void 딟([In] object obj0)
    {
      try
      {
        int num = 0;
        while (++num < this.딟)
        {
          if (!this.딟)
          {
            this.딟("Host", this.딟.Host);
            TcpClient tcpClient = new TcpClient();
            tcpClient.NoDelay = true;
            tcpClient.SendTimeout = 20000;
            tcpClient.ReceiveTimeout = 20000;
            tcpClient.Connect(this.딟.Host, this.딟.Port);
            using (NetworkStream stream1 = tcpClient.GetStream())
            {
              Stream stream2 = (Stream) stream1;
              if (this.딟.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
              {
                stream2 = (Stream) new SslStream((Stream) stream1, false, new RemoteCertificateValidationCallback(딧.딧.딟));
                (stream2 as SslStream).AuthenticateAsClient(this.딟.Host);
              }
              this.딟(stream2);
              딧.딢 딢 = new 딧.딢();
              딢.딧(stream2);
              // ISSUE: reference to a compiler-generated method
              this.딟((땥) 딢);
            }
            tcpClient.Close();
            switch (this.딢().딟())
            {
              case HttpStatusCode.MovedPermanently:
              case HttpStatusCode.Found:
              case HttpStatusCode.TemporaryRedirect:
                this.딟 = new Uri(this.딢().딟("Location"));
                continue;
              default:
                num = this.딟;
                continue;
            }
          }
          else
            break;
        }
      }
      catch (Exception ex)
      {
        떀.딟("Unhandled Exception, aborting request.");
        떀.딟(ex.ToString());
        this.딟 = ex;
        // ISSUE: reference to a compiler-generated method
        this.딟((땥) null);
      }
      // ISSUE: reference to a compiler-generated method
      this.딟(true);
    }

    public void 딟()
    {
      // ISSUE: reference to a compiler-generated method
      this.딟(false);
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.딟));
    }

    public static bool 딟([In] object obj0, [In] X509Certificate obj1, [In] X509Chain obj2, [In] SslPolicyErrors obj3) => true;

    private void 딟([In] Stream obj0)
    {
      BinaryWriter binaryWriter = new BinaryWriter(obj0);
      binaryWriter.Write(Encoding.ASCII.GetBytes(this.땃().ToUpper() + " " + this.딟.PathAndQuery + " HTTP/1.1"));
      binaryWriter.Write(딧.딧.땄);
      foreach (string key in this.딟.Keys)
      {
        foreach (string s in this.딟[key])
        {
          binaryWriter.Write(Encoding.ASCII.GetBytes(key));
          binaryWriter.Write(':');
          binaryWriter.Write(Encoding.ASCII.GetBytes(s));
          binaryWriter.Write(딧.딧.땄);
        }
      }
      if (this.딟 != null && this.딟.Length > 0)
      {
        if (this.딟("Content-Length") == string.Empty)
        {
          binaryWriter.Write(Encoding.ASCII.GetBytes("content-length: " + this.딟.Length.ToString()));
          binaryWriter.Write(딧.딧.땄);
          binaryWriter.Write(딧.딧.땄);
        }
        binaryWriter.Write(this.딟);
      }
      else
        binaryWriter.Write(딧.딧.땄);
    }

    public void Dispose() => this.딟 = true;

    [SpecialName]
    public string 땄() => this.딟.ToString();

    [CompilerGenerated]
    [SpecialName]
    public string 땃() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public bool 딧() => this.땄;

    [CompilerGenerated]
    [SpecialName]
    public 땥 딢() => this.딟;
  }
}
