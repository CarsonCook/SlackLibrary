# SlackLibrary

This is a collection of code meant to make using the Slack APIs easy. The library handles all work regarding building, sending and receiving API calls so that sending a call and receiving the response is done by a class instantiation and a method call. Click [here](https://api.slack.com/methods) to see a list of all Slack API methods, with documentation for each.

The following documentation provides a high level understanding of the library and how to use it. For more specific documentation about each class, for example what each method parameter is exactly, go into the classes themselves. Javadoc style documentation has been written in each class.

A list of the classes that need to be instantiated for each API call can be found in the [Delete](https://ddsb.visualstudio.com/AzureTemplates/_wiki?pagePath=%2FSlack%2FSlack-Library%2FDelete), [Get](https://ddsb.visualstudio.com/AzureTemplates/_wiki?pagePath=%2FSlack%2FSlack-Library%2FGet) and [Post](https://ddsb.visualstudio.com/AzureTemplates/_wiki?pagePath=%2FSlack%2FSlack-Library%2FPost) files.

## Events API

### Classes

The Events directory is where classes relating to the Slack Event API are stored.

#### GetEvent

This class is used as a helper class for handling events. Currently there are only two methods, both static, one that retrieves event information from the Slack JSON payload and one that gets the type of event.

#### EventHandler

This class is the important part of the library for events. It is an abstract class meant to be inherited by other classes outside of the library. Those classes will handle specific types of events and are ver easy to implement (unless the Handle logic is complex) . For example:
```
public class HandleReaction : EventHandler
{
    public HandleReaction(string eventToHandle) : base(eventToHandle)
    {
    }

    public Task<bool> Handle(JsonEventDetails eventDetails)
    {
        //event logic
    }
}
```
EventHandler has an abstract method, Handle, that will contain the logic used to actually handle the event. This, however, is not accessible by client code, even though it seems like it should be. 

What client code uses is the HandleEvent(List<EventHandler>, JsonEvent) method. This method takes a list of EventHandlers (specific ones like HandleReaction as EventHandler itself is abstract) and a JsonEvent object. When an EventHandler child class is made, it has a constructor that takes a string specifying the name of the event it will handle. This is going to be equal to one of the possible values for the type field in the Slack event JSON. This event identifier is passed into the EventHandler and put in _evenTToHandle. When HandleEvent(List<EventHandler>), JsonEvent) is called, it loops through the List looking for an EventHandler with the same Type field as what's in _eventToHandle. When one is found, that instance's Handle method is called, and the result is returned. This makes client code needed to handle events extremely easy and removes the client having to make a long switch case holding each event type they want to handle.

### Handling Events

To handle an event, client code merely needs to receive the Slack event JSON, parse it into a JsonEvent class, build an EventHandler list and call EventHandler.HandleEvent(). For example:
```
public class EventController : ApiController
    {
        public async Task<string> PostAsync()
        {
            string request = await Request.Content.ReadAsStringAsync();
            JsonEvent slackEvent = GetEvent.Get(request);
            bool handled = await EventHandler.HandleEvent(BuildEventHandlerList(), slackEvent);
            return request; //must return the challenge parameter in the post content. Apparently returning the request string works
        }

        private List<EventHandler> BuildEventHandlerList()
        {
            List<EventHandler> handlers = new List<EventHandler>
            {
                {new HandleReply(Events.REPLY_SENT) },
                {new HandleReaction(Events.REACTION_ADDED) }
            };
            return handlers;
        }
    }
```
The Events class in the library holds constants of the possible event types defined by Slack. However there are some issues - Slack considered some events to be the same when really they are not. For example, a reply to a message and a normal message are the same type of event to Slack. However, it was determined in GetEvent.DiagnoseEvent() that a reply has some different attributes in the JSON than a normal message, so a new event type was added. Many of these edge cases will not be in the Events class, at least yet.

### Future Changes

One possible change is having the children EventHandlers have an empty constructor that still passes an event type string to base(). This would make the code that builds the EventHandler chain of command even simpler, although it removes flexibility for handlers. Also, the complexity is not an issue, and the client still needs to figure out what event type string is needed, just in a different place.

The Events class and GetEvent.DiagnoseEvent() method likely could be added to. There are likely more situations like the message event vs. reply event, where they are the same event to Slack and its JSON, but to users a different one. This should be investigated and unfortunately is very difficult to add.

The Chain of Responsibility pattern used by EventHandler.HandleEvent() means that only one handler can ever be used for one event. This is fine if the client is mindful of that when creating EventHandler children/implementing Handle(), but if not this could cause issues. Allowing multiple handlers to handle one event could get messy, but may be useful. The results would need to be returned in a class similar to a JsonParsing one (see below), where an array of handler results are returned with the name of the handler and the result.

## API Calls

There are three categories of classes that make API calls: Get, Delete and Post. Get is meant for classes that retrieve information from Slack, changing nothing. Delete is meant to simulate user actions in Slack, but only for removal action like remove a pinned item or deleting a message. Post is meant to simulate all other user actions, usually they add or change Slack. For example, sending a message or archiving a channel. Classes in each category have the name within them: for example MessagePost, MessageDelete and GetThread. There are some Get classes that have a slightly different name, however, such as FindMessage.

### Using each Type

For the point of showing how to use the types, fake SlackPost, SlackDelete and GetSlack classes will be used.

```
bool postWorked = await new SlackPost().Post();
bool deleteWorked = await new SlackDelete().Delete();
var getResponse = await new SlackGet().Get();
if (getResponse.Ok)
{
     //Get call worked
}
```

Every Delete and Post method return a Boolean that represents if the call worked or not. Get methods return an object that has parsed the API response and has variables holding all information from the response. Every object will have an Ok parameter that holds Boolean representing if the call worked or not. The Boolean should always be checked before continuing on with code that depends on a working call. Also, these methods are all async and require an await operator.

Every real class requires the application token to be passed as a constructor parameter. This is so that only authorized apps can make changes to your Slack team. Many classes will have more required and optional constructor parameters that reflect required and optional parameters in the API call. 

## Future Additions

### Adding Classes

Only approximately half of the available Slack API methods have been implemented in this library, many of which are very useful.

To add a class that implements a Slack API method, you simply must inherit SlackApiGet/Post/Delete, implement the methods and follow the Slack documentation. GetApiUrl and GetFirstDataKey will be implemented, and if there are more parameters in the API method call than defined in the parent class, BuildRequest will be overridden. These methods are outlined below. All values are passed in via constructor, to be used in BuildRequest. Below is an example of a more complex class, for the API method [here](https://slack.com/api/reactions.list):
```
/**
     * Class used to retrieve all of the items a user has reacted to, and what those reactions were.
     * 
     * Requires the reactions:read permission.
     */
    public class GetUserReactions : SlackApiGet<JsonListResponse>
    {
        private int _count, _page;
        private bool _full;

        /**
         * Method used to set the intance variables to avoid constructor repitition.
         * 
         * @param count - The number of items to return per page.
         * @param page - The page number of results to return.
         * @param full - Signifies if the full reaction list is to be returned.
         */
        private void Initialize(int count, int page, bool full)
        {
            _count = count;
            _page = page;
            _full = full;
        }

        /**
         * Constructor used to have optional parameters be logical defaults.
         * 
         * @param token - The app's Bot, Workspace or User token.
         * @param userId - The ID of the user for which reaction items are being retrieved.
         */
        public GetUserReactions(string token, string userId) : base(token, userId)
        {
            Initialize(100, 1, true);
        }

        public GetUserReactions(string token, string userId, int count, int page, bool full) : base(token, userId)
        {
            Initialize(count, page, full);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.COUNT, _count.ToString()); //this API method has a "count" parameter
            request.Add(DicKeys.PAGE, _page.ToString()); //"page" parameter
            request.Add(DicKeys.FULL, _full.ToString()); //"full" parameter
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_ALL_USER_REACTED_TO;
        }

        protected override string GetFirstDataKey()
        {
            return DicKeys.USER;
        }
    }
```

#### Inheritance Tree

In order to make class creation easy an inheritance tree was made. _SlackApiCall_ is the root, with a SlackApi<Type> class being the intermediate between the implementing children classes and _SlackApiCall_.

##### SlackApiCall

This is the root of the inheritance tree. It is an abstract class with a protected constructor so that client code and children classes cannot accidentally directly instantiate it. Every single Slack API call must include the calling application's Slack token as well as have a method that will actually send the call. _SlackApiCall_ was made to abstract those common class attributes. The token value is passed via constructor, so all children need to call ```base(token)```.

Sending the API call was implemented via the FireRequest method. It takes a Dictionary holding the request key value pairs and then returns the response. The actual type returned is passed into _SlackApiCall_ via a generic type parameter. Since the response is being parsed into a JSON, and every response contains an important Ok field, the generic type must inherit or be SlackApiResponse (a JsonParsing class). If any errors occur in this method (not in the API call itself), null is returned.

_SlackApiCall_ also holds abstract methods GetApiUrl and GetFirstDataKey. GetApiUrl will return the URL of the Slack API method the implementing class is using. This is done so that FireRequest can call GetApiUrl instead of relying on the URL being passed as a parameter. GetFirstDataKey is abstracted here because many API methods of all types have more required parameters than just the token, so rather than have each intermediate type class abstract it, _SlackApiCall_ abstracts it for all. This method will return the string key for a required value in the Dictionary request. If there are no required values, this method should return "".

Finally, there is a virtual method, BuildRequest. This method is used to create the request Dictionary for the API call. Because the token is the only parameter required by all methods, the _SlackApiCall_ BuildRequest only adds the token key-value pair. Children class will override it, call base.BuildRequest and then add other pairs to the request if necessary. It is called from FireRequest as well.

#### SlackApiDelete

This class is the parent to all Delete API method classes. It inherits _SlackApiCall_ and is also abstract so that GetApiUrl and GetFirstDataKey do not need to be implemented, as the API method classes will have different values for each. It also has a protected constructor to avoid direct instantiation. _SlackApiDelete_ fills the type parameter in _SlackApiCall_ with SlackApiResponse so that the Ok value can be captured in the response, which the only value needed.

_SlackApiDelete_ overrides BuildRequest to add an identifier value. Most delete API methods require a string identifier of what is to be deleted, so that is abstracted from the children. The overridden BuildRequest is as follows:
```
Dictionary<string, string> request = base.BuildRequest();
            request.Add(GetFirstDataKey(), _identifier);
            return request;
```

so that the token addition does not have to be re-done.

The identifier value is passed via constructor, so implementing delete classes must call ```base(token, Id);```.

_SlackApiDelete_ adds a new method, Delete. This method is the only client facing method and is used to send the API call and asynchronously return the response. Since all delete API methods simply respond with an Ok value, this Delete method is the same for all Delete classes, hence why it is implemented in _SlackApiDelete_.

#### SlackApiPost

SlackApiPost is nearly the same as SlackApiDelete except it takes two extra pieces of data in it's constructor and adds two key-value pairs to the request Dictionary. This is because most Post type API methods require two identifiers - the item and it's holder, for example a message and the channel holding it. The overridden BuildRequest calls the abstract method GetSecondDataKey to get the key for the second value. It is the same idea as the _SlackApiCall_ GetFirstDataKey, but confined to Post because other classes often do not have three required parameters.

_SlackApiPost_ has a Post method that is the same as Delete in _SlackApiDelete_. This is not abstracted so that the name can reflect the API method type.

#### SlackApiGet

_SlackApiGet_ is also very similar to _SlackApiDelete_. Its equivalent of Delete is the Get method, which has a different implementation. Since Get API methods return more data than just an "API call Ok", it needs to return a JsonParsing class object holding this information. As such, _SlackApiGet_ has a generic type parameter that Get returns and is also passed up to _SlackApiCall_.  Get also checks for the result of FireRequest to be null, or for the Ok value to be false; if true null will be returned.

#### Adding to JsonParsing

A new JsonParsing class will likely need to be added for new Get API methods. How these are built is outline in the [JsonParsing page](https://ddsb.visualstudio.com/AzureTemplates/_wiki?pagePath=%2FSlack%2FSlack-Library%2FJsonParsing). 

Classes that are at the top level of the response need to inherit _SlackApiResponse_. This means that the "ok" filed in the JSON response does not need to be added to the new JsonParsing class. It is necessary to inherit _SlackApiResponse_ because _SlackApiCall_ (and therefore _SlackApiGet_) take a generic type parameter that must inherit SlackApiResponse. This is to ensure that the Ok field is obtained when parsing the response.

### Improvements to Make

The following are some changes that could be made in the future to improve the library code.

#### Remove ItemType

There is an enum called ItemType that is referenced throughout the library. This is made for many reasons, the main ones being:

* it tightly couples classes by having them reference the same global data
* there are some labels in ItemType that are not needed in some classes, but are in others. This means a bad value can be passed, which will cause the API call to fail, rather than throw a compile-time error.

One possible solution is to simply create a new enum for each class that uses ItemType, iterating only the values needed. Another idea is to split apart the classes that reference it into separate classes. For example, rather than different behavior if ItemType is MESSAGE vs. FILE, make a class that does the MESSAGE behavior and a class that does the FILE behavior and force the client to pick which one to instantiate. The issue with this idea is then there would be quite a few small classes laying around, with a lot of similar code. One way to mitigate the similar code would be to keep the overall class but make it abstract. Then the smaller MESSAGE/FILE classes could inherit the original class, and send the ItemType value through the base() constructor call.

There is another enum, ChannelType, that is reference by multiple classes. All of these classes use every label in this enum, however, and there should never be any additions to it (there are no more channel types to add). Having said that, it is always possible Slack creates a new channel type, or a label added for whatever reason, so removing ChannelType is a possibility.

#### Use an Action Category

It is possible that some of the remaining API methods to be implemented may not fit within the current types. For example, archiving a channel - it is definitely not a Get or Delete, and is it really a Post? Maybe create an Action category for more miscellaneous actions like archiving.

## API Methods to Add

api.test, apps.permissions.request, auth.revoke, auth.test, chat.unfurl, files.upload, oauth.access, oauth.token, rtm.connect, rtm.start, users.setPhoto.

## Extra Tips

### IDs

Often for debugging, IDs of channels or users (or others) are needed. Rather than using a Get() call, these can be found through the Chrome browser. If you right-click Inspect an element, you can usually find the ID. For example, inspecting a username from a message will show that user's ID in the data-id field. You can also find message/file/channel IDs by looking at the URL when you enter a channel or file/message thread.

### Debugging

To test out a call you should make it trigger on a specific event that will only happen when you manually do it. The best way is using a slash command. For example, say you trigger the call when a message happens. Then, because you want to make sure your call works, you send a message to view the result. This would create an infinite loop of messages and you would need to uninstall the app to stop the messages.

When a Post or Delete call fails, all you normally receive is "false" or "true" if you are printing out the result of FireRequest(). Instead of this, you need to use MessagePost to send a message containing the responseValString in FireRequest(). This way you can see the actual error and fix it. This will create an infinite loop, however, as MessagePost will trigger FireRequest(), triggering MessagePost...etc., again needed an app uninstall to stop. To make a single MessagePost with the error, add a weird key-value pair to your request Dictionary in the troublesome class. For example,
```
protected override BuildRequest()
{
      Dictionary<string, string> request = base.BuildRequest();
      request.Add("TESTING123","asdf");
      return request;
}
```

Then, in FireRequest() check for that key, if it is there, send a message, like so:
```
if (BuildRequest().ContainsKey("HELLO123"))
{
      await new MessagePost("token","channel",responseValString).Post();
}
```

The MIT License

Copyright (c) 2010-2017 Google, Inc. http://angularjs.org

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
