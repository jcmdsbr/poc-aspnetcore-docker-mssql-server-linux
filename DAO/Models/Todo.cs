using System;
using System.ComponentModel.DataAnnotations;

namespace DAO.Models {
    public class Todo {

        protected Todo () { }
        public Todo (string description, bool isComplete = false) {
            this.Id = Guid.NewGuid ();
            this.Description = description;
            this.IsComplete = isComplete;
            this.CreatedIn = DateTime.Now;

        }

        [Key]
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public bool IsComplete { get; private set; }
        public DateTime CreatedIn { get; private set; }

        public void Check (bool isComplete) {
            this.IsComplete = isComplete;
        }
    }
}