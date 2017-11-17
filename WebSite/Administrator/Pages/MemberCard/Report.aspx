<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Administrator_Pages_MemberCard_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row text-center">     
            <div class="form-horizontal text-center">
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                         <br />    <br />
                        <h2 style="color: #31849B; text-align:center"><b>BÁO CÁO KẾT QUẢ</b></h2>    <br />    <br />
                        <div class="col-xs-12">

                             <br />    <br />
                            <div class="col-lg-6">
                                 <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTMember.View)
                                  {
                                %>
                                     <a href="/admin/the-thanh-vien/bao-cao-theo-khach-hang-lam-the.html" class="my-button">DANH SÁCH LÀM THẺ</a>
                                 <%}%>
                            </div>
                             <div class="col-lg-6">
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTServiceTransaction.View)
                                  {
                                %>
                                <a href="/admin/the-thanh-vien/bao-cao-theo-so-luong-giao-dich.html" class="my-button">TỔNG SỐ GIAO DỊCH </a>
                                <%}%>
                             </div>                          
                              <br />    <br /> <br />    <br /> <br />    <br />
                            <div class="col-lg-6">
                                 <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTReportIncrease_Decrease.View)
                                  {
                                %>
                                <a href="/admin/the-thanh-vien/bao-cao-theo-tich-diem.html" class="my-button">GIAO DỊCH TÍCH ĐIỂM</a>
                                <%}%>
                            </div>
                            
                             <div class="col-lg-6">                             
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTReportServiceAmount.View)
                                  {
                                %>
                                <a href="/admin/the-thanh-vien/bao-cao-theo-tra-thuong-2.html" class="my-button">GIAO DỊCH SỬ DỤNG ĐIỂM</a>
                                <%}%>
                             </div>

                        </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>

