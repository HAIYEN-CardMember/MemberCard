<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="SuccessFullMemberCard.aspx.cs" Inherits="Administrator_Pages_MemberCard_SuccessFullMemberCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12">
                        <h3 style="color: #2d5c8a">Thông báo</h3>
                    </div>
                    <div class="col-xs-12">
                        <b>Bạn đã thêm thành công
                                <asp:Label ID="lbFullName" runat="server" Text=""></asp:Label>
                            với mã thẻ và mật khẩu:</b>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="col-xs-3">Mã thành viên</div>
                        <asp:Label ID="lbCard_ID" class="col-xs-9 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="col-xs-3">Mã thẻ</div>
                        <asp:Label ID="lbCard_Code" class="col-xs-9 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="col-xs-3">Mật khẩu</div>
                        <asp:Label ID="lbAccessCode" class="col-xs-9 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="col-xs-3">Điểm tích lũy</div>
                        <asp:Label ID="lbTotalPoint" class="col-xs-9 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-12">
                        <div class="col-xs-3">Ngày hết hạn</div>
                        <asp:Label ID="lbExpDate" class="col-xs-9 form-group" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-xs-4">
                        <a href="/admin/the-thanh-vien/them.html" class="btn btn-lg btn-info btn-block">Trở lại</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

