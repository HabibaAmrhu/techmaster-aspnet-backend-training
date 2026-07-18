using WebAPIproject.DTOs;

namespace WebAPIproject.Repositories.Interfaces
{
    public interface INotes
    {
        List<Notes> GetAll();
        void Add(Notes note);
        Notes GetById(int id);
        bool Update(int id ,UpdateNoteRequest dto);
        bool Delete(int id);
        List<Notes> Search(string title);
        List<Notes> Pagination(int Pnum, int Psize);
        int GetTotalCount();
    }
}
