using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContactManagement
{
   public  class Settings
   {
       private readonly Windows.Storage.ApplicationDataContainer _localSettings;
       public Settings()
       {
           _localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
       }

       public List<Contact> Contacts
       {
           get
           {
               if (_localSettings.Values.ContainsKey("contacts"))
               {
                   return fromJson(_localSettings.Values["contacts"].ToString());

               }else
               {
                   return new List<Contact>();
               }
           }

           set
           {
               _localSettings.Values["contacts"] = toJson(value);
           }
           
       }


       private List<Contact> fromJson(string json)
       {
           return JsonConvert.
               DeserializeObject(json, typeof (List<Contact>)) 
               as List<Contact>;
       }
       private String toJson(List<Contact> contacts)
       {
           return JsonConvert.SerializeObject(contacts);
       }


       private List<Contact> _fromJson(string json)
       {
           DataContractJsonSerializer serializer =
               new DataContractJsonSerializer(typeof(List<Contact>));

           return serializer.ReadObject(getStream(json)) as List<Contact>;
       }

       private String _toJson(List<Contact> contacts)
       {
           DataContractJsonSerializer serializer =
               new DataContractJsonSerializer(typeof(List<Contact>));
           MemoryStream  stream = new MemoryStream();

          serializer.WriteObject(stream,contacts);

          return stream.ToString();
       }


       private MemoryStream getStream(string json)
       {
           return new MemoryStream(Encoding.UTF8.GetBytes(json));
       }

    }
}
