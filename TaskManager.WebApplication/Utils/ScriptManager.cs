using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.WebApplication.Utils
{
    public static class ScriptManager
    {
        public static void SetStartupScript(ITempDataDictionary tempData, string script, bool mustSurroundWithScriptTag = false)
        {
            string scriptStart = "<script>";
            string scriptEnd = "</script>";

            if (mustSurroundWithScriptTag)
                tempData["StartupScript"] = scriptStart + script + scriptEnd;
            else
                tempData["StartupScript"] = script;
        }
    }
}
