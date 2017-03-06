# DweetSharp
This is a C# open-source library to interact with the [dweet.io](https://dweet.io) REST API. It gives you ridiculously simple messaging and alerts for the Internet of Things.

## How to use it?
Using DweetSharp is as easy as pie.
```csharp
DweetIO.DweetFor("NameOfSomeThing", "some JSON string");

//if you are using Json.NET your code could look like this
DweetIO.DweetFor("NameOfSomeThing", JsonConvert.SerializeObject(someIoTMeasurementObject));

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
