
using CreditSuisse.App.Domain.Interfaces;

namespace CreditSuisse.App.Domain.Repository
{
    internal class Category : ICategory
    {
        public List<Category> Get()
        {
            var categories = new List<Category>
            {
                new Category { Name = "EXPIRED" },
                new Category { Name = "HIGHRISK" },
                new Category { Name = "MEDIUMRISK" }
            };

            return categories;
        }

        public string Name { get; set; }
        public void added(string name)
        {
            throw new NotImplementedException();
        }
        public void modified(string name)
        {
            throw new NotImplementedException();
        }
        public void removed(string name)
        {
            throw new NotImplementedException();
        }
    }
}
