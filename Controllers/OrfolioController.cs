﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EquipeOrfolio.Controllers
{
    public class OrfolioController : Controller
    {
        // GET: Orfolio
        public ActionResult Index()
        {
            return View();
        }

        // GET: Orfolio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orfolio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orfolio/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orfolio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Orfolio/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Orfolio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orfolio/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
