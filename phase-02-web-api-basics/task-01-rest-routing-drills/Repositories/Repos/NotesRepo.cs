using WebAPIproject.DTOs;
using WebAPIproject.Repositories.Interfaces;

namespace WebAPIproject.Repositories.Repos
{

    public class NotesRepo : INotes
    {
        private readonly List<Notes> _notes = new List<Notes>();

        public NotesRepo()
        {
        }
        public void Add(Notes note)
        {
            _notes.Add(note);
        }

        public bool Delete(int id)
        {
            var note = GetById(id);
            if (note == null) return false;

            _notes.Remove(note);
            return true;
        }

        public List<Notes> GetAll()
        {
            return _notes;
        }

        public Notes GetById(int id)
        {
            return _notes.FirstOrDefault(n => n.Id == id);
        }

        public List<Notes> Pagination(int Pnum, int Psize)
        {
            return _notes.Skip((Pnum - 1)* Psize).Take(Psize).ToList();
        }
        public int GetTotalCount() => _notes.Count;

        public List<Notes> Search(string title)
        {
            return _notes.Where(t => t.title.Contains(title, StringComparison.OrdinalIgnoreCase)||
            t.content.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public bool Update(int id, UpdateNoteRequest dto)
        {
            var note = GetById(id);
            if (note == null) { return false; }

            note.title = dto.title;
            note.content =  dto.content;
            return true;
        }
    }
}
