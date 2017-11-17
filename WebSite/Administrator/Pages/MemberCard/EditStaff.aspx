<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="EditStaff.aspx.cs" Inherits="Administrator_Pages_MemberCard_EditStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">

    <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #31849B"><B>SỬA THÔNG TIN NHÂN VIÊN</B></h2>

        </div>

        <div class="col-sm-12">
            <div class="form-horizontal">
                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Mã nhân viên:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtStaffID" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Họ và tên:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtStaffName" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ErrorMessage=" Vui lòng nhập họ và tên." ValidationGroup="Data" ControlToValidate="txtStaffName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
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
                            <asp:LinkButton ID="lbReset" runat="server" OnClick="lbReset_Click" OnClientClick='return confirm("Bạn có muốn cấp lại mật khẩu cho nhân viên không?");'>Cấp lại mật khẩu</asp:LinkButton>
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
                            <asp:Button ID="btnEdit" class="btn btn-lg btn-block" runat="server" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" ValidationGroup="Data" Text="Cập nhật" OnClick="btnEdit_Click" OnClientClick='return confirm("Bạn có muốn cập nhật lại thông tin không?");' />
                        </div>
                        <div class="col-sm-4">
                            <asp:Button ID="btnDelete" class="btn btn-lg btn-block" runat="server" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" ValidationGroup="Data" Text="Xóa nhân viên" OnClick="btnDelete_Click" OnClientClick='return confirm("Bạn có muốn xóa nhân viên không?");' />
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

