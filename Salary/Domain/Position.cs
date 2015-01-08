
using System.ComponentModel;

namespace Salary.Domain
{
    public class Position : Entity
    {

        public Category Category;

        public string Name { get; set; }
        
        public decimal Percent { get; set; }

        public Position(Category category, string name)
        {
            Name = name;
            Category = category;
            switch (category)
            {
                case Category.First:
                    Percent = 0.03m;
                    break;
                case Category.Second:
                    Percent = 0.02m;
                    break;
                case Category.Third:
                    Percent = 0.01m;
                    break;
            }
        }
    }
}
