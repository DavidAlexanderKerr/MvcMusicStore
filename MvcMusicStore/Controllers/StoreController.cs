﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private MusicStoreDB storeDB = new MusicStoreDB();

        // GET: Store
        public ActionResult Index()
        {
            List<Genre> genres = storeDB.Genres.ToList();

            return View(genres);
        }

        // GET: Store/Browse?genre=Disco
        public ActionResult Browse(string genre)
        {
            Genre genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            return View(genreModel);
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            Album album = storeDB.Albums.Find(id);

            return View(album);
        }
    }
}