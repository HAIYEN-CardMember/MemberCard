<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Administrator_Pages_MemberCard_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style type="text/css">
        .noi_cap {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="page-header text-center">
            <h2 style="color: #31849B"><b>HỆ THỐNG QUẢN LÝ THẺ</b></h2>
        </div>
        <div class="form-horizontal">
            <div class="form-group-sm">
                <div class="col-xs-2">
                    <asp:TextBox ID="txtTenKhachHang" CssClass="form-control" placeholder="Tên khách hàng" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:TextBox ID="txtMaThe" CssClass="form-control" placeholder="Mã thẻ" runat="server"></asp:TextBox><!--numberInput1-->
                </div>
                <div class="col-xs-2">
                    <asp:TextBox ID="txtMobilePhone" CssClass="form-control" placeholder="Số điện thoại" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-2">
                    <asp:Button ID="btnSearch" CssClass="btn form-control" runat="server" Text="Tìm" OnClick="btnSearch_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" />
                </div>
                <div class="col-xs-2">
                    <asp:Button ID="btnClear" CssClass="btn form-control" runat="server" Text="Xóa" OnClick="btnClear_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" />
                </div>
                <div class="col-xs-2">
                    <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.UPDMember.Add)
                      {
                    %>
                    <a href="/admin/the-thanh-vien/them.html" class="btn btn-info form-control">Thêm mới</a>
                    <%} %>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="text-center"
                AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging" PagerSettings-Position="TopAndBottom" PageSize="20" OnRowDataBound="gvData_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="No_" HeaderText="STT" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:TemplateField HeaderText="Mã thẻ" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>

                            <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.UPDServiceTransaction.View)
                              {
                            %>
                            <a href='/admin/thong-tin-giao-dich-khach-hang/<%#Eval("Card_ID") %>.html'><%#Eval("Card_Code") %></a>
                            <% }
                              else
                              {   %>
                            <%#Eval("Card_Code") %>
                            <% } %>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tên khách hàng" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.UPDMember.Edit)
                              {
                            %>
                            <a href='/admin/the-thanh-vien-<%#Eval("Card_ID") %>/chinh-sua.html'><%#Eval("FullName") %></a>                             
                            <% }
                              else
                              {   %>
                            <%#Eval("FullName") %>
                            <% } %>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-left" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MobilePhone" HeaderText="Số điện thoại" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />                    
                    <asp:BoundField DataField="IssueDate" HeaderText="Ngày cấp" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="ExpDate" HeaderText="Ngày hết hạn" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:TemplateField HeaderText="Nơi cấp" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left">
                        <ItemTemplate>
                            <!-- <div class="noi_cap" style='color: <%#Eval("Color") %>'> -->
                            <div class="noi_cap">
                                <%#Eval("PlaceName") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Điểm tích lũy" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right">
                        <ItemTemplate>
                            <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.UPDServiceTransaction.View)
                              {
                            %>
                            <a href='/admin/thong-tin-giao-dich-khach-hang/<%#Eval("Card_ID") %>.html'><%#Eval("TotalPoint", "{0:N0}") %></a>
                            <% }
                              else
                              {   %>
                            <%#Eval("TotalPoint", "{0:N0}") %>
                            <% } %>
                        </ItemTemplate>
                        <ItemStyle CssClass="text-center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="Tình trạng thẻ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    
                </Columns>
                <HeaderStyle CssClass="text-center" />
                <RowStyle CssClass="cursor-pointer" />
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>

