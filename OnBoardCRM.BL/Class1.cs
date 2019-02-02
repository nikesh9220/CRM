using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardCRM.BL
{
    public class Class1
    {
        public int X { get; set; }

        public void Fetch()
        {
            OnBoardCRM.DL.Class2 obj = new DL.Class2();
        }
    }
}
