# DweetSharp
This is a C# open-source library to interact with the [dweet.io](https://dweet.io) REST API. It gives you ridiculously simple messaging and alerts for the Internet of Things.

## How to use it?
Using DweetSharp is as easy as 🍰. 

### Sending a Dweet
```csharp
//using Json.NET for serialization
string serializedObject = JsonConvert.SerializeObject(someIoTMeasurementObject);

DweetIO.DweetFor("NameOfSomeThing", serializedObject);
```
For a detailed documentation of the dweet.io API please have a look at [this](https://dweet.io/play/).

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
