<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="PermissionConfig.aspx.cs" Inherits="Administrator_Pages_MemberCard_PermissionConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style type="text/css">
        td {
            text-align: center;
        }

            td span input {
                text-align: center;
                vertical-align: middle;
                position: relative;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #31849B"><b>QUẢN LÝ QUYỀN TRUY CẬP</b></h2>
        </div>
        <div class="col-xs-12">
            <div class="form-horizontal">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>


                        <div class="form-group form-group-sm">
                            <label class="col-xs-2 control-label">Nhân viên:</label>
                            <div class="col-xs-10">
                                <div class="col-xs-12">
                                    <asp:DropDownList ID="ddlStaff" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlStaff_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <label class="col-xs-2 control-label">Quyền:</label>
                            <div class="col-xs-10">
                                <div class="col-xs-12">
                                    <asp:DropDownList ID="ddlPermission" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlPermission_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Value="UPDMember" Text="UPDMember"></asp:ListItem>
                                        <asp:ListItem Value="UPDServiceTransaction" Text="UPDServiceTransaction"></asp:ListItem>
                                        <asp:ListItem Value="UPDPaymentTransaction" Text="UPDPaymentTransaction"></asp:ListItem>
                                        <asp:ListItem Value="UPDPointRule" Text="UPDPointRule"></asp:ListItem>
                                        <asp:ListItem Value="UPDChangeCard" Text="UPDChangeCard"></asp:ListItem>
                                        <asp:ListItem Value="RPTMember" Text="RPTMember"></asp:ListItem>
                                        <asp:ListItem Value="RPTServiceTransaction" Text="RPTServiceTransaction"></asp:ListItem>
                                        <asp:ListItem Value="RPTPaymentTransaction" Text="RPTPaymentTransaction"></asp:ListItem>
                                        <asp:ListItem Value="RPTReportIncrease_Decrease" Text="RPTReportIncrease_Decrease"></asp:ListItem>
                                        <asp:ListItem Value="RPTReportServiceAmount" Text="RPTReportServiceAmount"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group form-group-sm">
                            <div class="col-xs-offset-2 col-xs-10">
                                <div class="col-xs-12">
                                    <div class="col-xs-3 checkbox">
                                        <asp:CheckBox ID="ckView" runat="server" Text="View" OnCheckedChanged="ckView_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                    <div class="col-xs-3 checkbox">
                                        <asp:CheckBox ID="ckAdd" runat="server" Text="Add" OnCheckedChanged="ckAdd_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                    <div class="col-xs-3 checkbox">
                                        <asp:CheckBox ID="ckEdit" runat="server" Text="Edit" OnCheckedChanged="ckEdit_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                    <div class="col-xs-3 checkbox">
                                        <asp:CheckBox ID="ckDelete" runat="server" Text="Delete" OnCheckedChanged="ckDelete_CheckedChanged" AutoPostBack="true" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlStaff" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlPermission" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ckView" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ckAdd" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ckEdit" EventName="CheckedChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ckDelete" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="col-xs-12">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="text-center"
                        DataKeyNames="Name">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                            <asp:TemplateField HeaderText="View" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cklView" Checked='<%# Convert.ToBoolean(Eval("View")) %>' runat="server" Enabled="false" ItemStyle-CssClass="text-center" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Add" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cklAdd" Checked='<%# Convert.ToBoolean(Eval("Add")) %>' runat="server" Enabled="false" ItemStyle-CssClass="text-center" CssClass="text-center" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cklEdit" Checked='<%# Convert.ToBoolean(Eval("Edit")) %>' runat="server" Enabled="false" ItemStyle-CssClass="text-center" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" HeaderStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cklDelete" Checked='<%# Convert.ToBoolean(Eval("Delete")) %>' runat="server" Enabled="false" ItemStyle-CssClass="text-center" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="text-center" />
                        <RowStyle CssClass="cursor-pointer" />
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

