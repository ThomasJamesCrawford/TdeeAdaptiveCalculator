using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDEE
{

    public class MasterPageItem
    {
        public MasterPageItem()
        {
            TargetType = typeof(MasterPageCS);
        }

        public string Title { get; set; }
        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}