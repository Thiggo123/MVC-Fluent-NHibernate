﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_FLuent_Nhibernate.Models
{
    public class Aluno
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual string Curso { get; set; }
        public virtual string Sexo { get; set; }


    }
}