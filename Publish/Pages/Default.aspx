<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                        <h2>Thông tin cá nhân</h2>
                        <a href="/cap-nhat-thong-tin.html">Chỉnh sửa</a>
                    </div>
                </div>
            </div>
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-3 control-label">Họ và tên:</label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbFullname" runat="server"></asp:Label>
                        </p>
                    </div>
                </div>

                <div class="form-group">
                    <label class="col-sm-3 control-label">Giới tính: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbGender" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Ngày sinh: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbDOBYOB" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Địa chỉ: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbAddressLine" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Điện thoại: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbMobilePhone" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Email: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbEmail" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Nơi điều trị: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbPlaceName" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                        <h2>Thông tin thẻ</h2>
                        <a href="/chi-riet-giao-dich-diem.html">Xem chi tiết</a>
                    </div>
                </div>
            </div>
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="col-sm-3 control-label">Mã thẻ:</label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbCard_Code" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Loại thẻ: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbCardType_ID" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Ngày cấp thẻ: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbIssueDate" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Ngày hết hạn: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbExpDate" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Tình trạng thẻ: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbStatus_ID" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Số điểm tích lũy: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <asp:Label ID="lbTotalPoint" runat="server" Text=""></asp:Label>
                        </p>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-3 control-label">Giao dịch điểm: </label>
                    <div class="col-sm-9">
                        <p class="form-control-static">
                            <a href="/chi-riet-giao-dich-diem.html">Xem chi tiết</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

