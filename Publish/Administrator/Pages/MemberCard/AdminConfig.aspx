<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="AdminConfig.aspx.cs" Inherits="Administrator_Pages_AdminConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">

    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12">
                        <h2 style="color: #2d5c8a">Cấu hình hệ thống</h2>
                        <div class="col-xs-12">
                            <ul>
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.AdminRight.View)
                                  {
                                %>
                                <li><a href="/admin/the-thanh-vien/quan-ly-nhan-vien.html">Quản lý tài khoản nhân viên</a></li>
                                <%} %>
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.AdminRight.View)
                                  {
                                %>
                                <li><a href="/admin/the-thanh-vien/quan-ly-rule.html">Quản lý Rule</a></li>
                                <%} %>
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.AdminRight.View)
                                  {
                                %>
                                <li><a href="/admin/the-thanh-vien/quan-ly-phan-quyen.html">Quản lý phân quyền</a></li>
                                <%} %>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

