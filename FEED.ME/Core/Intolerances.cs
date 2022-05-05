using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEDME.Core
{
    public class Intolerances : ObservableCollection<string>
    {
        public Intolerances()
        {
            Add("Dairy");
            Add("Egg");
            Add("Gluten");
            Add("Grain");
            Add("Peanut");
            Add("Seafood");
            Add("Sesame");
            Add("Shellfish");
            Add("Soy");
            Add("Sulfite");
            Add("Tree Nut");
            Add("Wheat");


        }
    }
}
