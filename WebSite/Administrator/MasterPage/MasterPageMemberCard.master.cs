using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_MasterPage_MasterPageMemberCard : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
    }

    public DTO.Permission.EnumOption OptionRule { get; set; }
    public DTO.Permission.EnumOptionType OptionRuleType { get; set; }
    private void CheckPermission()
    {
        DTO.Permission.Option option = null;
        bool result = false;

        switch (OptionRule)
        {
            case DTO.Permission.EnumOption.None:
                result = true;
                break;
            case DTO.Permission.EnumOption.AdminRight:
                option = mPermission.AdminRight;
                break;
            case DTO.Permission.EnumOption.UPDMember:
                option = mPermission.UPDMember;
                break;
            case DTO.Permission.EnumOption.UPDServiceTransaction:
                option = mPermission.UPDServiceTransaction;
                break;
            case DTO.Permission.EnumOption.UPDPaymentTransaction:
                option = mPermission.UPDPaymentTransaction;
                break;
            case DTO.Permission.EnumOption.UPDPointRule:
                option = mPermission.UPDPointRule;
                break;
            case DTO.Permission.EnumOption.UPDChangeCard:
                option = mPermission.UPDChangeCard;
                break;
            case DTO.Permission.EnumOption.RPTMember:
                option = mPermission.RPTMember;
                break;
            case DTO.Permission.EnumOption.RPTServiceTransaction:
                option = mPermission.RPTServiceTransaction;
                break;
            case DTO.Permission.EnumOption.RPTPaymentTransaction:
                option = mPermission.RPTPaymentTransaction;
                break;
            case DTO.Permission.EnumOption.RPTReportIncrease_Decrease:
                option = mPermission.RPTReportIncrease_Decrease;
                break;
            case DTO.Permission.EnumOption.RPTReportServiceAmount:
                option = mPermission.RPTReportServiceAmount;
                break;
            default:
                break;
        }

        if (option != null)
        {
            switch (OptionRuleType)
            {
                case DTO.Permission.EnumOptionType.View:
                    result = option.View;
                    break;
                case DTO.Permission.EnumOptionType.Add:
                    result = option.Add;
                    break;
                case DTO.Permission.EnumOptionType.Edit:
                    result = option.Edit;
                    break;
                case DTO.Permission.EnumOptionType.Delete:
                    result = option.Delete;
                    break;
                default:
                    break;
            }
        }
        if (!result)
            Response.Redirect(Page.ResolveUrl("~/admin/dang-nhap.html"));
    }
    public DTO.Permission mPermission { get; set; }

    public void CheckLogin()
    {
        HttpCookie myCookie = Request.Cookies["staffInfo"];
        if (myCookie != null)
        {
            if (string.IsNullOrEmpty(myCookie.Values["StaffID"]))
            {
                Response.Redirect(Page.ResolveUrl("~/admin/dang-nhap.html"));
            }
            else
            {
                mPermission = BUS.Permission.Get(StaffID);
                CheckPermission();
                if (!string.IsNullOrEmpty(myCookie.Values["StaffName"]))
                    lbFullName.Text = Server.UrlDecode(myCookie.Values["StaffName"].ToString());
            }
        }
        else
        {
            Response.Redirect(Page.ResolveUrl("~/admin/dang-nhap.html"));
        }
    }

    public string StaffID
    {
        get
        {
            string result = "";
            HttpCookie myCookie = Request.Cookies["staffInfo"];
            if (myCookie != null)
            {
                if (!string.IsNullOrEmpty(myCookie.Values["StaffID"]))
                {
                    result = myCookie.Values["StaffID"].ToString();
                }
            }
            if (result != "")
                return result;
            return "";
        }
    }

    public string StaffName
    {
        get
        {
            string result = "";
            HttpCookie myCookie = Request.Cookies["staffInfo"];
            if (myCookie != null)
            {
                if (!string.IsNullOrEmpty(myCookie.Values["StaffName"]))
                {
                    result = Server.UrlDecode(myCookie.Values["StaffName"].ToString());
                }
            }
            if (result != "")
                return result;
            return "";
        }
    }
    public int Place_ID
    {
        get
        {
            string result = "";
            HttpCookie myCookie = Request.Cookies["staffInfo"];
            if (myCookie != null)
            {
                if (!string.IsNullOrEmpty(myCookie.Values["Place_ID"]))
                {
                    result = myCookie.Values["Place_ID"].ToString();
                }
            }
            if (result != "")
                return Convert.ToInt32(result);
            return 0;
        }
    }
    public void DownloadFile(string strFileName)
    {
        System.IO.FileInfo file = new System.IO.FileInfo(strFileName);
        if (file.Exists)
        {
            long sz = file.Length;
            Response.ClearHeaders();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}", System.IO.Path.GetFileName(strFileName)));
            Response.AddHeader("Content-Length", sz.ToString("F0"));
            Response.ContentType = "text/x-msexcel";
            Response.TransmitFile(strFileName);
            Response.Flush();
            Response.End();
        }
    }

}
