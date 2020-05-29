using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var topic =
                new Category()
                {
                    CategoryTitle = model.CategoryTitle
                };

            using (var top = new ApplicationDbContext())
            {
                top.Categories.Add(topic);
                return top.SaveChanges() == 1;
            }
        }
        public IEnumerable<CategoryList> GetCategories()
        {
            using (var top = new ApplicationDbContext())
            {
                var query =
                    top.Categories
                    //.Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CategoryList
                        {
                            CategoryId = e.CategoryId,
                            CategoryTitle = e.CategoryTitle,
                        }
                        );
                return query.ToArray();
            }
        }
        public CategoryDetail GetCategoryById(int id)
        {
            using (var top = new ApplicationDbContext())
            {
                var topic =
                    top
                        .Categories
                        .Single(e => e.CategoryId == id);//&& e.OwnerId == _userId);
                return
                    new CategoryDetail
                    {
                        CategoryId = topic.CategoryId,
                        CategoryTitle = topic.CategoryTitle,
                      
                    };
            }
        }
        public bool UpdateCategory(CategoryEdit model)
        {
            using (var top = new ApplicationDbContext())
            {
                var topic =
                    top
                        .Categories
                        .Single(e => e.CategoryId == model.CategoryId); //&& e.OwnerId == _userId);
                topic.CategoryTitle = model.CategoryTitle;
              
                return top.SaveChanges() == 1;
            }
        }
        public bool DeleteCategory(int CategoryId)
        {
            using (var top = new ApplicationDbContext())
            {
                var topic =
                    top
                        .Categories
                        .Single(e => e.CategoryId == CategoryId); //&& e.OwnerId == _userId);

                top.Categories.Remove(topic);

                return top.SaveChanges() == 1;
            }
        }
    }
}
   

