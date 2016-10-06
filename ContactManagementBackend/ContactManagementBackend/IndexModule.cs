using System.Linq;
using Nancy.ModelBinding;

namespace ContactManagementBackend
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            DatabaseContext db = new DatabaseContext();
            Get["/"] = parameters =>
            {
                return Response.AsText("THis is my website");
            };

            Get["contacts/"] = p =>
            {
                var contacts = db.Contacts.ToList();
                return Response.AsJson(contacts);
            };

            Post["contacts/"] = p =>
            {
                var contact = this.Bind<Contact>();
                db.Contacts.Add(contact);
                db.SaveChanges();
                return Response.AsJson(contact);
            };
        }
    }
}