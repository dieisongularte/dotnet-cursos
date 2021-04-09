using DIO.Cursos.Business.Entities;
using DIO.Cursos.Business.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.Cursos.Infraestrutura.Data.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly CursoDbContext _context;

        public CursoRepository(CursoDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Curso curso)
        {
            _context.Curso.Add(curso);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<Curso> ObterPorUsuario(int codigoUsuario)
        {
            return _context.Curso.Include(i => i.Usuario).Where(c => c.CodigoUsuario == codigoUsuario).ToList();
        }
    }
}
