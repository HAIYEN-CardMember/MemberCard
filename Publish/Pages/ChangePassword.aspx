﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="Pages_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-sm-8 col-sm-offset-2 text-center">
                        <h2 style="color: #2d5c8a">Đổi mật khẩu</h2>
                    </div>
                </div>
            </div>
            <div class="col-sm-8 col-sm-offset-2">
                <div class="form-horizontal">
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Mật khẩu cũ:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAccessCodeOld" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <small class="help-block">
                                <asp:RequiredFieldValidator ID="rfvAccessCodeOld" runat="server" ErrorMessage=" Vui lòng nhập mật khẩu cũ." ValidationGroup="Data" ControlToValidate="txtAccessCodeOld" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Mật khẩu mới: </label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAccessCodeNew" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <small class="help-block">
                                <asp:RequiredFieldValidator ID="rfvAccessCodeNew" runat="server" ErrorMessage=" Vui lòng nhập mật khẩu mới." ValidationGroup="Data" ControlToValidate="txtAccessCodeNew" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-4 control-label">Nhập lại mật khẩu mới:</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtAccessCodeConfirm" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                            <small class="help-block">
                                <asp:RequiredFieldValidator ID="rfvAccessCodeConfirm" runat="server" ErrorMessage=" Vui lòng nhập lại mật khẩu mới." ValidationGroup="Data" ControlToValidate="txtAccessCodeConfirm" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvAccessCodeConfirm" ControlToValidate="txtAccessCodeNew" runat="server" ErrorMessage="Mật khẩu nhập lại không đúng" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" ControlToCompare="txtAccessCodeConfirm" ValidationGroup="Data"></asp:CompareValidator>
                            </small>

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-6 text-center">
                            <small class="help-success">
                                <asp:Label ID="lbSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label>
                            </small>
                            <small class="has-success">
                                <asp:Label ID="lbError" runat="server" CssClass="label label-danger" Text=""></asp:Label>
                            </small>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-sm-offset-3 col-sm-6 text-center">
                            <asp:Button ID="btnChange" class="btn btn-lg btn-block" runat="server" ValidationGroup="Data" Text="Đổi mật khẩu" OnClick="btnChange_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
