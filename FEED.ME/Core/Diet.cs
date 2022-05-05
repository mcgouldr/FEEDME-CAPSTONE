using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEDME.Core
{
    public class Diet : ObservableCollection<string>
    {
        public Diet()
        {
            Add("Gluten Free");
            Add("Ketogenic");
            Add("Vegeterian");
            Add("Lacto-Vegeterian");
            Add("Ovo-Vegeterian");
            Add("Vegan");
            Add("Pesceterian");
            Add("Paleo");
            Add("Primal");
            Add("Low FODMAP");
            Add("Whole30");
        }
    }
}
