﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="ReportServiceAmount.aspx.cs" Inherits="Administrator_Pages_MemberCard_ReportServiceAmount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
     <script type="text/javascript">
         $(document).ready(function () {
             var dp = $("#<%=txtBeginDate.ClientID%>");
            dp.datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });
        $(document).ready(function () {
            var dp = $("#<%=txtEndDate.ClientID%>");
            dp.datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" Runat="Server">
   

   <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #2d5c8a">Báo cáo tích điểm thưởng</h2>
        </div>
        <div class="form-horizontal">
            <div class="col-lg-6">
                <div class="form-group form-group-sm">
                    <label class="col-lg-4 control-label">Ngày bắt đầu:</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="txtBeginDate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvBeginDate" runat="server" ErrorMessage=" Vui lòng nhập ngày bắt đầu." ValidationGroup="Data" ControlToValidate="txtBeginDate" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revBeginDate" runat="server" ValidationGroup="DataValue" ErrorMessage="Định dạng ngày không đúng" ControlToValidate="txtBeginDate" ValidationExpression="((0[1-9]|(1|2)[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" CssClass="text-danger text-left" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label class="col-lg-4 control-label">Ngày kết thúc:</label>
                    <div class="col-lg-8">
                        <asp:TextBox ID="txtEndDate" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage=" Vui lòng nhập ngày kết thúc." ValidationGroup="Data" ControlToValidate="txtEndDate" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEndDate" runat="server" ValidationGroup="DataValue" ErrorMessage="Định dạng ngày không đúng" ControlToValidate="txtEndDate" ValidationExpression="((0[1-9]|(1|2)[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" CssClass="text-danger text-left" Display="Dynamic"></asp:RegularExpressionValidator>

                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label class="col-lg-4 control-label">Trung tâm:</label>
                    <div class="col-lg-8">
                        <asp:DropDownList ID="ddlServicePlace_ID" CssClass="form-control" runat="server"></asp:DropDownList>

                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="form-group form-group-sm">
                    <div class="col-lg-4">
                        <asp:Button ID="btnGet" CssClass="btn form-control" runat="server" Text="Xem báo cáo" OnClick="btnGet_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                    </div>
                    <div class="col-lg-4">
                        <asp:Button ID="btnExport" CssClass="btn form-control" runat="server" Text="Xuất ra file" OnClick="btnExport_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                    </div>
                    <div class="col-lg-4">
                        <asp:Button ID="btnBack" CssClass="btn form-control" runat="server" Text="Trở lại" OnClick="btnBack_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="col-xs-1">
            </div>
            <div class="col-xs-11">
                <h4 style="color: #2d5c8a">
                    <img src="../../../Images/calendar.png" alt="" />
                    <asp:Label ID="lbResult" runat="server" Text="Kết quả"></asp:Label>
                </h4>
            </div>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="col-xs-1">
            </div>
            <div class="col-xs-10">
                <h5 style="color: #2d5c8a">
                    <asp:Literal ID="lDanhSach" runat="server"></asp:Literal>
                </h5>
                <br />
            </div>

        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="text-center"
                AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging" PagerSettings-Position="TopAndBottom" PageSize="20">
                <Columns>
                    <%--<asp:BoundField DataField="No_" HeaderText="STT" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />--%>
                    <asp:BoundField DataField="ServiceDate" HeaderText="Ngày giao dịch" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Card_Code" HeaderText="Mã thẻ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField DataField="FullName" HeaderText="Tên khách hàng" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                    <asp:BoundField DataField="ServiceDescription" HeaderText="Dịch vụ sử dụng" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                    <asp:BoundField DataField="ServiceAmount" HeaderText="Giá trị tiền" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:N0}" />
                    <asp:BoundField DataField="PointRec" HeaderText="Điểm" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:N0}" />
                      <%--<asp:BoundField DataField="PlaceName" HeaderText="Nơi sử dụng dịch vụ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />--%>
                      <%--<asp:BoundField DataField="Increase_Decrease" HeaderText="Loại giao dịch" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />--%>
                    
                </Columns>
                <HeaderStyle CssClass="text-center" />
                <RowStyle CssClass="cursor-pointer" />
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>

</asp:Content>

