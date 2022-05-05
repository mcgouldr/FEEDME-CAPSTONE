using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEDME.Core
{
    public class CuisineTypes : ObservableCollection<string>
    {
        public CuisineTypes()
        {
            Add("African");
            Add("American");
            Add("British");
            Add("Cajun");
            Add("Caribbean");
            Add("Chinese");
            Add("Eastern European");
            Add("European");
            Add("French");
            Add("German");
            Add("Greek");
            Add("Indian");
            Add("Irish");
            Add("Italian");
            Add("Japanese");
            Add("Jewish");
            Add("Korean");
            Add("Latin American");
            Add("Mediterranean");
            Add("Mexican");
            Add("Middle Eastern");
            Add("Nordic");
            Add("Southern");
            Add("Spanish");
            Add("Thai");
            Add("Vietnamese");
        }
    }
}
