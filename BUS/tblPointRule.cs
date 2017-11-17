using System.Collections.Generic;
using System.Linq;

namespace BUS
{
    public class tblPointRule
    {
        public static List<DTO.tblPointRule> GetAll()
        {
            return DAO.tblPointRule.Get(0);
        }

        public static DTO.tblPointRule GetByID(int rule_id)
        {
            return DAO.tblPointRule.Get(rule_id).FirstOrDefault();
        }

        public static int Create(int Rule_ID, string Description, int ChangeRate, int Increase_Des)
        {
            return DAO.tblPointRule.Create(Rule_ID, Description, ChangeRate, Increase_Des);
        }

        public static int Delete(int rule_id)
        {
            return DAO.tblPointRule.Delete(rule_id);
        }

        public static int Update(int RuleID, string Description, int ChangeRate, int Increase_Decrease)
        {
            return DAO.tblPointRule.Update(RuleID, Description, ChangeRate, Increase_Decrease);
        }
    }
}