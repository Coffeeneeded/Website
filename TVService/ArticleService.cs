using System;
using System.Collections.Generic;
using System.Text;
using TVRepository.Interface;
using TVService.Contracts;

namespace TVService
{
    public class ArticleService : IArticleService
    {
        private readonly IArticlesDAL dependency;
        public ArticleService(IArticlesDAL _dependency)
        {
            this.dependency = _dependency;
        }

        public string Get()
        {
            return this.dependency.get();
        }
    }
}
