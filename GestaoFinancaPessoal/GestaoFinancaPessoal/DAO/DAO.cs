﻿using GestaoFinancaPessoal.Models;
using GestaoFinancaPessoal.Uteis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoFinancaPessoal.Models;
using GestaoFinancaPessoal.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq.Expressions;

namespace GestaoFinancaPessoal.DAO
{
    public class DAO<T> : IDAO, IDisposable where T : MasterModel, IDisposable
    {
        protected readonly ApplicationDbContext Context;
        protected readonly DbSet<T> DbSet;
        protected readonly Session Session;
        protected readonly ModelStateDictionary ModelState;
        protected readonly Controllers.Controller Controller;


        public DbContext GetContext()
        {
            return this.Context;
        }

        public Session GetSssion()
        {
            return this.Session;
        }

        public ModelStateDictionary GetModelState()
        {
            return this.Controller.ModelState;
        }

        public Controllers.Controller GetController()
        {
            return this.Controller;
        }

        public DAO(Controllers.Controller controller)
        {
            this.Context = controller.Contexto;
            this.DbSet = controller.Contexto.Set<T>();
            this.Session = controller.Session;
            this.ModelState = controller.ModelState;
            this.Controller = controller;

            controller.Contexto.Database.EnsureCreated();
        }

        public DAO(IDAO dao)
        {
            this.Context = (ApplicationDbContext)dao.GetContext();
            this.DbSet = this.Context.Set<T>();
            this.Session = dao.GetSssion();
            this.ModelState = dao.GetModelState();
            this.Controller = dao.GetController();

            Context.Database.EnsureCreated();
        }

        public TDAO NewDAO<TDAO>(TipoConecao tipo = TipoConecao.DEFAULT) where TDAO : IDAO
        {
            return (TDAO)Activator.CreateInstance(typeof(TDAO), new object[] { this });
        }

        public bool IsValid(T p)
        {
            return ModelState.IsValid;
        }

        public virtual void Add(T p)
        {
            if (this.IsValid(p))
            {
                DbSet.Add(p);
            }
        }

        public virtual void Attach(T p)
        {
            DbSet.Attach(p);
        }

        public virtual void Update(T p)
        {
            if (this.IsValid(p))
            {
                DbSet.Update(p);
            }
        }

        public virtual void Remove(T p)
        {
            DbSet.Remove(p);
        }

        public virtual IList<T> List(T p, Boolean mapeado = false)
        {
            if (mapeado)
            {
                return DbSet.ToList();//ele mapeia todos objetos 
            }
            else
            {
                return DbSet.AsNoTracking().ToList();//ele nao mapeia os objetos 
            }
        }

        public virtual T getById(T p)
        {
            return DbSet.Where(i => i.Id == p.Id).FirstOrDefault();
        }

        public virtual T getById(int id)
        {
            return DbSet.Where(i => i.Id == id).FirstOrDefault();
        }

        public virtual IList<T> List(Boolean mapeado = false)
        {
            if (mapeado)
            {
                return DbSet.ToList();//ele mapeia todos objetos 
            }
            else
            {
                return DbSet.AsNoTracking().ToList();//ele nao mapeia os objetos 
            }
        }

        public IQueryable<T> ListQuery()
        {
            return DbSet;
        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        public virtual void Dispose()
        {
            Context.Dispose();
        }





        public Expression<Func<TItem, object>> GroupByExpression<TItem>(string[] propertyNames)
        {
            var properties = propertyNames.Select(name => typeof(TItem).GetProperty(name)).ToArray();
            var propertyTypes = properties.Select(p => p.PropertyType).ToArray();
            var tupleTypeDefinition = typeof(Tuple).Assembly.GetType("System.Tuple`" + properties.Length);
            var tupleType = tupleTypeDefinition.MakeGenericType(propertyTypes);
            var constructor = tupleType.GetConstructor(propertyTypes);
            var param = Expression.Parameter(typeof(TItem), "item");
            var body = Expression.New(constructor, properties.Select(p => Expression.Property(param, p)));
            var expr = Expression.Lambda<Func<TItem, object>>(body, param);
            return expr;
        }
    }
}
