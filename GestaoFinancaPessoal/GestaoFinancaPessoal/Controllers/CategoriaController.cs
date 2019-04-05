﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoFinancaPessoal.DAO;
using GestaoFinancaPessoal.Data;
using GestaoFinancaPessoal.Models;
using GestaoFinancaPessoal.Uteis.Exception.ModelErrorException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinancaPessoal.Controllers
{
    public class CategoriaController : Controller
    {
        public CategoriaController(ApplicationDbContext Contexto, IHttpContextAccessor contextAcessor) : base(Contexto, contextAcessor)
        {
        }

        // GET: Categoria
        public ActionResult Index()

        {
            var categoriaDAO = new CategoriaDAO(this.DAO);

            return View(categoriaDAO.List(true));
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            var categoriaDAO = new CategoriaDAO(this.DAO);
            ViewBag.Categoria = categoriaDAO.List();
            return View(new Categoria());
        }

        // POST: Categoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            var categoriaDAO = new CategoriaDAO(this.DAO);

            ViewBag.Categoria = categoriaDAO.List();
            ViewBag.Salvo = false;
            ModelState.Remove("Hierarquia.Nome");
            try
            {
                if (ModelState.IsValid)
                {
                    
                    if(categoria.Hierarquia.Id == 0)
                    {
                        categoria.Hierarquia = null;
                    }
                    else
                    {
                        categoria.Hierarquia = categoriaDAO.getById(categoria.Hierarquia.Id);
                    }

                    categoriaDAO.Add(categoria);
                    categoriaDAO.SaveChanges();
                    ViewBag.Salvo = true;
                }
                else
                {
                    return View(categoria);
                }

                this.ViewBag.Salvo = true;
                return View(categoria);
            }
            catch (ModelErrorException e)
            {
                this.AddModelError(e);
                return View(categoria);
            }

        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            var categoriaDAO = new CategoriaDAO(this.DAO);
            ViewBag.Categoria = categoriaDAO.List();

            var categoria = categoriaDAO.getById(id);
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Categoria categoria)
        {
            var categoriaDAO = new CategoriaDAO(this.DAO);

            ViewBag.Categoria = categoriaDAO.List();
            ViewBag.Alterado = false;
            ModelState.Remove("Hierarquia.Nome");
            try
            {
                if (ModelState.IsValid)
                {
                    if (categoria.Hierarquia.Id == 0)
                    {
                        categoria.Hierarquia = null;
                    }
                    else
                    {
                        categoria.Hierarquia = categoriaDAO.getById(categoria.Hierarquia.Id);
                    }


                    categoriaDAO.Update(categoria);
                    categoriaDAO.SaveChanges();
                    ViewBag.Alterado = true;
                }
                else
                {
                    return View(categoria);
                }

                this.ViewBag.Alterado = true;
                return View(categoria);
            }
            catch (ModelErrorException e)
            {
                this.AddModelError(e);
                return View(categoria);
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            var categoriaDAO = new CategoriaDAO(this.DAO);
            try
            {
                ViewBag.Excluido = false;
                
                Categoria categoria = categoriaDAO.getById(id);

                categoriaDAO.Remove(categoria);
                categoriaDAO.SaveChanges();
                ViewBag.Excluido = true;

                return View("index", categoriaDAO.List());

            }
            catch (ModelErrorException e)
            {
                this.AddModelError(e);
            }
            catch(DbUpdateException e)
            {
                ViewBag.Erro = "N&atilde;o foi possivel deletar está categoria.";
                return View("index", categoriaDAO.List());
            }
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}