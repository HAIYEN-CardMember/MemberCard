using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_ServiceTransaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage_MasterPage)Master).CheckLogin();
        if (!IsPostBack)
        {
            PageLoad();
        }
    }

    private void PageLoad()
    {
        List<DTO.tblMemberCardServiceTransaction> lsArray = BUS.tblMemberCardServiceTransaction.GetByCard_ID(((MasterPage_MasterPage)Master).Card_ID);
        gvData.DataSource = lsArray;
        gvData.DataBind();
        DTO.tblCustomerMemberCard item = BUS.tblCustomerMemberCard.GetByID(((MasterPage_MasterPage)Master).Card_ID);
        DTO.tblPointRule pointRule = BUS.tblPointRule.GetByID(2);
        lbFullName.Text = item.FullName + " - Tổng giao dịch: " + lsArray.Count.ToString("N0") + (item.TotalPoint != null ? " <br /> Tổng điểm tích lũy: " + item.TotalPoint.Value.ToString("N0") + " tương ứng " + (pointRule.ChangeRate * item.TotalPoint.Value).ToString("N0") + " VNĐ" : "");        
    }
}