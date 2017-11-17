<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage/MasterPageMemberCard.master" AutoEventWireup="true" CodeFile="SwitchMemberCard.aspx.cs" Inherits="Administrator_Pages_MemberCard_SwitchMemberCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="clhContent" runat="Server">
    <div class="row">
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class=" col-xs-12 col-sm-12 col-md-12  col- col-lg-12 text-center">
                        <h2 style="color: #2d5c8a">Chuyển dữ liệu sang thẻ mới</h2>
                    </div>
                </div>
            </div>
        </div>
        <div class=" col-xs-12 col-sm-12 col-md-12 col- col-lg-12">
            <div class="form-horizontal">
                <div class="form-group form-group-sm">
                    <label class="col-lg-4 control-label">Mã thẻ cũ:</label>
                    <div class="col-lg-6">
                        <div class="col-lg-12">
                            <asp:Label ID="txtFrom_Card_ID" CssClass="form-control" BackColor="Menu" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <label class="col-lg-4 control-label">Mã thẻ mới:</label>
                    <div class="col-lg-6">
                        <div class="col-lg-12">
                            <asp:TextBox ID="txtTo_Card_ID" CssClass="form-control numberInput2" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTo_Card_ID" runat="server" ErrorMessage=" Vui lòng nhập mã thẻ mới." ValidationGroup="Data" ControlToValidate="txtTo_Card_ID" CssClass="help-block" Display="Dynamic" ForeColor="#C10841"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <div class="col-lg-offset-3 col-lg-6 text-center">
                        <small class="help-success">
                            <h3>
                                <asp:Label ID="lbSuccess" runat="server" CssClass="label label-success" Text=""></asp:Label></h3>
                        </small>
                        <small class="has-success">
                            <h3>
                                <asp:Label ID="lbError" runat="server" CssClass="label label-danger" Text=""></asp:Label></h3>
                        </small>
                    </div>
                </div>
                <div class="form-group form-group-sm">
                    <div class="col-lg-offset-3 col-lg-6">
                        <div class="col-lg-offset-2 col-lg-4">
                            <asp:Button ID="btnSwitch" class="btn btn-lg btn-block" runat="server" ValidationGroup="Data" Text="Chuyển đổi" OnClick="btnSwitch_Click" BackColor="#2d5c8a" BorderColor="#2d5c8a" ForeColor="White" OnClientClick='return confirm("Bạn có muốn chuyển mã thẻ cũ sang thẻ mới không ?");'/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

