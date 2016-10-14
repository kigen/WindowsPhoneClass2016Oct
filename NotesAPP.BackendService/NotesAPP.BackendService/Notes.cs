using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesAPP.BackendService
{
    public class Notes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string User { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Created { get; set; }
    }
}