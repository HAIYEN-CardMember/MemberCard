<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Administrator_Pages_MemberCard_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12">
                        <h2 style="color: #2d5c8a">Báo cáo kết quả quản lý thẻ</h2>
                        <div class="col-xs-12">
                            <ul>
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTMember.View)
                                  {
                                %>
                                <li><a href="/admin/the-thanh-vien/bao-cao-theo-khach-hang-lam-the.html">Báo cáo theo khách hàng làm thẻ</a></li>
                                <%}%>
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTServiceTransaction.View)
                                  {
                                %>
                                <li><a href="/admin/the-thanh-vien/bao-cao-theo-so-luong-giao-dich.html">Báo cáo theo số lượng giao dịch</a></li>
                                <%}%>
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTReportIncrease_Decrease.View)
                                  {
                                %>
                                <li><a href="/admin/the-thanh-vien/bao-cao-theo-tich-diem.html">Báo cáo theo tích điểm của khách hàng</a></li>
                                <%}%>
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.RPTReportServiceAmount.View)
                                  {
                                %>
                                <li><a href="/admin/the-thanh-vien/bao-cao-theo-tra-thuong-2.html">Báo cáo theo trả thưởng của khách hàng</a></li>
                                <%}%>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

