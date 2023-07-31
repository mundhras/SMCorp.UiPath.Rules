using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMCorp.UiPath.Rules
{
    internal class Strings
    {
        public const string BusinessRule = "BusinessRule";


        public const string SMCORP_NMG_001_RuleId = "SMCORP-NMG-001";
        public const string SMCORP_NMG_001_RuleName = "Variable Length";
        public const string SMCORP_NMG_001_Recommendation = "Variable should not be more than 15 characters. Follow org guidelines.";
        

        public const string SMCORP_NMG_002_RuleId = "SMCORP-NMG-002";
        public const string SMCORP_NMG_002_RuleName = "Custom Variable Length";
        public const string SMCORP_NMG_002_Recommendation = "Variable should not be more than {0} characters. Follow org guidelines.";
        public const string VariableLengthAllowed = "VariableLengthAllowed";


        public const string SMCORP_NMG_003_RuleId = "SMCORP-NMG-003";
        public const string SMCORP_NMG_003_RuleName = "Custom Variable Length for Process Only";
        public const string SMCORP_NMG_003_Recommendation = "Variable should not be more than 15 characters in a Process. Follow org guidelines.";

        public const string SMCORP_USG_001_RuleId = "SMCORP-USG-001";
        public const string SMCORP_USG_001_RuleName = "Only Save to Draft is allowed";
        public const string SMCORP_USG_001_Recommendation = "Send email via automation is not supported please save to draft and review before sending email.";

        public const string SMCORP_USG_004_RuleId = "SMCORP-USG-002";
        public const string SMCORP_USG_004_RuleName = "Log Message Activity Counter";
        public const string SMCORP_USG_004_Recommendation = "You have {0} Log message activities.";


    }
}
