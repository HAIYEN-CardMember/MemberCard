﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="ServiceTransaction.aspx.cs" Inherits="Pages_ServiceTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div id="print">
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                <h2>Lịch sử giao dịch</h2>
                <h5>
                    <asp:Label ID="lbFullName" runat="server" Text=""></asp:Label></h5>
            </div>
            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                <div class="table-responsive">
                    <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="text-center">
                        <Columns>
                            <asp:BoundField DataField="No_" HeaderText="STT" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="ServiceDate" HeaderText="Ngày giao dịch" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="ServiceDescription" HeaderText="Dịch vụ sử dụng" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="PlaceName" HeaderText="Nơi sử dụng dịch vụ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="Increase_Decrease" HeaderText="Loại giao dịch" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="PointRec" HeaderText="Điểm tích lũy" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:N0}" />
                        </Columns>
                        <HeaderStyle CssClass="text-center" />
                        <RowStyle CssClass="cursor-pointer" />
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
            </div>
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <div class="form-group">
                <div class="">
                    <asp:Button ID="btnPrint" runat="server" CssClass="btn" Text="Print" OnClientClick="javascript:CallPrint('print');return false;" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                    <a href="/thong-tin-khach-hang.html" class="btn btn-primary">Trở lại</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

