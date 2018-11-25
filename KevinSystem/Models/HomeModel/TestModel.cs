using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KevinSystem.Models.HomeModel
{
    public class TestModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PictureURL { get; set; }

        public TestModel()
        {
            init();
        }

        private void init()
        {
            this.ID = 0;
            this.Name = string.Empty;
            this.PictureURL = string.Empty;
        }

        public List<TestModel> TestData_Get()
        {
            List<TestModel> result = new List<TestModel>();
            TestModel Data = new TestModel();
            Data.ID = 1;
            Data.Name = "圖一";
            Data.PictureURL = "https://p2.bahamut.com.tw/S/2KU/91/d6ad9ed67a5bbc3305988ecd76132bj5.JPG";
            result.Add(Data);
            Data = new TestModel();
            Data.ID = 2;
            Data.Name = "圖二";
            Data.PictureURL = "https://p2.bahamut.com.tw/S/2KU/80/b26a5d670c8588d3435ae6c4a4132e05.JPG";
            result.Add(Data);
            Data = new TestModel();
            Data.ID = 3;
            Data.Name = "圖三";
            Data.PictureURL = "https://p2.bahamut.com.tw/S/2KU/65/f81f3b11afbbd3fffdc6718f1f132dl5.JPG";
            result.Add(Data);
            return result;
        }
    }
}
