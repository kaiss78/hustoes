using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES;

namespace OESSupport.DB
{
    public class DataControl
    {
        public static OESData data = new OESData();
        
        public static string getPaper(string id)
        {

            return data.FindPaperById(id)[0].paperPath;
        }
        public static string getWordA(string id)
        {

            return data.FindOfficeWordById(id,"1")[0].rawPath;
        }
        public static string getWordB(string id)
        {

            return data.FindOfficeWordById(id, "1")[0].ansPath;
        }
        public static string getExcelA(string id)
        {

            return data.FindOfficeWordById(id, "2")[0].rawPath;
        }
        public static string getExcelB(string id)
        {

            return data.FindOfficeWordById(id, "2")[0].ansPath;
        }
        public static string getPowerPointA(string id)
        {

            return data.FindOfficeWordById(id, "3")[0].rawPath;
        }
        public static string getPowerPointB(string id)
        {

            return data.FindOfficeWordById(id, "3")[0].ansPath;
        }
        public static string getCCompletion(string id)
        {

            return data.FindCompletionProgramById(id)[0].path;
        }
        public static string getCModification(string id)
        {

            return data.FindModificationProgramById(id)[0].path;
        }
        public static string getCFunctionA(string id)
        {

            return data.FindFunProgramById(id)[0].path;
        }
        public static string getCFunctionB(string id)
        {

            return data.FindFunProgramById(id)[0].correctC;
        }
        public static string getCppCompletion(string id)
        {

            return data.FindCompletionProgramById(id)[0].path;
        }
        public static string getCppModification(string id)
        {

            return data.FindModificationProgramById(id)[0].path;
        }
        public static string getCppFunctionA(string id)
        {

            return data.FindCompletionProgramById(id)[0].path;
        }
        public static string getCppFunctionB(string id)
        {

            return data.FindFunProgramById(id)[0].correctC;
        }
        public static string getVbCompletion(string id)
        {

            return data.FindCompletionProgramById(id)[0].path;
        }
        public static string getVbModification(string id)
        {

            return data.FindModificationProgramById(id)[0].path;
        }
        public static string getVbFunctionA(string id)
        {

            return data.FindCompletionProgramById(id)[0].path;
        }
        public static string getVbFunctionB(string id)
        {

            return data.FindFunProgramById(id)[0].correctC;
        }
        public static List<Paper> getPaperList()
        {
            return new List<Paper>();
        }
    }
}
