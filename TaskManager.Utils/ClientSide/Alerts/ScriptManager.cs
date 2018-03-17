using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TaskManager.Utils.ClientSide.Alerts
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
