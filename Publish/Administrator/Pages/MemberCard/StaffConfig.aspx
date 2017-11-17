<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="StaffConfig.aspx.cs" Inherits="Administrator_Pages_MemberCard_StaffConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #2d5c8a">Quản lý tài khoản nhân viên</h2>

        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="text-center"
                AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging" PagerSettings-Position="TopAndBottom" PageSize="20">
                <Columns>
                    <%-- <asp:BoundField DataField="No_" HeaderText="STT" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" /> --%>
                    <%-- <asp:BoundField DataField="StaffID" HeaderText="Mã nhân viên" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/> --%>
                    <asp:TemplateField HeaderText="Mã nhân viên" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <a href='/admin/the-thanh-vien-<%#Eval("StaffID") %>/sua-nhan-vien.html'><%#Eval("StaffID") %></a>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tên nhân viên" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <a href='/admin/the-thanh-vien-<%#Eval("StaffID") %>/sua-nhan-vien.html'><%#Eval("StaffName") %></a>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mật khẩu" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                        <ItemTemplate>
                            <a href='/admin/the-thanh-vien-<%#Eval("StaffID") %>/sua-nhan-vien.html'>Cấp lại mật khẩu</a>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>

                </Columns>
                <HeaderStyle CssClass="text-center" />
                <RowStyle CssClass="cursor-pointer" />
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
        <div class="form-group form-group-sm">
            <div class="col-lg-offset-3 col-lg-6 text-center">
                <small class="help-success">
                    <h3>
                        <asp:Label ID="lbSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label></h3>
                </small>
                <small class="has-success">
                    <h3>
                        <asp:Label ID="lbError" runat="server" CssClass="label label-danger" Text=""></asp:Label></h3>
                </small>

            </div>
        </div>
        <div class="form-group form-group-sm">
            <div class="col-lg-offset-3 col-lg-6">
                <div class="col-lg-4">
                    <asp:Button ID="btnAdd" class="btn btn-lg btn-primary btn-block" runat="server" Text="Thêm nhân viên" OnClick="btnAdd_Click" />
                </div>
                <div class="col-lg-4">
                    <a href="/admin/the-thanh-vien/cau-hinh.html" class="btn btn-lg btn-primary btn-block">Trở lại</a>
                </div>

            </div>
        </div>

    </div>
</asp:Content>

