using System;
using System.Reflection;
class Program {
 static int count;
 static void Check(bool value,string name) { if(!value) throw new Exception(name); count++; }
 static object Call(object target,string name,params object[] args) { return target.GetType().GetMethod(name,BindingFlags.Instance|BindingFlags.NonPublic).Invoke(target,args); }
 static void Main() { Test(); Console.WriteLine("PASS " + count + " source assertions"); }
 static void Test() { var p=new m0rg0t_SSH.MainPage();var e=new m0rg0t_SSH.DownloadStringCompletedEventArgs {Result="<root><message_text>one</message_text><message_text>two</message_text><message_text>three</message_text></root>"};Check((string)Call(p,"GetDataFromXML","message_text",e)=="onetwothree","adjacent elements retained");
 e.Result="<root><message_text>A &amp; B</message_text><other>x</other><message_text>C</message_text></root>";Check((string)Call(p,"GetDataFromXML","message_text",e)=="A & BC","entities and separated elements");e.Result="<root/>";Check((string)Call(p,"GetDataFromXML","message_text",e)=="","absent messages");
 foreach(var cmd in new[]{"echo A&B", "echo #fragment", "echo a+b%20", "echo Привет", ""}) {p.Commandline.Text=cmd;Call(p,"Sendcommand_Click",null,null); var u=m0rg0t_SSH.WebClient.LastUri;Check(u.Query=="?message="+System.Uri.EscapeDataString(cmd),"exact single encoded query parameter");Check(u.Fragment=="","command cannot become fragment");Check(System.Uri.UnescapeDataString(u.Query.Substring("?message=".Length))==cmd,"command roundtrip");Check(m0rg0t_SSH.WebClient.SubscribedBeforeStart,"completion handler registered before download");}
 } }