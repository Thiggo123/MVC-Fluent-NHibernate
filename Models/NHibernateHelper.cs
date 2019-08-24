using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MVC_FLuent_Nhibernate.Models;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Treinando__Fluent_NHibernate_.Models
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cadastro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<AlunoMap>()).ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false)).BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

       

    }
}