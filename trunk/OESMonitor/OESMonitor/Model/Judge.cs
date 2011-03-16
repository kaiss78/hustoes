﻿using System;
using System.Collections.Generic;
using System.Text;


namespace OESMonitor.Model
{
    public class Judge:Problem
    {
        public string ans, stuAns;
        public int unit;
        public string unitName;
        public Judge()
        {
            type = "判断题";
        }
        public Judge(string p)
        {
            problem = p;
            stuAns = "";
            ans = "";
            type = "判断题";
        }
    }
}
