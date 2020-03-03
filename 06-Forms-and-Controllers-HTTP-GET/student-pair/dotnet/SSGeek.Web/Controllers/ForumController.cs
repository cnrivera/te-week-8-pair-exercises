using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class ForumController : Controller
    {
        private IForumPostDAO dao;

        public ForumController(IForumPostDAO forumDAO)
        {
            this.dao = forumDAO;
        }

        public IActionResult Index()
        {
            var forumPost = dao.GetAllPosts();

            return View(forumPost);
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPost(ForumPost newPost)
        {
            dao.SaveNewPost(newPost);
            return RedirectToAction("Index", "Forum");
        }


        
    }
}