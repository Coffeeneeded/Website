using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace TVRepository
{
    public class ArticlesContextFactory :IDbContextFactory<ArticlesContext>
    {
        public ArticlesContext Create(DbContextFactoryOptions options)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArticlesContext>();
            optionsBuilder.UseSqlServer("data source=THIAGONOTE-PC\\SQLEXPRESS;initial catalog=WebBlog;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

            return new ArticlesContext(optionsBuilder.Options);
        }         
    }
}
