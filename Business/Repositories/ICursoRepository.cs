using DIO.Cursos.Business.Entities;
using System.Collections.Generic;

namespace DIO.Cursos.Business.Repositories
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        void Commit();
        IList<Curso> ObterPorUsuario(int codigoUsuario);
    }
}
