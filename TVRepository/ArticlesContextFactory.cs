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
            optionsBuilder.UseSqlServer("Data Source=tcp:s15.winhost.com;Initial Catalog=DB_116930_blog;User ID=DB_116930_blog_user;Password=@lfa4463;Integrated Security=False;");

            return new ArticlesContext(optionsBuilder.Options);
        }         
    }
}
