using System.Collections.Generic;

namespace Franchise.Web.Models
{
    public interface INoteCommentRepository
    {
        void AddNoteComment(NoteComment model);
        int DeleteNoteComment(int boardId, int id);
        int GetCountBy(int boardId, int id, string name);
        List<NoteComment> GetNoteComments(int boardId);
        List<NoteComment> GetRecentComments();
    }
}
