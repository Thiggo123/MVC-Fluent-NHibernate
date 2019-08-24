using MVC_FLuent_Nhibernate.Models;
using MVC_Treinando__Fluent_NHibernate_.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Treinando__Fluent_NHibernate_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Alunos = session.Query<Aluno>().ToList();

                return View(Alunos);
            }
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Alunos = session.Get<Aluno>(id);
                return View(Alunos);
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Aluno Alunos)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(Alunos);
                        transaction.Commit();

                    }
                }
                return RedirectToAction("Index");

            }
            catch
            {

                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Alunos = session.Get<Aluno>(id);
                return View(Alunos);
            }
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno Alunos)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    var alunoAlterado = session.Get<Aluno>(id);

                    alunoAlterado.Nome = Alunos.Nome;
                    alunoAlterado.Email = Alunos.Email;
                    alunoAlterado.Curso = Alunos.Curso;
                    alunoAlterado.Sexo = Alunos.Sexo;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                }

                
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var Alunos = session.Get<Aluno>(id);
                return View(Alunos);
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Aluno Alunos)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(Alunos);
                        transaction.Commit();


                    }

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}