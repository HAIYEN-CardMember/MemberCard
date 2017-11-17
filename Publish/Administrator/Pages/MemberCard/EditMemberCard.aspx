<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="EditMemberCard.aspx.cs" Inherits="Administrator_Pages_MemberCard_EditMemberCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class=" col-xs-12 col-sm-12 col-md-12  col- col-lg-12 text-center">
                        <h2 style="color: #2d5c8a">
                            <asp:Label ID="lbTitle" runat="server" Text=""></asp:Label></h2>
                    </div>
                </div>
            </div>
            <div class=" col-xs-12 col-sm-12 col-md-12  col- col-lg-12">
                <div class="form-horizontal">
                    <div class="form-group form-group-sm">
                        <b class="col-lg-2" style="color: #2d5c8a">Thông tin khách hàng:</b>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Họ và tên:</label>
                        <div class="col-lg-10">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ErrorMessage=" Vui lòng nhập họ và tên." ValidationGroup="Data" ControlToValidate="txtFullName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Giới tính: </label>
                        <div class="col-lg-10">
                            <div class="col-lg-12">
                                <asp:DropDownList ID="ddlGender_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Ngày sinh: </label>
                        <div class="col-lg-10 text-left">
                            <div class="col-lg-3">
                                <asp:DropDownList ID="ddlDay" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <asp:DropDownList ID="ddlMonth" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <asp:DropDownList ID="ddlYear" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Địa chỉ:</label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtAddressLine1" CssClass="form-control" placeholder="Số nhà + đường + phường xã, tổ ấp" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label class="col-lg-2 control-label">Quận, thành phố:</label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtAddressLine2" CssClass="form-control" placeholder="Quận huyện + Thành phố, tỉnh" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Di động:</label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtMobilePhone" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label class="col-lg-2 control-label">Điện thoại (nếu có):</label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtPhone2" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Email:</label>
                        <div class="col-lg-10">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <b class="col-lg-2" style="color: #2d5c8a">Thông tin thẻ:</b>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Mã thẻ:</label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:Label ID="txtCard_ID" CssClass="form-control" Visible="false" BackColor="Menu" runat="server"></asp:Label>
                                <asp:Label ID="txtCard_Code" CssClass="form-control" BackColor="Menu" runat="server"></asp:Label>
                            </div>
                        </div>
                        <label class="col-lg-2 control-label">Loại thẻ:</label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:DropDownList ID="ddlCardType_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Mật khẩu:</label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:LinkButton ID="lbReset" runat="server" OnClick="lbReset_Click" OnClientClick='return confirm("Bạn có muốn cập nhật mật khẩu này không ?");'>Reset Access Code</asp:LinkButton>

                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Ngày cấp thẻ: </label>
                        <div class="col-lg-10 text-left">
                            <div class="col-lg-3">
                                <asp:DropDownList ID="ddlIssueDateDay" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <asp:DropDownList ID="ddlIssueDateMonth" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <asp:DropDownList ID="ddlIssueDateYear" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Nơi cấp: </label>
                        <div class="col-lg-10">
                            <div class="col-lg-12">
                                <asp:DropDownList ID="ddlIssuePlace_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Tên nhân viên: </label>
                        <div class="col-lg-10">
                            <div class="col-lg-12">
                                <asp:Label ID="lbIssueBy" CssClass="form-control" BackColor="Menu" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Tình trạng thẻ: </label>
                        <div class="col-lg-10">
                            <div class="col-lg-12">
                                <asp:DropDownList ID="ddlStatus_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Mã hồ sơ: </label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtEMRCode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <label class="col-lg-2 control-label">Nơi lập: </label>
                        <div class="col-lg-4">
                            <div class="col-lg-12">
                                <asp:DropDownList ID="ddlEMRPlace_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-group-sm">
                        <label class="col-lg-2 control-label">Tổng điểm tích lũy: </label>
                        <div class="col-lg-10">
                            <div class="col-lg-12">
                                <asp:Label ID="txtTotalPoint" CssClass="form-control numberInput" BackColor="Menu" runat="server"></asp:Label>
                            </div>
                        </div>
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
                            <div class="col-lg-6">
                                <asp:Button ID="btnEdit" class="btn btn-lg btn-primary btn-block" runat="server" ValidationGroup="Data" Text="Cập nhật" OnClick="btnEdit_Click" OnClientClick='return confirm("Bạn có muốn cập nhật lại thông tin không ?");' />
                            </div>
                            <div class="col-lg-6">
                                <a href="/admin/the-thanh-vien/index.html" class="btn btn-lg btn-primary btn-block">Trở lại</a>
                            </div>
                            <div class="col-lg-4 hide">
                                <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.UPDChangeCard.Edit)
                                  {
                                %>
                                <asp:HyperLink ID="lkSwichCard" CssClass="btn btn-lg btn-primary btn-block" Text="Chuyển mã thẻ" runat="server" />
                                <%} %>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

