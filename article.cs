using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NP6.Test
{
    class article
    {
        public string Name;
        public int Price;
    }

    class  ListArticle
{
      private ArrayList _ListArticle = new ArrayList();

      public void AddArticle(Article article)
      {
            _ListArticle.Add(article);
      }

      public void RemoveArticle(Article article)
      {
            if( _ListArticle.Contains(article) ) _ListArticle.Remove(article);
      }

      public bool ContainsArticle(Article article)
      {
            return _ListArticle.Contains(article);
      }
};


class Prog
{
      public static void Main()
      {
            ListArticle myList = new ListArticle(); 
            Article A = new Article();
            A.Name = "Vélo"; A.Price = 250;
            myList.AddArticle(A);
            if( myList.ContainsArticle(A) ) myList.RemoveArticle(A);
      }
}

}
