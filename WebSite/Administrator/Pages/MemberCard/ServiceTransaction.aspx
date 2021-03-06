﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="ServiceTransaction.aspx.cs" Inherits="Administrator_Pages_MemberCard_ServiceTransaction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

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
            <!--<div class="col-xs-4 text-right">
                <img src="../../Images/menu_icon.png" alt="" />
            </div>
            -->
            <div class="text-center">
                <h2 style="color: #31849B"><b>THÔNG TIN GIAO DỊCH BỆNH NHÂN </b></h2>
                <h3 style="color: #145367"><b>
                    <asp:Label ID="lbFullName" runat="server" Text=""></asp:Label></b><b style="color: #ff0000"><asp:Label ID="lbPoint" runat="server" Text=""></asp:Label></b></h3>
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
                             <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.UPDServiceTransaction.Edit)
                               {
                                %>                           
                            <asp:LinkButton ID="btnEdit" CommandName="btnEdit" CommandArgument='<%# Eval("ID")  %>' runat="server" CssClass="btn btn-default btn-sm">
                            <i class="glyphicon glyphicon-edit"></i>
                            </asp:LinkButton>
                             <%} %>                               
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Xóa" HeaderStyle-CssClass="text-center">                      
                        <ItemTemplate>
                             <%if (((Administrator_MasterPage_MasterPageMemberCard)Master).mPermission.UPDServiceTransaction.Delete)
                               {
                                %>                           
                            <asp:LinkButton ID="btnTrash" CommandName="btnTrash" CommandArgument='<%# Eval("ID") %>' runat="server" CssClass="btn btn-default btn-sm" OnClientClick='return confirm("Bạn có muốn xóa giao dịch này không ?");'>
                            <i class="glyphicon glyphicon-trash"></i>
                            </asp:LinkButton>
                             <%} %>                              
                        </ItemTemplate>                      
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="text-center" />
                <RowStyle CssClass="cursor-pointer" />
                <PagerStyle CssClass="pagination-ys" />
            </asp:GridView>
        </div>
        <div class="form-group form-group-sm">
            <div class="col-lg-offset-3 col-lg-6">
                <h4 style="text-align: center">
                    <asp:Label ID="lbCheckStatus" runat="server" CssClass="label label-danger" Text=""></asp:Label></h4>
                <h4 style="text-align: center">
                    <asp:Label ID="lbCheckDelete" runat="server" CssClass="label label-danger" Text=""></asp:Label></h4>
                <div class="col-lg-4">
                    <asp:Button ID="btnNew" CssClass="btn btn-block" runat="server" Text="Thêm mới" OnClick="btnNew_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" />
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="btnGivePoint" CssClass="btn btn-block" runat="server" Text="Tặng điểm" OnClick="btnGivePoint_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" />
                </div>
                <div class="col-lg-4">
                    <asp:Button ID="ButtonBack" CssClass="btn btn-block" runat="server" Text=" Trở lại " OnClick="btnBack_Click" BackColor="#31849B" BorderColor="#31849B" ForeColor="White" />
                </div>

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
                        <h3 style="color: #31849B">
                            <b>
                                <asp:Label ID="lbModal_Title" runat="server" Text=""></asp:Label></b></h3>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group form-group-sm" hidden="hidden">
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
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Dịch vụ sử dụng: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:TextBox ID="txtServiceDescription" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvServiceDescription" runat="server" ErrorMessage=" Vui lòng nhập dịch vụ sử dụng." ValidationGroup="Data" ControlToValidate="txtServiceDescription" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
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
    <asp:Button runat="server" ID="btnDataGift" Style="display: none" />
    <cc1:ModalPopupExtender ID="ModelDataGift" TargetControlID="btnDataGift" PopupControlID="pnDataGift" runat="server" CancelControlID="btnModelClose" BackgroundCssClass="ModalBackground"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnDataGift" CssClass="pnData" runat="server" align="center" Style="display: none">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <asp:Button ID="Button2" CssClass="close" runat="server" Text="x" />
                        <h3 style="color: #31849B">
                            <b>
                                <asp:Label ID="Label1" runat="server" Text="TẶNG ĐIỂM"></asp:Label></b></h3>
                    </div>
                    <div class="modal-body">
                        <div class="form-horizontal">
                            <div class="form-group form-group-sm" hidden="hidden">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Mã thẻ: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 text-left">
                                    <b>
                                        <asp:Label ID="Label2" runat="server" Text="" Font-Size="Smaller"></asp:Label></b>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Ngày giao dịch: </label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:TextBox ID="txtServiceDateGift" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvServiceDateGift" runat="server" ErrorMessage=" Vui lòng nhập ngày giao dịch." ValidationGroup="DataGift" ControlToValidate="txtServiceDateGift" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revServiceDateGift" runat="server" ValidationGroup="DataGift" ErrorMessage="Định dạng ngày không đúng" ControlToValidate="txtServiceDateGift" ValidationExpression="((0[1-9]|(1|2)[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$" CssClass="text-danger text-left" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                             <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Nơi sử dụng dịch vụ: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:DropDownList ID="ddlServicePlace_ID_Gift" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Mã thẻ tặng: </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:TextBox ID="txtMaTheGift" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMaTheGift" runat="server" ErrorMessage="Vui lòng nhập mã thẻ được tặng" ValidationGroup="DataGift" ControlToValidate="txtMaTheGift" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                </div>
                            </div>                          
                            <div class="form-group form-group-sm">
                                <label class="col-xs-12 col-sm-12 col-md-3 col-lg-3 control-label">Số điểm tặng:  </label>
                                <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9">
                                    <asp:TextBox ID="txtGiftPoint" CssClass="form-control numberInput" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvGiftPoint" runat="server" ErrorMessage="Vui lòng nhập số điểm tặng" ValidationGroup="DataGift" ControlToValidate="txtGiftPoint" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                             
                            <div class="form-group form-group-sm">
                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 text-center">
                                    <h4>
                                        <asp:Label ID="lbGiftSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label></h4>
                                    <h4>
                                        <asp:Label ID="lbGiftError" runat="server" CssClass="label label-danger" Text=""></asp:Label></h4>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnGift" CssClass="btn btn-info" data-dismiss="modal" runat="server" ValidationGroup="DataGift" Text="Tặng điểm" OnClick="btnGift_Click" />
                    </div>

                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

