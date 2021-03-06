﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class PessoaController : Controller
    {
        public static List<Pessoa> Pessoas { get; set; } = new List<Pessoa>();
        public static List<Pessoa> PessoasSearch { get; set; } = new List<Pessoa>();

        // GET: Pessoa
        public ActionResult Index(string procurarPor, string procurar)
        {
            if (procurarPor == "Nome")
            {
                return View(Pessoas.Where(x => x.Nome == procurar || procurar == null).ToList());
            }
            if (procurarPor == "Sobrenome")
            {
                return View(Pessoas.Where(x => x.Sobrenome.StartsWith(procurar) || procurar == null).ToList());
            }

            return View(Pessoas);
        }
        public ActionResult IndexSearch()
        {
            return View(PessoasSearch);
        }

        public ActionResult Create()
        {
            return View();
        }
       
        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pessoa pessoa)
        {
            try
            {
                Pessoas.Add(pessoa);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            try
            {
                var pessoaOld = Pessoas.FirstOrDefault(x => x.Id == id);

                Pessoas.Remove(pessoaOld);

                pessoa.Id = id;
                Pessoas.Add(pessoa);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var pessoa = Pessoas.FirstOrDefault(x => x.Id == id);
                Pessoas.Remove(pessoa);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
