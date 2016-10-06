using System.Collections.Generic;
using System.Net.Http;
using PortableRest;

namespace ContactManagement
{
    public class Proxy
    {
        private const string URL = "http://apicontacts.azurewebsites.net/";
        public static Contact PostContact(Contact contact)
        {
            var client = new RestClient {BaseUrl = URL};
            
            RestRequest request = new 
                RestRequest("contact/", HttpMethod.Post);

            request.AddParameter(contact);

            var response = client.ExecuteAsync<Contact>(request);

            return response.Result;
        }


        public static List<Contact> GetContacts()
        {
            var client = new RestClient { BaseUrl = URL };

            RestRequest request = new
                RestRequest("contact/", HttpMethod.Get);

            var response = client.ExecuteAsync<List<Contact>>(request);

            return response.Result;
        } 
    }
}
