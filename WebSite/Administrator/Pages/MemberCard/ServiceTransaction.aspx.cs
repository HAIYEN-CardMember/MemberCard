using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Net.Mime;
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

        ddlServicePlace_ID_Gift.DataSource = BUS.tblServicePlace.GetAll();
        ddlServicePlace_ID_Gift.DataValueField = "Place_ID";
        ddlServicePlace_ID_Gift.DataTextField = "PlaceName";
        if (ddlServicePlace_ID_Gift.Items.Count > 0)
            ddlServicePlace_ID_Gift.SelectedIndex = 0;
        ddlServicePlace_ID_Gift.DataBind();

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
        lbFullName.Text = item.FullName + " - Tổng giao dịch: " + lsArray.Count.ToString("N0") + (item.TotalPoint != null ? 
            " <br /><br /> Tổng điểm tích lũy: " + item.TotalPoint.Value.ToString("N0") + " tương ứng " : "");
        lbPoint.Text = (pointRule.ChangeRate * item.TotalPoint.Value).ToString("N0") + " VNĐ";
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
                    lbModal_Title.Text = "CẬP NHẬT GIAO DỊCH";
                    hdID.Value = item.ID.ToString();
                    lbCard_ID.Text = Request.QueryString["Card_ID"].ToString();
                    txtServiceDate.Text = item.ServiceDate.ToString("dd/MM/yyyy");
                    ddlServicePlace_ID.SelectedValue = item.ServicePlace_ID.ToString();
                    txtServiceDescription.Text = item.ServiceDescription;
                    txtServiceAmount.Text = item.ServiceAmount.ToString("N0").Replace(".", ",");
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
                String UpdateBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffID;
                int result = 0;              
                result = BUS.tblServiceTransaction.Delete(ID, UpdateBy);

                if(result == -1)
                {
                    LoadData();
                    lbCheckDelete.Text = "Dữ liệu đã phát sinh đổi điểm, không được phép XÓA!";
                }
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
            lbCheckStatus.Text = "Thẻ đang tạm khóa không thực hiện được giao dịch";
        }

        else
        {
            btnOK.Text = "Thêm mới";
            lbModal_Title.Text = "THÊM MỚI GIAO DỊCH";
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
            item.CreateBy = ((Administrator_MasterPage_MasterPageMemberCard)Master).StaffID;
            Common cm = new Common();

            int result = 0;
            result = BUS.tblServiceTransaction.Create(item);

            if (result == -1)
            {
                LoadData();
                lbError.Text = "Dữ liệu đã phát sinh đổi điểm, không được phép sửa!";                
                ModelData.Show();
            }
            else
            {
                    // Thông báo Email & SMS

                    DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(item.Card_ID);
                    if (memberCard != null && memberCard.Card_ID > 0)
                    {
                        DTO.tblCustomer customer = BUS.tblCustomer.GetByID(memberCard.Customer_ID);

                        if (customer.MobilePhone != null)
                        {
                            if (Convert.ToInt32(ddlIncrease_Decrease.SelectedItem.Value) == 1)
                            {
                                try
                                {
                                    cm.SMSSendIncreaseTransaction(customer.MobilePhone, item.ServiceAmount, Convert.ToInt16(memberCard.TotalPoint));
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }                                   
                             }
                             else                           
                             {
                                try
                                {
                                    cm.SMSSendDescreaseTransaction(customer.MobilePhone, item.ServiceAmount, Convert.ToInt16(memberCard.TotalPoint));
                                }
                                catch (Exception ex )
                                {
                                     Console.WriteLine(ex.Message);
                                }
                             }                                                        
                        }
                    
                        if (customer.Email != null && customer.Email != "")
                        {
                            try
                            {
                                cm.EmailSendTransaction(customer.Email, customer.FullName, memberCard.Card_Code, Convert.ToString(item.ServiceDate.ToString("dd/MM/yyyy")), txtServiceDescription.Text, item.ServiceAmount, Convert.ToInt16(memberCard.TotalPoint));
                                ModelData.Hide();
                                LoadData();                              
                            }
                            catch (Exception ex)
                            {}
                        }
                        else
                        {                            
                            ModelData.Hide();
                            LoadData();
                        }
                    }
                    else
                    {
                        lbError.Text = "Không tồn tại mã thẻ";
                    }
             }
           ModelData.Hide();
           LoadData();                    
        }
        else
        {
            ModelData.Show();
        }
    }

    protected void btnGivePoint_Click(object sender, EventArgs e)
    {
        txtServiceDateGift.Text = DateTime.Now.ToString("dd/MM/yyyy");
        ModelDataGift.Show();
    }

    protected void btnGift_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            int card_ID = Convert.ToInt32(Request.QueryString["Card_ID"].ToString());
            DTO.tblMemberCard memberCard = BUS.tblMemberCard.GetByID(card_ID);
            string Card_Code = memberCard.Card_Code;

            int servicePlace_ID = Convert.ToInt32(ddlServicePlace_ID_Gift.SelectedItem.Value);

            string gift_Card_Code = Convert.ToString(txtMaTheGift.Text.Trim());           
            DTO.tblMemberCard gif_memberCard = BUS.tblMemberCard.GetByCardCode(gift_Card_Code);
            int gift_Card_ID = gif_memberCard.Card_ID;

            string GifServiceDescription = "Tặng điểm cho mã: " + gift_Card_Code;
            string gif_ServiceDescription = "Nhận điểm từ mã: " + Card_Code;

            DateTime serviceDate = DateTime.ParseExact(txtServiceDateGift.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime serviceDate = Convert.ToDateTime(txtServiceDate.Text);
            int pointRec = Convert.ToInt32(txtGiftPoint.Text.Trim().Replace(",", ""));


            if (BUS.tblServiceTransaction.Gift(card_ID, Card_Code, servicePlace_ID, gift_Card_ID, gift_Card_Code, serviceDate, GifServiceDescription, gif_ServiceDescription, pointRec) > 0)
            {
                lbGiftSuccess.Text = "Tặng điểm thành công";
                ModelDataGift.Show();
                LoadData();
            }
            else
            {

                //lbGiftSuccess.Text = "";
                lbGiftError.Text = "Tặng điểm không thành công";              
                ModelDataGift.Show();
                LoadData();
            }
        }
    }
}