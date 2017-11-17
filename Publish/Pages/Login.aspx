﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Login.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-md-4 col-md-push-8">
            <section class="login-form">

                <div class="formlogin">
                    <div class="head">
                        <img src="/Images/mem2.png" alt="" />
                    </div>
                    <div class="page-header">

                        <div style="color: #2d5c8a">
                            <h2>Đăng nhập</h2>
                        </div>
                        <small class="help-block text-center">
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Vui lòng nhập mã thẻ hoặc email" ValidationGroup="Data" ControlToValidate="txtUserName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" Font-Size="Small"></asp:RequiredFieldValidator>
                        </small>
                        <small class="help-block text-center">
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage=" Vui lòng nhập mật khẩu" ValidationGroup="Data" ControlToValidate="txtPassword" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" Font-Size="Small"></asp:RequiredFieldValidator>
                        </small>
                        <small class="help-block text-center">
                            <asp:Label ID="lbError" runat="server" Text="" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" Font-Size="Small"></asp:Label>
                        </small>
                    </div>

                    <asp:TextBox ID="txtUserName" placeholder="Nhập Card ID hoặc Email" class="form-control input-lg" runat="server"></asp:TextBox>

                    <asp:TextBox ID="txtPassword" placeholder="Nhập Access Code" class="form-control input-lg" ValidationGroup="Data" TextMode="Password" runat="server"></asp:TextBox>

                    <div>
                        <asp:CheckBox ID="ckRemeber" Text="&nbsp&nbspGhi nhớ đăng nhập" runat="server" />
                    </div>

                    <div>
                        Quên mật khẩu? Nhấn vào <a href="/quen-mat-khau.html">đây</a>
                    </div>
                    <asp:Button ID="btnLogin" class="btn btn-lg btn-block" runat="server" ValidationGroup="Data" Text="Đăng Nhập" OnClick="btnLogin_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                </div>
            </section>
        </div>
        <div class="col-md-7 col-md-pull-4">
            <br />
            <br />
            <br />
            <div style="color: #f2f2f2" class="page-header">
                <h2 style="font-weight: bold">Hệ thống thẻ thành viên </h2>
            </div>
            <div style="color: #f2f2f2" class="modal-body table-responsive=text-right">
                Chào mừng bạn đến với hệ thống thẻ thành viên trong chuỗi hệ thống HYGroup: 
           <br />
                <br />
            </div>
            <div class="col-xs-12">
                <div class="col-xs-12" style="color: #f2f2f2">

                    <h3 style="font-weight: bold">- Trung tâm Mắt kỹ thuật cao 30-4:</h3>
                    Địa chỉ: số 9 Sư Vạn Hạnh, Phường 9, Quận 5, Tp.HCM<br />
                    Điện thoại: 1800 7272 - (08) 3833 3369<br />
                    <br />
                    <br />
                    <h3 style="font-weight: bold">- Trung tâm Mắt Hải Yến:</h3>
                    Địa chỉ: số 31A Nguyễn Đình Chiểu, Phường ĐaKao, Quận 1, Tp.HCM<br />
                    Điện thoại: 0913 666 665 - (08) 6686 1396<br />
                    <br />
                    <br />
                    <h3 style="font-weight: bold">- Trung tâm Mắt kỹ thuật cao An Sinh: </h3>
                    Địa chỉ: số 10 Trần Huy Liệu, Quận Phú Nhuận, Tp.HCM<br />
                    Điện thoại: (08) 3844 8523 - (08) 3845 3869<br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

