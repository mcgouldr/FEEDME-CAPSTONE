using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEDME.Core
{
    public class MealTypes : ObservableCollection<string>
    {
        public MealTypes()
        {
            Add("main course");
            Add("side dish");
            Add("dessert");
            Add("appetizer");
            Add("salad");
            Add("bread");
            Add("breakfast");
            Add("soup");
            Add("beverage");
            Add("sauce");
            Add("marinade");
            Add("fingerfood");
            Add("snack");
            Add("drink");
        }
    }
}
