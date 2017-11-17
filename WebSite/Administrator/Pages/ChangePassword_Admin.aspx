<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword_Admin.aspx.cs" Inherits="Administrator_Pages_ChangePassword_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="form-horizontal">
                <div class="form-group">
                    </br>
                    <div class=" col-xs-12 text-center">
                        <h2 style="color: #31849B"><b>ĐỔI MẬT KHẨU</b> </h2></br>
                    </div>
                </div>
            </div>
            <div class=" col-xs-12 col-sm-12 col-md-offset-3 col-md-6 col-ld-offset-3 col- col-lg-6">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-lg-5 control-label">Mật khẩu cũ:</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="txtAccessCodeOld" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <small class="help-block">
                                <asp:RequiredFieldValidator ID="rfvAccessCodeOld" runat="server" ErrorMessage=" Vui lòng nhập mật khẩu cũ." ValidationGroup="Data" ControlToValidate="txtAccessCodeOld" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">Mật khẩu mới: </label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="txtAccessCodeNew" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <small class="help-block">
                                <asp:RequiredFieldValidator ID="rfvAccessCodeNew" runat="server" ErrorMessage=" Vui lòng nhập mật khẩu mới." ValidationGroup="Data" ControlToValidate="txtAccessCodeNew" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-lg-5 control-label">Nhập lại mật khẩu mới:</label>
                        <div class="col-lg-7">
                            <asp:TextBox ID="txtAccessCodeConfirm" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <small class="help-block">
                                <asp:RequiredFieldValidator ID="rfvAccessCodeConfirm" runat="server" ErrorMessage=" Vui lòng nhập lại mật khẩu mới." ValidationGroup="Data" ControlToValidate="txtAccessCodeConfirm" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvAccessCodeConfirm" ControlToValidate="txtAccessCodeNew" runat="server" ErrorMessage="Mật khẩu nhập lại không đúng" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" ControlToCompare="txtAccessCodeConfirm" ValidationGroup="Data"></asp:CompareValidator>
                            </small>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-offset-3 col-lg-6 text-center">
                            <small class="help-success">
                                <asp:Label ID="lbSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label>
                            </small>
                            <small class="has-success">
                                <asp:Label ID="lbError" runat="server" CssClass="label label-danger" Text=""></asp:Label>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-6 text-right">
                            <asp:Button ID="btnChange" class="btn btn-lg btn-block" runat="server" ValidationGroup="Data" Text="Đổi mật khẩu" OnClick="btnChange_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White"/>
                        </div>
                        <div class="col-md-6 text-left">    
                            <a href="/admin/the-thanh-vien/index.html" class="btn btn-lg btn-primary btn-block">Về trang chủ</a>                
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

