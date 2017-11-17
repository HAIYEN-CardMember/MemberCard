using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Permission
    {
        public Permission()
        {
            None = new Option();
            AdminRight = new Option();
            UPDMember = new Option();
            UPDServiceTransaction = new Option();
            UPDPaymentTransaction = new Option();
            UPDPointRule = new Option();
            UPDChangeCard = new Option();
            RPTMember = new Option();
            RPTServiceTransaction = new Option();
            RPTPaymentTransaction = new Option();
            RPTReportIncrease_Decrease = new Option();
            RPTReportServiceAmount = new Option();
        }

        public Option None { get; set; }
        public Option AdminRight { get; set; }
        public Option UPDMember { get; set; }
        public Option UPDServiceTransaction { get; set; }
        public Option UPDPaymentTransaction { get; set; }
        public Option UPDPointRule { get; set; }
        public Option UPDChangeCard { get; set; }
        public Option RPTMember { get; set; }
        public Option RPTServiceTransaction { get; set; }
        public Option RPTPaymentTransaction { get; set; }
        public Option RPTReportIncrease_Decrease { get; set; }
        public Option RPTReportServiceAmount { get; set; }


        public enum EnumOption
        {
            None, AdminRight, UPDMember, UPDServiceTransaction, UPDPaymentTransaction, UPDPointRule,
            UPDChangeCard
                , RPTMember, RPTServiceTransaction, RPTPaymentTransaction, RPTReportIncrease_Decrease, RPTReportServiceAmount
        }

        public enum EnumOptionType
        {
            View, Add, Edit, Delete
        }

        public class Option
        {
            public Option()
            {
                View = false;
                Add = false;
                Edit = false;
                Delete = false;
            }
            public int Value { get; set; }
            public bool View { get; set; }
            public bool Add { get; set; }
            public bool Edit { get; set; }
            public bool Delete { get; set; }

            public void Process(int value)
            {
                Value = value;
                string binary = Convert.ToString(value, 2);
                if (binary.Length > 3)
                    Delete = binary[binary.Length - 4] == '1';
                if (binary.Length > 2)
                    Edit = binary[binary.Length - 3] == '1';
                if (binary.Length > 1)
                    Add = binary[binary.Length - 2] == '1';
                if (binary.Length > 0)
                    View = binary[binary.Length - 1] == '1';

                View = !View && Add ? Add : View;
                View = !View && Edit ? Edit : View;
                View = !View && Delete ? Delete : View;
            }
        }

        public class PermissionView
        {
            public string Name { get; set; }
            public bool View { get; set; }
            public bool Add { get; set; }
            public bool Edit { get; set; }
            public bool Delete { get; set; }
        }
        public List<PermissionView> GetView()
        {
            List<PermissionView> lsArray = new List<PermissionView>();
            if (UPDMember != null)
                lsArray.Add(SetView("UPDMember", UPDMember));
            if (UPDServiceTransaction != null)
                lsArray.Add(SetView("UPDServiceTransaction", UPDServiceTransaction));
            if (UPDPaymentTransaction != null)
                lsArray.Add(SetView("UPDPaymentTransaction", UPDPaymentTransaction));
            if (UPDPointRule != null)
                lsArray.Add(SetView("UPDPointRule", UPDPointRule));
            if (UPDChangeCard != null)
                lsArray.Add(SetView("UPDChangeCard", UPDChangeCard));
            if (RPTMember != null)
                lsArray.Add(SetView("RPTMember", RPTMember));
            if (RPTServiceTransaction != null)
                lsArray.Add(SetView("RPTServiceTransaction", RPTServiceTransaction));
            if (RPTPaymentTransaction != null)
                lsArray.Add(SetView("RPTPaymentTransaction", RPTPaymentTransaction));
            if (RPTReportIncrease_Decrease != null)
                lsArray.Add(SetView("RPTReportIncrease_Decrease", RPTReportIncrease_Decrease));
            if (RPTReportServiceAmount != null)
                lsArray.Add(SetView("RPTReportServiceAmount", RPTReportServiceAmount));
            return lsArray;
        }

        private PermissionView SetView(string name, Option item)
        {
            PermissionView result = new PermissionView();
            result.Name = name;
            result.View = item.View;
            result.Add = item.Add;
            result.Edit = item.Edit;
            result.Delete = item.Delete;
            return result;

        }
    }
}
