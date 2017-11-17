<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Information.aspx.cs" Inherits="Pages_Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">

    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                        <h2>Cập nhật thông tin</h2>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-8 col-md-offset-2 col-lg-8 col-lg-offset-2">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Họ và tên:</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                            <small class="help-block">
                                <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ErrorMessage=" Vui lòng nhập họ và tên." ValidationGroup="Data" ControlToValidate="txtFullName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Giới tính: </label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlGender_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Ngày sinh: </label>
                        <div class="col-sm-10">
                            <div class="row">
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlDay" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlYear" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Địa chỉ:</label>
                        <div class="col-sm-10">
                            <div class="row">
                                <div class="col-xs-12">
                                    <asp:TextBox ID="txtAddressLine1" CssClass="form-control" placeholder="Số nhà + đường + phường xã, tổ ấp" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-xs-12">
                                    <asp:TextBox ID="txtAddressLine2" CssClass="form-control" placeholder="Quận huyện + Thành phố, tỉnh" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Điện thoại:</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtMobilePhone" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvMobilePhone" runat="server" ErrorMessage="Vui lòng nhập số điện thoại" ValidationGroup="InputData" ControlToValidate="txtMobilePhone" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revMobilePhone" runat="server" ErrorMessage="Số điện thoại không đúng" ControlToValidate="txtMobilePhone" ValidationExpression="^([0-9]{10,11})$" ForeColor="#C10841" ValidationGroup="Data" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Email:</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" CssClass="help-block" ErrorMessage="Email không đúng" ValidationGroup="Data" Display="Dynamic" ForeColor="#C10841"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-2 control-label">Nơi điều trị:</label>
                        <div class="col-sm-10">
                            <asp:Label ID="lbEMRPlace_ID" runat="server" CssClass="form-control" BackColor="Menu" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-6 text-center">
                            <small class="help-success">
                                <h3>
                                    <asp:Label ID="lbSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label>
                                </h3>
                            </small>
                            <small class="has-success">
                                <h3>
                                    <asp:Label ID="lbError" runat="server" CssClass="label label-danger" Text=""></asp:Label>
                                </h3>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-2 col-sm-10">
                            <div class="row">
                                <asp:Button ID="btnUpdate" class="btn btn-primary" runat="server" ValidationGroup="Data" Text="Lưu lại" OnClick="btnUpdate_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                                <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" ValidationGroup="Data" Text="Hủy" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>


