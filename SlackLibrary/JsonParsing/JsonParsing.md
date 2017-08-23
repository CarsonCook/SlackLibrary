# JsonParsing

This folder holds all of the classes used to parse out and hold the JSON information received from Slack API calls/event subscriptions. Every class simply has public instance variables with getters and setters, and a [JsonProperty()] tag corresponding to the keys in the Slack JSONs.

Some of these classes inherit from other JsonParsing classes in order to avoid multiple classes with the same attributes. Every class inherits (sometimes indirectly) _SlackApiResponse_, as every response from a Slack API call has Ok and Error fields.

Each class represents an object response from a Slack API call, documented [here](!https://api.slack.com/methods). A nested object in the response means that the JsonParsing equivalent class references another JsonParsing class. For example,
```
"ok": true,
"file": {
        "id": "12345",
        ...
}
```
Is going to become:

ExampleJson:
```
[JsonProperty("ok")]
public bool Ok {get; set;}
[JsonProperty("file")]
public ExampleFileJson File {get; set;}
```

ExampleFileJson:
```
[JsonProperty("id")]
public string Id {get; set;}
```

```ExampleJson response = JsonConvert.DeseriablizeObject<ExampleJson>(jsonString)``` 

Now response holds all of the information returned from the Slack API call and is accessed like so:

```
if (response.Ok)
{
   string fileId = response.Id;
}
```
