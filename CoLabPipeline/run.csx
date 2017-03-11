#r "Newtonsoft.Json"

using System;
using System.Net;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage req, TraceWriter log)
{
   // Grab the JSON that stream analytics has thrown on the queue
   // It will look something like the example below and we need to clean
   // it up so we can load the JSON payload inside it.
   //{
   //   "ContentBag": "@\u0006string\b3http://schemas.microsoft.com/2003/10/Serialization/�\u001b{\"avg\":0.48083300419999553}"
   //}
   log.Verbose($"Webhook was triggered!");
   string jsonContent = await req.Content.ReadAsStringAsync();
   log.Verbose($"json content: {jsonContent}");
   dynamic data = JsonConvert.DeserializeObject(jsonContent);

   string msgBody = data.ContentBag;
   log.Verbose($"Message Received: {msgBody}");

   int length = msgBody.Length;
   log.Verbose($"Message Length: {length.ToString()}");

   // Grab the payload inside the ContentBag value between the curly braces and dump
   // the other rubbish. 
   int start = msgBody.IndexOf("{");
   int end = msgBody.LastIndexOf("}");
   string result = msgBody.Substring(start, end - start + 1);
   log.Verbose($"Result: {result}");

   // Deserialize the value inside and pass it back for processing in the logic app
   return req.CreateResponse(HttpStatusCode.OK, JsonConvert.DeserializeObject(result));
}