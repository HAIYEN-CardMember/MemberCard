﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="AddPointRule.aspx.cs" Inherits="Administrator_Pages_MemberCard_AddPointRule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">

    <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #2d5c8a">Thêm luật tính điểm</h2>
        </div>
        <div class=" col-sm-12">
            <div class="form-horizontal">
                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Mã tính điểm:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtRuleID" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRuleID" runat="server" ErrorMessage=" Vui lòng nhập mã tính điểm" ValidationGroup="Data" ControlToValidate="txtRuleID" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Mô tả:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ErrorMessage=" Vui lòng nhập mô tả" ValidationGroup="Data" ControlToValidate="txtDescription" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Tỉ lệ:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtChangeRate" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtChangeRate" runat="server" ErrorMessage=" Vui lòng nhập tỉ lệ" ValidationGroup="Data" ControlToValidate="txtChangeRate" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>

                <div class="form-group form-group-sm">
                    <label class="col-sm-2 control-label">Increase-Descrease:</label>
                    <div class="col-sm-10">
                        <div class="col-sm-12">
                            <asp:TextBox ID="txtIncrease" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIncrease" runat="server" ErrorMessage=" Vui lòng nhập Increase - Descrease" ValidationGroup="Data" ControlToValidate="txtIncrease" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>

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
                            <asp:Button ID="btnAdd" class="btn btn-lg btn-primary btn-block" runat="server" Text="Thêm" OnClick="btnAdd_Click" />
                        </div>
                        <div class="col-sm-4">
                            <asp:Button ID="btnClear" class="btn btn-lg btn-block" runat="server" Text="Làm lại" OnClick="btnClear_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                        </div>
                        <div class="col-sm-4">
                            <a href="/admin/the-thanh-vien/quan-ly-rule.html" class="btn btn-lg btn-primary btn-block">Trở lại</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>

