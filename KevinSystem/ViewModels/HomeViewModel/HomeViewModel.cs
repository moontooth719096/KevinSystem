using KevinSystem.Models.HomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinSystem.ViewModels.HomeViewModel
{
    public class HomeViewModel
    {
        public List<TestModel> TestaData { get; set; }

        public HomeViewModel()
        {
            this.TestaData = new TestModel().TestData_Get();
        }
    }
}
