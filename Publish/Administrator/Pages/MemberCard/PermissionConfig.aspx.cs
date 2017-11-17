using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_PermissionConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PageLoad();
        }
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.AdminRight;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.View;
    }

    private void PageLoad()
    {
        ddlStaff.DataSource = BUS.tblStaff.GetAll();
        ddlStaff.DataValueField = "StaffID";
        ddlStaff.DataTextField = "StaffName";
        ddlStaff.DataBind();
        if (ddlStaff.Items.Count > 0)
            ddlStaff.SelectedIndex = 0;

        if (ddlPermission.Items.Count > 0)
            ddlPermission.SelectedIndex = 0;
        LoadPermission();

    }
    protected void ddlStaff_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPermission();
    }

    protected void ddlPermission_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadPermission();
    }
    protected void ckAdd_CheckedChanged(object sender, EventArgs e)
    {
        ckView.Checked = ckAdd.Checked ? ckAdd.Checked : ckView.Checked;
        SetPermission();
        LoadPermission();
    }
    protected void ckEdit_CheckedChanged(object sender, EventArgs e)
    {
        ckView.Checked = ckEdit.Checked ? ckEdit.Checked : ckView.Checked;
        SetPermission();
        LoadPermission();
    }
    protected void ckDelete_CheckedChanged(object sender, EventArgs e)
    {
        ckView.Checked = ckDelete.Checked ? ckDelete.Checked : ckView.Checked;
        SetPermission();
        LoadPermission();
    }

    protected void ckView_CheckedChanged(object sender, EventArgs e)
    {
        SetPermission();
        LoadPermission();
    }

    private void SetPermission()
    {
        DTO.tblStaff item = BUS.tblStaff.GetByID(ddlStaff.SelectedItem.Value);
        int i = 0;
        i += ckView.Checked ? 1 : 0;
        i += ckAdd.Checked ? 2 : 0;
        i += ckEdit.Checked ? 4 : 0;
        i += ckDelete.Checked ? 8 : 0;
        switch (ddlPermission.SelectedItem.Value)
        {
            case "UPDMember":
                item.UPDMember = i;
                break;
            case "UPDServiceTransaction":
                item.UPDServiceTransaction = i;
                break;
            case "UPDPaymentTransaction":
                item.UPDPaymentTransaction = i;
                break;
            case "UPDPointRule":
                item.UPDPointRule = i;
                break;
            case "UPDChangeCard":
                item.UPDChangeCard = i;
                break;
            case "RPTMember":
                item.RPTMember = i;
                break;
            case "RPTServiceTransaction":
                item.RPTServiceTransaction = i;
                break;
            case "RPTPaymentTransaction":
                item.RPTPaymentTransaction = i;
                break;
            case "RPTReportIncrease_Decrease":
                item.RPTReportIncrease_Decrease = i;
                break;
            case "RPTReportServiceAmount":
                item.RPTReportServiceAmount = i;
                break;
            default:
                break;
        }
        BUS.tblStaff.Create(item);
    }

    private void LoadPermission()
    {
        DTO.Permission item = BUS.Permission.Get(ddlStaff.SelectedItem.Value);
        DTO.Permission.Option option = null;
        switch (ddlPermission.SelectedItem.Value)
        {
            case "UPDMember":
                option = item.UPDMember;
                break;
            case "UPDServiceTransaction":
                option = item.UPDServiceTransaction;
                break;
            case "UPDPaymentTransaction":
                option = item.UPDPaymentTransaction;
                break;
            case "UPDPointRule":
                option = item.UPDPointRule;
                break;
            case "UPDChangeCard":
                option = item.UPDChangeCard;
                break;
            case "RPTMember":
                option = item.RPTMember;
                break;
            case "RPTServiceTransaction":
                option = item.RPTServiceTransaction;
                break;
            case "RPTPaymentTransaction":
                option = item.RPTPaymentTransaction;
                break;
            case "RPTReportIncrease_Decrease":
                option = item.RPTReportIncrease_Decrease;
                break;
            case "RPTReportServiceAmount":
                option = item.RPTReportServiceAmount;
                break;
            default:
                break;
        }

        ckView.Checked = option != null ? option.View : false;
        ckAdd.Checked = option != null ? option.Add : false;
        ckEdit.Checked = option != null ? option.Edit : false;
        ckDelete.Checked = option != null ? option.Delete : false;

        gvData.DataSource = item.GetView();
        gvData.DataBind();

    }

}