using KevinSystem.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinSystem.Models.SystemModel
{
    public class MainFunctionModel
    {
       public int MainFunctionID { get; set; }
       public string MainFunctionName { get; set; }

        public List<MainFunctionModel> MainFunction_Get()
        {
           return  new kevinSystemDB().MainFunction_Get();
        }
    }
}
