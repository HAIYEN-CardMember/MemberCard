<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="AdminConfig.aspx.cs" Inherits="Administrator_Pages_AdminConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">

    <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                        <BR /><h2 style="color: #31849B; text-align:center"><B>CÀI ĐẶT HỆ THỐNG</B></h2><BR />
                        <div class="col-xs-12">
                            <br />    <br />
                            <div class="col-lg-6">
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.AdminRight.View)
                                  {
                                %>
                                <a href="/admin/the-thanh-vien/quan-ly-nhan-vien.html" class="my-button">THÔNG TIN QUẢN TRỊ VIÊN</a>
                                <%} %>
                            </div>
                            <div class="col-lg-6">
                                  <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.AdminRight.View)
                                  {
                                %>
                               <a href="/admin/the-thanh-vien/quan-ly-rule.html" class="my-button">LUẬT TÍNH ĐIỂM</a>
                                <%} %>
                            </div>
                            <br /> <br />    <br /> <br /><br /> <br />    <br /> <br />
                             <div class="col-lg-12">
                                  <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.AdminRight.View)
                                  {
                                %>
                              <a href="/admin/the-thanh-vien/quan-ly-phan-quyen.html" class="my-button">PHÂN QUYỀN QUẢN TRỊ</a>
                                <%} %>
                             </div>

                        </div>
                    </div>
                </div>
            </div>
    </div>

</asp:Content>

