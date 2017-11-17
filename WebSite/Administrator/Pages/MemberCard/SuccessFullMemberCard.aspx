<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="SuccessFullMemberCard.aspx.cs" Inherits="Administrator_Pages_MemberCard_SuccessFullMemberCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                       <br /><br /> <h2 style="color: #31849B"><b>THÔNG BÁO</b></h2><br />
                    </div>
                    <div class="col-xs-12 text-center">
                        <b>Bạn đã mở thẻ thành công
                                <b style="color:red; font-size:large"><asp:Label ID="lbFullName" runat="server" Text=""></asp:Label></b>
                            với thông tin:</b>
                    </div>
                </div>
                <br/>
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                        <div class="col-xs-6">Mã thành viên</div>
                        <asp:Label ID="lbCard_ID" class="col-xs-6 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                        <div class="col-xs-6"><b>Mã thẻ</b></div>
                         <b style="color:red; font-size:medium"><asp:Label ID="lbCard_Code" class="col-xs-6 form-group" runat="server" Text=""></asp:Label></b>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                        <div class="col-xs-6"><b>Mật khẩu</b></div>
                         <b style="color:red; font-size:medium"><asp:Label ID="lbAccessCode" class="col-xs-6 form-group" runat="server" Text=""></asp:Label></b>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                        <div class="col-xs-6">Điểm tích lũy</div>
                        <asp:Label ID="lbTotalPoint" class="col-xs-6 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12 text-center">
                        <div class="col-xs-6">Ngày hết hạn</div>
                        <asp:Label ID="lbExpDate" class="col-xs-6 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group text-center">
                    <div class="col-xs-12">
                        <a href="/admin/the-thanh-vien/them.html" class="btn btn-lg btn-info">Trở lại</a>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>

