<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/Login.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Administrator_Pages_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">

        <div class="col-md-7">
            <br />
            <br />
            <br />
            <div style="color: #f2f2f2" class="page-header">
                <h2 style="font-weight: bold">HỆ THỐNG DÀNH CHO NHÂN VIÊN </h2>
            </div>
            <div style="color: #f2f2f2" class="modal-body table-responsive=text-right">
                Hãy sử dụng tài khoản nhân viên để đăng nhập vào hệ thống quản lý thẻ: 
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
        <div class="col-md-4">
            <br />
            <section class="login-form">
                <div class="formlogin">
                    <br />
                    <div class="head">
                        <img src="../../Images/mem2.png" alt="" />
                    </div>
                    <div class="page-header">
                        <h2 style="color: #2d5c8a">Đăng nhập</h2>
                        <h4 style="color: #2d5c8a">Hệ thống quản trị</h4>
                        <small class="help-block">
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="Vui lòng nhập mã thẻ hoặc email." ValidationGroup="Data" ControlToValidate="txtUserName" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" Font-Size="Small"></asp:RequiredFieldValidator>
                        </small>
                        <small class="help-block">
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage=" Vui lòng nhập mật khẩu." ValidationGroup="Data" ControlToValidate="txtPassword" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" Font-Size="Small"></asp:RequiredFieldValidator>
                        </small>
                        <small class="help-block">
                            <asp:Label ID="lbError" runat="server" Text="" CssClass="help-block" Display="Dynamic" ForeColor="#C10841" Font-Size="Small"></asp:Label>
                        </small>
                    </div>


                    <asp:TextBox ID="txtUserName" placeholder="Tên đăng nhập" class="form-control input-lg" runat="server"></asp:TextBox>

                    <asp:TextBox ID="txtPassword" placeholder="Nhập mật khẩu" class="form-control input-lg" ValidationGroup="Data" TextMode="Password" runat="server"></asp:TextBox>

                    <br />
                    <asp:Button ID="btnLogin" class="btn btn-lg btn-block" runat="server" ValidationGroup="Data" Text="Đăng Nhập" OnClick="btnLogin_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                </div>


                <%--   <div class="form-links">
                    <a href="#"><%=HttpContext.Current.Request.Url.AbsoluteUri.ToString()%></a>
                </div>--%>
            </section>
        </div>
        <div class="col-md-4"></div>
    </div>

</asp:Content>


