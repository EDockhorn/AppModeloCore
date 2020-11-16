using System;

namespace Dock.UI.Site.Models
{
    public class Aluno
    {
        public Aluno()
        {
            Id = Guid.NewGuid();
        }


        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
