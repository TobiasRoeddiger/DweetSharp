# DweetSharp
This is a C# open-source library to interact with the [dweet.io](https://dweet.io) REST API. It gives you ridiculously simple messaging and alerts for the Internet of Things.

## How to use it?
Using DweetSharp is as easy as pie. 🍰
```csharp
//using Json.NET for serialization
string serializedObject = JsonConvert.SerializeObject(someIoTMeasurementObject);

DweetIO.DweetFor("NameOfSomeThing", serializedObject);
```

## Supported Functionality
* ✅ Lock
* ✅ Unlock
* ✅ RemoveLock
* ✅ DweetFor
* ✅ DweetQuietlyFor
* ✅ GetLatestDweetFor
* ✅ GetDweetsFor
* ❌ ListenForDweetsFrom
* ❌ GetStoredDweetsFor
* ❌ GetStoredAlertsFor
* ✅ Alert
* ❌ GetAlertFor
* ✅ RemoveAlertFor
