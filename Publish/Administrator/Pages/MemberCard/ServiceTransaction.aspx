<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="ServiceTransaction.aspx.cs" Inherits="Administrator_Pages_MemberCard_ServiceTransaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=txtServiceDate.ClientID%>");
            dp.datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <div class="col-xs-2 text-right">
                <img src="../../Images/menu_icon.png" alt="" />
            </div>
            <div class="col-xs-10">
                <h4 style="color: #2d5c8a">Thông tin giao dịch của Khách hàng                    
                    <br />
                    <b>
                        <asp:Label ID="lbFullName" runat="server" Text=""></asp:Label>
                    </b></h4>
            </div>
            <br />
        </div>

        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <br />
            <asp:GridView ID="gvData" runat="server" CssClass="table table-hover table-striped table-bordered" GridLines="None" AutoGenerateColumns="False" HeaderStyle-CssClass="text-center"
                DataKeyNames="ID" OnRowCommand="gvData_RowCommand" AllowPaging="True" OnPageIndexChanging="gvData_PageIndexChanging" PagerSettings-Position="TopAndBottom" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="No_" HeaderText="STT" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField DataField="Card_Code" HeaderText="Mã thẻ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField DataField="ServiceDate" HeaderText="Ngày giao dịch" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="PlaceName" HeaderText="Nơi sử dụng dịch vụ" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField DataField="ServiceDescription" HeaderText="Dịch vụ sử dụng" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField DataField="Increase_Decrease" HeaderText="Loại giao dịch" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField DataField="Description" HeaderText="Cách tính điểm" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                    <asp:BoundField DataField="PointRec" HeaderText="Điểm tích lũy" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:N0}" />
                    <asp:TemplateField HeaderText="Sửa" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("ID")  %>' runat="server" CssClass="btn btn-default btn-sm">
                            <i class="glyphicon glyphicon-edit"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Xóa" HeaderStyle-CssClass="text-center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnTrash" CommandName="btnTrash" CommandArgument='<%# Eval("ID") %>' runat="server" CssClass="btn btn-default btn-sm" OnClientClick='return confirm("Bạn có muốn xóa dữ liệu này không ?");'>
                            <i class="glyphicon glyphicon-trash"></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="text-center" />
                <RowStyle CssClass="cursor-pointer" />
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <div class="form-group col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                <h4>
                    <asp:Label ID="lbCheckStatus" runat="server" CssClass="label label-danger" Text=""></asp:Label></h4>
                <asp:Button ID="btnNew" CssClass="btn btn-info" runat="server" Text="Thêm mới" OnClick="btnNew_Click" />
                <asp:Button ID="ButtonBack" CssClass="btn btn-info" runat="server" Text=" Trở lại " OnClick="btnBack_Click" />

            </div>
        </div>
    </div>
    <asp:Button runat="server" ID="btnData" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModelData" TargetControlID="btnData" PopupControlID="pnData" runat="server" CancelControlID="btnModelClose" BackgroundCssClass="ModalBackground"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnData" CssClass="pnData" runat="server" align="center" Style="display: none">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:Button ID="btnModelClose" CssClass="close" runat="server" Text="x" />
                        <h3>
                            <asp:Label ID="lbModal_Title" runat="server" Text=""></asp:Label></h3>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Mã thẻ: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 text-left">
                                    <b>
                                        <asp:Label ID="lbCard_ID" runat="server" Text="" Font-Size="Smaller"></asp:Label></b>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Ngày giao dịch: </label>
                                <asp:HiddenField ID="hdID" runat="server" />
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:TextBox ID="txtServiceDate" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvServiceDate" runat="server" ErrorMessage=" Vui lòng nhập ngày giao dịch." ValidationGroup="Data" ControlToValidate="txtServiceDate" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revServiceDate" runat="server" ValidationGroup="DataValue" ErrorMessage="Định dạng ngày không đúng" ControlToValidate="txtServiceDate" ValidationExpression="((0[1-9]|(1|2)[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" CssClass="text-danger text-left" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Nơi sử dụng dịch vụ: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:DropDownList ID="ddlServicePlace_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Dịch vụ khách sử dụng: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:TextBox ID="txtServiceDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvServiceDescription" runat="server" ErrorMessage=" Vui lòng nhập dịch vụ khách sử dụng." ValidationGroup="Data" ControlToValidate="txtServiceDescription" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Giá trị giao dịch:  </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:TextBox ID="txtServiceAmount" CssClass="form-control numberInput" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvServiceAmount" runat="server" ErrorMessage="Vui lòng số giao dịch." ValidationGroup="Data" ControlToValidate="txtServiceAmount" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Loại giao dịch: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:DropDownList ID="ddlIncrease_Decrease" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="1" Text=" (+) " Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="-1" Text=" (-) "></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Cách tính điểm:</label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:DropDownList ID="ddlPointRule_ID" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Số điểm tích lũy: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 text-left">
                                    <asp:Label ID="txtPointRec" CssClass="form-control" BackColor="Menu" runat="server"></asp:Label>
                                    <%--<asp:RequiredFieldValidator ID="rfvPointRec" runat="server" ErrorMessage="Vui lòng nhập số điểm tích lũy." ValidationGroup="Data" ControlToValidate="txtPointRec" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                                    <h4>
                                        <asp:Label ID="lbSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label></h4>
                                    <h4>
                                        <asp:Label ID="lbError" runat="server" CssClass="label label-danger" Text=""></asp:Label></h4>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnOK" CssClass="btn btn-info" data-dismiss="modal" runat="server" ValidationGroup="Data" Text="Thêm mới" OnClick="btnOK_Click" />


                    </div>

                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

