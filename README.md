# DweetSharp
This is a C# open-source library to interact with the [dweet.io](https://dweet.io) REST API. It gives you ridiculously simple messaging and alerts for the Internet of Things.

## How to use it?
Using DweetSharp is as easy as 🍰. For a detailed documentation of the dweet.io API please have a look at [this](https://dweet.io/play/).

#### Sending a Dweet
```csharp
//using Json.NET for serialization
string serializedObject = JsonConvert.SerializeObject(someIoTMeasurementObject);

DweetIO.DweetFor("NameOfSomeThing", serializedObject);
```

#### Getting a Dweet
```csharp
string latestDweet = await DweetIO.GetLatestDweetFor("NameOfSomeThing");
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
* ✅ GetStoredDweetsFor
* ❌ GetStoredAlertsFor
* ✅ Alert
* ✅ GetAlertFor
* ✅ RemoveAlertFor

##Limitations
* retrieving dweets returns a JSON which you will have to parse according to your needs


