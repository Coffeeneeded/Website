using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVRepository.Interface;

namespace TVRepository.Data
{
    public class ArticlesDAL : IArticlesDAL
    {
        private readonly ArticlesContext _dependency;
        public ArticlesDAL(ArticlesContext dependecy)
        {
            this._dependency = dependecy;
        }

        public string get()
        {
            return this._dependency.Autores.FirstOrDefault().Biografia;
        }
    }
}
