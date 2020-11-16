using Dock.UI.Site.Data;
using Dock.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Dock.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MyDbContext _context;

        public TesteCrudController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Name = "Johnny",
                DataNascimento = DateTime.Now,
                Email = "johnny@dockhorn.com.br"
            };

            _context.Alunos.Add(aluno);
            _context.SaveChanges();

            var _aluno = _context.Alunos.Find(aluno.Id);
            var _aluno2 = _context.Alunos.FirstOrDefault(it => it.Email == "johnny@dockhorn.com.br");
            var _aluno3 = _context.Alunos.Where(it => it.Name == "Johnny");

            aluno.Name = "João";
            _context.Alunos.Update(aluno);
            _context.SaveChanges();

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();

            return View();
        }
    }
}
