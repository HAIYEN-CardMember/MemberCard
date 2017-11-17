<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrator_Pages_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="control-group">
            <a href="/admin/the-thanh-vien/index.html">
                <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                    <div class="col-xs-6">
                        <img src="../../Images/icon_card.png" class="img-responsive" />
                    </div>
                    </br></br></br>
                <label class="col-xs-6 control-label text-left text-uppercase">
                    <h3 style="color: #2d5c8a">Thẻ Thành Viên</h3>
                </label>
                </div>
            </a>

            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <div class="col-xs-6">
                    <img src="../../Images/icon_calendar.png" class="img-responsive" />
                </div>
                </br></br></br></br>
                <label class="col-xs-6 control-label text-left text-uppercase">
                    <h3 style="color: #2d5c8a">Đặt Lịch Khám</h3>
                </label>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <div class="col-xs-6">
                    <img src="../../Images/icon_email.png" class="img-responsive" />
                </div>
                </br></br></br></br></br>
                <label class="col-xs-6 control-label text-left text-uppercase">
                    <h3 style="color: #2d5c8a">EMAIL MARKETING</h3>
                </label>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6">
                <div class="col-xs-6">
                    <img src="../../Images/icon_livechat.png" class="img-responsive" />
                </div>
                </br></br></br>
                <label class="col-xs-6 control-label text-left text-uppercase">
                    <h3 style="color: #2d5c8a">Tư Vấn </br> Trực Tuyến</h3>
                </label>
            </div>
        </div>
    </div>
</asp:Content>

