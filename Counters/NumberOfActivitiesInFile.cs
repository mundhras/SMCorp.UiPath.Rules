using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiPath.Studio.Activities.Api.Analyzer.Rules;
using UiPath.Studio.Analyzer.Models;

namespace SMCorp.UiPath.Rules.Counters
{
    internal static class NumberOfActivitiesInFile
    {
        internal static Counter<IActivityModel> Get()
        {
            return new Counter<IActivityModel>(Strings.SMCORP_USG_004_RuleName, Strings.SMCORP_USG_004_RuleId, Inspect);
        }

        // A Counter<T> receives the entire collection of T objects in the parent structure. e.g. activities in workflow, workflows in project.
        private static InspectionResult Inspect(IReadOnlyCollection<IActivityModel> activities, Counter ruleInstance)
        {
            var i = (from activity in activities
                     where activity.Type.Contains("UiPath.Core.Activities.LogMessage")
                     select activity).Count();


                return new InspectionResult()
                {
                    // For a counter, the error level is always info, even if not set here.
                    ErrorLevel = System.Diagnostics.TraceLevel.Info,
                    // For a counter, the Has Errors field is always ignored.
                    HasErrors = true,
                    Messages = new List<string>() { string.Format(Strings.SMCORP_USG_004_Recommendation, i) }
                };
            
        }
    }
}
