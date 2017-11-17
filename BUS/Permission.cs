using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUS
{
    public class Permission
    {
        public static DTO.Permission Get(string staffid)
        {
            DTO.tblStaff staff = BUS.tblStaff.GetByID(staffid);
            DTO.Permission item = new DTO.Permission();
            item.AdminRight.Process(staff.AdminRight);
            item.UPDMember.Process(staff.UPDMember);
            item.UPDServiceTransaction.Process(staff.UPDServiceTransaction);
            item.UPDPaymentTransaction.Process(staff.UPDPaymentTransaction);
            item.UPDPointRule.Process(staff.UPDPointRule);
            item.UPDChangeCard.Process(staff.UPDChangeCard);
            item.RPTMember.Process(staff.RPTMember);
            item.RPTServiceTransaction.Process(staff.RPTServiceTransaction);
            item.RPTPaymentTransaction.Process(staff.RPTPaymentTransaction);
            item.RPTReportIncrease_Decrease.Process(staff.RPTReportIncrease_Decrease);
            item.RPTReportServiceAmount.Process(staff.RPTReportServiceAmount);

            
            return item;
        }
    }
}
