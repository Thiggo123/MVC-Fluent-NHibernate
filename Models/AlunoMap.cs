using FluentNHibernate.Mapping;
using MVC_FLuent_Nhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Treinando__Fluent_NHibernate_.Models
{
    public class AlunoMap : ClassMap<Aluno>
    {
        public AlunoMap()
        {
            Id(x => x.Id,"Id");
            Map(x => x.Nome,"Nome");
            Map(x => x.Email,"Email");
            Map(x => x.Curso,"Curso");
            Map(x => x.Sexo,"Sexo");
            Schema("dbo");
            Table("Alunos");
        }
    }
}