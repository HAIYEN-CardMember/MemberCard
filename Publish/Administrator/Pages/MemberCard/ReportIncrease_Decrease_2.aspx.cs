using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Pages_MemberCard_ReportIncrease_Decrease : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRule = DTO.Permission.EnumOption.RPTReportIncrease_Decrease;
        ((Administrator_MasterPage_MasterPageMemberCard)Master).OptionRuleType = DTO.Permission.EnumOptionType.View;

        if (!IsPostBack)
        {
            PageLoad();
        }
       
    }

    private void PageLoad()
    {
        txtBeginDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtEndDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

        // List<DTO.tblServicePlace> lsArray = BUS.tblServicePlace.GetAll();
        // lsArray.Insert(0, new DTO.tblServicePlace() { Place_ID = 0, PlaceName = "Tất cả" });
        // ddlServicePlace_ID.DataSource = lsArray;
        // ddlServicePlace_ID.DataValueField = "Place_ID";
        // ddlServicePlace_ID.DataTextField = "PlaceName";
        // if (ddlServicePlace_ID.Items.Count > 0)
        //     ddlServicePlace_ID.SelectedIndex = 0;
        // ddlServicePlace_ID.DataBind();
    }

    protected void btnGet_Click(object sender, EventArgs e)
    {
        LoadData();

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/the-thanh-vien/bao-cao.html");
    }

    private void LoadData()
    {
        lDanhSach.Text = "";
        DateTime s = DateTime.ParseExact(txtBeginDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime e = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        // int Place_ID = Convert.ToInt32(ddlServicePlace_ID.SelectedItem.Value);

        // List<DTO.tblMemberCardServiceTransaction> lsArray = BUS.tblMemberCardServiceTransaction.GetViewShare(s, e);
        //lbResult.Text = String.Format("Từ ngày {0:dd/MM/yyyy} đến {1:dd/MM/yyyy} có {2:N0} giao dịch:", s, e, lsArray.Count);


        gvData.DataSource = BUS.tblMemberCardServiceTransaction.SharePivotView(s, e);
        gvData.DataBind();

    }
    protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvData.PageIndex = e.NewPageIndex;
        LoadData();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DateTime sta = DateTime.ParseExact(txtBeginDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime end = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        //int Place_ID = Convert.ToInt32(ddlServicePlace_ID.SelectedItem.Value);
        System.Data.DataSet ds = new System.Data.DataSet();
        System.Data.DataTable dt = BUS.tblMemberCardServiceTransaction.SharePivotView(sta, end);
       // dt.Columns.Remove("ID");
        //dt.Columns.Remove("SharePlaceID");
       // dt.Columns.Remove("PaymentAtID");
        //dt.Columns["No_"].ColumnName = "STT";
        dt.Columns.Remove("Card_ID");
        dt.Columns["Card_Code"].ColumnName = "Mã thẻ";
        dt.Columns["FullName"].ColumnName = "Tên khách hàng";
        dt.Columns["ServiceDate"].ColumnName = "Ngày giao dịch";
        dt.Columns["PaymentAtName"].ColumnName = "Trả thưởng tại";
        dt.Columns["ServiceDescription"].ColumnName = "Dịch vụ sử dụng";
        dt.Columns["ServiceAmount"].ColumnName = "Trả thưởng";
        dt.Columns["MAT304"].ColumnName = "Hitec304";
        dt.Columns["MATHYEC"].ColumnName = "HYEC";
        dt.Columns["MATANSINH"].ColumnName = "HitecAS";
        dt.TableName = "Bao_Cao_Tra_Thuong";
        ds.Tables.Add(dt);
        if (!System.IO.Directory.Exists(Server.MapPath("\\Output")))
            System.IO.Directory.CreateDirectory(Server.MapPath("\\Output"));
        string Path = Server.MapPath(String.Format("\\Output\\{0}_{1}.xlsx", "Bao_Cao_Tra_Thuong", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")));
        Utilities.ExportData.Save(ds, Path);
        ((Administrator_MasterPage_MasterPageMemberCard)Page.Master).DownloadFile(Path);


    }

}