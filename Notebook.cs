using System;
using NoteTaking;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace NoteTaking
{
    public class Notebook
    {
        #pragma warning disable CS8600


        private List<Note> notes;
        internal string? title;

        public string NotebookTitle { get; internal set; }

        public string Title { get; set; }

        public Notebook()
        {
            notes = new List<Note>();
        }

        public void AddNote(string title, string content)
        {
            Note note = new Note()
            {
            Title =  title,
            Content = content

            };
            
            notes.Add(note);    

        }

      
        public List<Note> DisplayNote()
        {
                return notes;
        }


        public void EditNote(string title, string newContent)
        {
                 
            Note noteToEdit = notes.Find(note => note.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
           
            if (noteToEdit != null){

                noteToEdit.Content = newContent;
                
            }  
           
        }

        public void DeleteNote(string title)
        {
            Note noteToDelete = notes.Find(note => note.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
             if (noteToDelete != null)
             {
                notes.Remove(noteToDelete);
             }
        }
        public List<Note> SearchNotes(string searchTerm)
        {
            string searchNoteTerm = searchTerm.ToLower();
            List<Note> searchResults = notes.FindAll(note => note.Title.ToLower().Contains(searchNoteTerm) || note.Content.ToLower().Contains(searchNoteTerm));
           
            return searchResults;
        }

    }
}