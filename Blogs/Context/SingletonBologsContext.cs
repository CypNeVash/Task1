﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Context
{
    sealed class SingletonBologsContext
    {
        private static BlogsContext blogsContext;

        private SingletonBologsContext() { }

        public static BlogsContext InstanceBlogsContext()
        {
            if (blogsContext == null)
                return blogsContext = new BlogsContext();
            else return blogsContext;
        }

    }
}
