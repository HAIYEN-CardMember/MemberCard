<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="AddStaff.aspx.cs" Inherits="Administrator_Pages_MemberCard_AddStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #31849B"><B>THÊM NHÂN VIÊN MỚI</B></h2>
        </div>
        <div class="col-sm-12">
            <div class="form-horizontal">
                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Mã nhân viên:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtStaffID" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStaffID" runat="server" ErrorMessage=" Vui lòng nhập mã nhân viên" ValidationGroup="Data" ControlToValidate="txtStaffID" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Họ và tên:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtStaffName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvStaffName" runat="server" ErrorMessage=" Vui lòng nhập họ và tên" ValidationGroup="Data" ControlToValidate="txtStaffName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Trung tâm: </label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:DropDownList ID="ddlPlace_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Mật khẩu:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtAccessCode" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtAccessCode" runat="server" ErrorMessage=" Vui lòng nhập mật khẩu" ValidationGroup="Data" ControlToValidate="txtAccessCode" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                        </div>
                    </div>
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
                        <div class="col-sm-4">
                            <asp:Button ID="btnAdd" class="btn btn-lg btn-block" runat="server" Text="Thêm" OnClick="btnAdd_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" />
                        </div>
                        <div class="col-sm-4">
                            <asp:Button ID="btnClear" class="btn btn-lg btn-block" runat="server" Text="Làm lại" OnClick="btnClear_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" />
                        </div>
                        <div class="col-sm-4">
                            <a href="/admin/the-thanh-vien/quan-ly-nhan-vien.html" class="btn btn-lg btn-primary btn-block">Trở lại</a>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>

