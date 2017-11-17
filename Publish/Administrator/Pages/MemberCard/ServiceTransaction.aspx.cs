using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_ServiceTransaction : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.UPDServiceTransaction;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.View;
        if (!IsPostBack)
        {
            if (Request.QueryString["Card_ID"] == null)
            {
                Response.Redirect("/admin/the-thanh-vien/index.html");
            }
            else
            {
                PageLoad();
            }
        }
    }

    private void PageLoad()
    {
        LoadData();

        ddlServicePlace_ID.DataSource = BUS.tblServicePlace.GetAll();
        ddlServicePlace_ID.DataValueField = "Place_ID";
        ddlServicePlace_ID.DataTextField = "PlaceName";
        if (ddlServicePlace_ID.Items.Count > 0)
            ddlServicePlace_ID.SelectedIndex = 0;
        ddlServicePlace_ID.DataBind();
        List<DTO.tblPointRule> lsArray = BUS.tblPointRule.GetAll();
        ddlPointRule_ID.DataSource = lsArray;
        ddlPointRule_ID.DataValueField = "Rule_ID";
        ddlPointRule_ID.DataTextField = "Description";
        for (int i = 0; i < ddlPointRule_ID.Items.Count; i++)
        {
            ListItem item = ddlPointRule_ID.Items[i];
            item.Attributes["Increase_Decrease"] = lsArray[i].Increase_Decrease.ToString();
            item.Attributes["ChangeRate"] = lsArray[i].ChangeRate.ToString();
        }
        if (ddlPointRule_ID.Items.Count > 0)
            ddlPointRule_ID.SelectedIndex = 0;
        ddlPointRule_ID.DataBind();





    }

    private void LoadData()
    {
        int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());

        List<DTO.tblMemberCardServiceTransaction> lsArray = BUS.tblMemberCardServiceTransaction.GetByCard_ID(Card_ID);
        gvData.DataSource = lsArray;
        gvData.DataBind();
        DTO.tblCustomerMemberCard item = BUS.tblCustomerMemberCard.GetByID(Card_ID);
        DTO.tblPointRule pointRule = BUS.tblPointRule.GetByID(2);
        lbFullName.Text = item.FullName + " - Tổng giao dịch: " + lsArray.Count.ToString("N0") + (item.TotalPoint != null ? " <br /> Tổng điểm tích lũy: " + item.TotalPoint.Value.ToString("N0") + " tương ứng " + (pointRule.ChangeRate * item.TotalPoint.Value).ToString("N0") + " VNĐ" : "");
    }
    protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ID = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName.Equals("btnEdit"))
        {
            if (ID != 0)
            {
                DTO.tblServiceTransaction item = BUS.tblServiceTransaction.GetByID(ID);

                if (item != null)
                {
                    btnOK.Text = "Cập nhật";
                    lbModal_Title.Text = "Cập nhật giao dịch";
                    hdID.Value = item.ID.ToString();
                    lbCard_ID.Text = Request.QueryString["Card_ID"].ToString();
                    txtServiceDate.Text = item.ServiceDate.ToString("dd/MM/yyyy");
                    ddlServicePlace_ID.SelectedValue = item.ServicePlace_ID.ToString();
                    txtServiceDescription.Text = item.ServiceDescription;
                    txtServiceAmount.Text = item.ServiceAmount.ToString("N0");
                    ddlIncrease_Decrease.SelectedValue = item.Increase_Decrease.ToString();
                    ddlPointRule_ID.SelectedValue = item.PointRule_ID.ToString();
                    txtPointRec.Text = item.PointRec.ToString();
                    ModelData.Show();
                }

            }
        }
        if (e.CommandName.Equals("btnTrash"))
        {
            if (ID != 0)
            {
                BUS.tblServiceTransaction.Delete(ID);
                LoadData();
            }
        }
    }
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        LoadData();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {

        int Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());
        DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(Card_ID);

        if (memberCard.Status_ID == 1)
        {
            lbCheckStatus.Text = "Thẻ đang tạm khóa";
        }

        else
        {
            btnOK.Text = "Thêm mới";
            lbModal_Title.Text = "Thêm mới giao dịch";
            hdID.Value = "0";
            //lbCard_ID.Text = Request.QueryString["Card_ID"].ToString();
            lbCard_ID.Text = memberCard.Card_Code;
            txtServiceDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlServicePlace_ID.SelectedIndex = 0;
            txtServiceDescription.Text = "";
            txtServiceAmount.Text = "";
            ddlIncrease_Decrease.SelectedIndex = 0;
            ddlPointRule_ID.SelectedIndex = 0;
            txtPointRec.Text = "0";
            ModelData.Show();

        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/the-thanh-vien/index.html");
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            DTO.tblServiceTransaction item = new DTO.tblServiceTransaction();
            item.Card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());
            item.ID = Convert.ToInt32(hdID.Value);
            item.ServiceDate = DateTime.ParseExact(txtServiceDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            item.ServicePlace_ID = Convert.ToInt32(ddlServicePlace_ID.SelectedItem.Value);
            item.ServiceDescription = txtServiceDescription.Text;
            item.ServiceAmount = Convert.ToInt32(txtServiceAmount.Text.Replace(",", ""));
            item.Increase_Decrease = Convert.ToInt32(ddlIncrease_Decrease.SelectedItem.Value);
            item.PointRule_ID = Convert.ToInt32(ddlPointRule_ID.SelectedItem.Value);
            item.PointRec = Convert.ToInt32(txtPointRec.Text);
            item.AutoTransferInput = true;
            if (BUS.tblServiceTransaction.Create(item) > 0)
            {
                ModelData.Hide();
                LoadData();
            }
            else
            {

                lbSuccess.Text = "";
                if (item.ID > 0)
                {
                    lbError.Text = "Cập nhật không thành công";
                }
                else
                {
                    lbError.Text = "Thêm mới không thành công";
                }
                ModelData.Show();
            }
        }
        else
        {
            ModelData.Show();
        }
    }
}