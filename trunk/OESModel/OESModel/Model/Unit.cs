using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Unit
    {
        //章节名
        public string UnitName="";
        //章节ID
        public int UnitId = 0;
        //章节所属课程
        public Course course = new Course();
    }
}
