﻿using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public interface IForumPostDAO
    {
        IList<ForumPost> GetAllPosts();
        void SaveNewPost(ForumPost post);
    }
}
