<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="RuleConfig.aspx.cs" Inherits="Administrator_Pages_MemberCard_RuleConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #2d5c8a">Quản lý luật tính điểm</h2>
        </div>

        <div class="col-sm-12">
            <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="text-center"
                AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging" PagerSettings-Position="TopAndBottom" PageSize="20">
                <Columns>

                    <asp:TemplateField HeaderText="Mã tính điểm" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <a href='/admin/the-thanh-vien-<%#Eval("Rule_ID") %>/sua-rule.html'><%#Eval("Rule_ID") %></a>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Mô tả" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <a href='/admin/the-thanh-vien-<%#Eval("Rule_ID") %>/sua-rule.html'><%#Eval("Description") %></a>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tỉ lệ" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <%#Eval("ChangeRate") %>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Increase_Decrease" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <%#Eval("Increase_Decrease") %>
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
            <div class="col-sm-offset-3 col-sm-6 text-center">
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
            <div class="col-sm-offset-3 col-sm-6">
                <div class="col-sm-6">
                    <asp:Button ID="btnAdd" class="btn btn-lg btn-primary btn-block" runat="server" Text="Thêm Rule" OnClick="btnAdd_Click" />
                </div>
                <div class="col-sm-6">
                    <a href="/admin/the-thanh-vien/cau-hinh.html" class="btn btn-lg btn-primary btn-block">Trở lại</a>
                </div>

            </div>
        </div>


    </div>


</asp:Content>

