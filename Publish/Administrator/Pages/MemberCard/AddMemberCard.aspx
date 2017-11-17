<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="AddMemberCard.aspx.cs" Inherits="Administrator_Pages_MemberCard_AddMemberCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-sm-12 text-center">
                        <h2 style="color: #2d5c8a">
                            <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label></h2>
                    </div>
                </div>
            </div>
            <div class="col-sm-12">
                <div class="form-horizontal">
                    <div class="form-group form-group-sm">
                        <b class="col-sm-4" style="color: #2d5c8a">Thông tin khách hàng:</b>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Họ và tên:</label>
                        <div class="col-sm-10">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ErrorMessage=" Vui lòng nhập họ và tên." ValidationGroup="Data" ControlToValidate="txtFullName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Giới tính: </label>
                        <div class="col-sm-10">
                            <div class="col-sm-12">
                                <asp:DropDownList ID="ddlGender_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Ngày sinh: </label>
                        <div class="col-sm-10 text-left">
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlDay" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlYear" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Địa chỉ:</label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtAddressLine1" CssClass="form-control" placeholder="Số nhà + đường + phường xã, tổ ấp" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label class="col-sm-2 control-label">Quận, thành phố:</label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtAddressLine2" CssClass="form-control" placeholder="Quận huyện + Thành phố, tỉnh" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Di động:</label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtMobilePhone" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label class="col-sm-2 control-label">Điện thoại (nếu có):</label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtPhone2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Email:</label>
                        <div class="col-sm-10">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <b class="col-sm-4" style="color: #2d5c8a">Thông tin thẻ:</b>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Mã thẻ:</label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtCard_ID" CssClass="form-control numberInput2" Visible="false" disabled="disabled" runat="server"></asp:TextBox>
                                <asp:TextBox ID="txtCard_Code" CssClass="form-control" placeholder="Bỏ trống để tạo tự động" runat="server"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvCard_Code" runat="server" ErrorMessage=" Vui lòng nhập mã thẻ." ValidationGroup="Data" ControlToValidate="txtCard_Code" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                        <label class="col-sm-2 control-label">Loại thẻ:</label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:DropDownList ID="ddlCardType_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Ngày cấp thẻ: </label>
                        <div class="col-sm-10 text-left">
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlIssueDateDay" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlIssueDateMonth" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlIssueDateYear" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Nơi cấp: </label>
                        <div class="col-sm-10">
                            <div class="col-sm-12">
                                <asp:DropDownList ID="ddlIssuePlace_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Tên nhân viên: </label>
                        <div class="col-sm-10">
                            <div class="col-sm-12">
                                <asp:Label ID="lbIssueBy" CssClass="form-control" BackColor="Menu" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Tình trạng thẻ: </label>
                        <div class="col-sm-10">
                            <div class="col-sm-12">
                                <asp:DropDownList ID="ddlStatus_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Mã hồ sơ: </label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtEMRCode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label class="col-sm-2 control-label">Nơi lập: </label>
                        <div class="col-sm-4">
                            <div class="col-sm-12">
                                <asp:DropDownList ID="ddlEMRPlace_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-sm-2 control-label">Tổng điểm tích lũy: </label>
                        <div class="col-sm-10">
                            <div class="col-sm-12">
                                <asp:Label ID="txtTotalPoint" CssClass="form-control numberInput" BackColor="Menu" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
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
                    <div class="form-group form-group-sm">
                        <div class="col-sm-offset-3 col-sm-6">
                            <div class="col-sm-4">
                                <asp:Button ID="btnAdd" class="btn btn-lg btn-block" runat="server" ValidationGroup="Data" Text="Thêm mới" OnClick="btnAdd_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                            </div>
                            <div class="col-sm-4">
                                <asp:Button ID="btnClear" class="btn btn-lg btn-block" runat="server" Text="Làm lại" OnClick="btnClear_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                            </div>
                            <div class="col-sm-4">
                                <a href="/admin/the-thanh-vien/index.html" class="btn btn-lg btn-info btn-block">Trở lại</a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

