# Portable source regressions

Run with .NET 10.0.401 and C# 5:

```sh
dotnet run --project tests/Portable.Tests/Portable.Tests.csproj --configuration Release
```

Links the actual MainPage code. Phone UI and WebClient are inert test doubles. Real System.Xml and System.Uri exercise adjacent XML elements, entities, missing messages, query escaping and completion-handler registration order. No server profile, credentials or HTTP/SSH request is used.

These tests do not build or validate the historical application SDK/device runtime. Original platform targets, dependencies and vendor binaries are unchanged. The .NET harness has no package feeds or external test packages.
