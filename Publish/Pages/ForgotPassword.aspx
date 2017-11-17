<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Login.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="Pages_ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-md-4"></div>
        <div class="col-md-4">
            <section class="login-form">
                <div class="formlogin">
                    <div class="page-header">
                        <h2 style="color: #2d5c8a">Quên mật khẩu ?</h2>
                    </div>
                  <label>Vui lòng nhập email, chúng tôi sẽ khởi tạo mật khẩu mới qua email của bạn</label>
                    </br>
                   
                   <small class="help-block text-center">
                       <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Vui lòng nhập email." ControlToValidate="txtUserName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                  </small>
                  <asp:TextBox ID="txtUserName" placeholder="Nhập email" class="form-control input-lg" runat="server"></asp:TextBox>
                
                    </br>
                     <div class="col-xs-offset-3 col-xs-6">
                            <small class="help-success text-left">
                                <asp:Label ID="lbSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label>
                            </small>
                         </div>
                     <div class="col-xs-offset-3 col-xs-6">
                            <small class="has-success text-center">
                                <asp:Label ID="lbError" runat="server" CssClass="label label-danger" Text=""></asp:Label>
                            </small>
                    </div>
                    </br>
                    <asp:Button ID="btnSend" class="btn btn-lg btn-info btn-block" runat="server" Text="Gửi" OnClick="btnSend_Click" />
                       <div>                             
                            <a href="index.html"><u> Đăng nhập</u> </a>
                        </div>  
                </div>                                  
            </section>
        </div>
        <div class="col-md-4"></div>
    </div>
</asp:Content>

