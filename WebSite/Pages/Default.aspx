<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row text-left">
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 text-center">
                <div class="form-group text-left" style="margin-left:50px">
                         <div class="form-group text-center" style="margin-left:-60px">
                            <h2 style="color:#31849B; font-weight:bold">THÔNG TIN CÁ NHÂN</h2>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="/cap-nhat-thong-tin.html">Chỉnh sửa </a>
                         </div><br />

                        <div class="text-left"><label class="col-sm-6 control-label text-left">Họ và tên:</label></div>
                        <div class="col-sm-6 text-left">                       
                                <asp:Label ID="lbFullname" runat="server"></asp:Label><br />
                        </div> 
                    
                        <br /><div class="text-left"><br /><label class="col-sm-6 control-label">Giới tính: </label></div>
                        <div class="col-sm-6 text-left">                       
                                <asp:Label ID="lbGender" runat="server" Text=""></asp:Label>
                        </div>
                     
                        <br /><div class="text-left"><br />  <label class="col-sm-6 control-label">Ngày sinh: </label></div>
                         <div class="col-sm-6 text-left">
                                <asp:Label ID="lbDOBYOB" runat="server" Text=""></asp:Label>
                        </div>

                        <br /><div class="text-left"><br /> <label class="col-sm-6 control-label">Địa chỉ: </label></div>
                         <div class="col-sm-6 text-left">
                                <asp:Label ID="lbAddressLine" runat="server" Text=""></asp:Label>
                        </div>

                         <br /><div class="text-left"><br /><label class="col-sm-6 control-label">Điện thoại: </label></div>
                         <div class="col-sm-6 text-left">
                                <asp:Label ID="lbMobilePhone" runat="server" Text=""></asp:Label>
                        </div>

                         <br /><div class="text-left"><br /><label class="col-sm-6 control-label">Email: </label></div>
                        <div class="col-sm-6 text-left">                       
                                <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label> <br />
                        </div>

                         <br /><div class="text-left"><br /><label class="col-sm-6 control-label">Nơi điều trị: </label></div>
                        <div class="col-sm-6 text-left">                      
                                <asp:Label ID="lbPlaceName" runat="server" Text=""></asp:Label> <br />
                        </div>
                </div>
            </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 text-center">
            <div class="form-group text-left" style="margin-left:50px"">
                    <div class="form-group text-center" style="margin-right:100px">
                            <h2 style="color:#31849B; font-weight:bold">THÔNG TIN THẺ</h2>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <a href="/chi-riet-giao-dich-diem.html">Xem chi tiết</a>
                    </div><br />

                    <div class="text-left"><label class="col-sm-6 control-label text-left">Mã thẻ:</label></div>
                    <div class="col-sm-6 text-left">                        
                                <asp:Label ID="lbCard_Code" runat="server" Text=""></asp:Label><br />
                    </div>
                    
                     <br /><div class="text-left"><br /><label class="col-sm-6 control-label">Loại thẻ: </label></div>
                        <div class="col-sm-6 text-left">
                            <asp:Label ID="lbCardType_ID" runat="server" Text=""></asp:Label>
                    </div>
                    
                     <br /><div class="text-left"><br /><label class="col-sm-6 control-label">Ngày cấp thẻ: </label> </div>
                         <div class="col-sm-6 text-left">
                       
                                        <asp:Label ID="lbIssueDate" runat="server" Text=""></asp:Label>
                                </div>

                         <br /><div class="text-left"> <br /><label class="col-sm-6 control-label">Ngày hết hạn: </label> </div>
                        <div class="col-sm-6 text-left">
                            <asp:Label ID="lbExpDate" runat="server" Text=""></asp:Label>
                        </div>

                        <br /><div class="text-left"><br /> <label class="col-sm-6 control-label">Tình trạng thẻ: </label></div>

                           <div class="col-sm-6 text-left">
                       
                            <asp:Label ID="lbStatus_ID" runat="server" Text=""></asp:Label>
                        </div>

                        <br /><div class="text-left"><br /><b style="color:red"><label class="col-sm-6 control-label">Điểm tích lũy: </label></b> </div>
                         <div class="col-sm-6 text-left">                       
                           <b style="color:red"><asp:Label ID="lbTotalPoint" runat="server" Text=""></asp:Label></b>
                         </div>
                   </div>    
              </div>             
        </div>
</asp:Content>

