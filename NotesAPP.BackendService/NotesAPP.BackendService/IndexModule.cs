using System.Linq;
using Nancy.ModelBinding;
using Nancy.Routing;

namespace NotesAPP.BackendService
{
    using Nancy;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            NotesDbContext db  = new NotesDbContext();
            Get["/notes"] = parameters =>
            {

                var notes = db.Notes.AsQueryable();
                string user = Request.Query["user"];

                if (user != null && !user.Equals(string.Empty))
                {
                    notes = notes.Where(n => n.User == user);
                }
                return Response.AsJson(notes.ToList());
            };

            Post["/notes"] = parameters =>
            {
                var note = this.Bind<Notes>();
                db.Notes.Add(note);
                db.SaveChanges();
                return Response.AsJson(note);
            };

            Get["/notes/{id}"] = parameters =>
            {
                int id = parameters.id;
                var note = db.Notes.FirstOrDefault(x => x.Id == id);
                return Response.AsJson(note);
            };



            Get["/"] = parameters => Response.AsJson(
                new {Success = true, Message = "You have arrived..but this backend service is not for humans.."});
        }
    }
}