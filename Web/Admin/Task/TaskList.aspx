﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskList.aspx.cs" Inherits="Maticsoft.Web.Admin.Task.TaskList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        .f-grid-cell[data-color=color1] {
            background-color: #0094ff;
            color: #fff;
        }

        .f-grid-cell[data-color=color2] {
            background-color: #eb8334;
            color: #fff;
        }

        .f-grid-cell[data-color=color3] {
            background-color: #ff0000;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="Panel1" runat="server" />
        <f:Panel ID="Panel1" CssClass="blockpanel" Margin="10px" runat="server" ShowBorder="false" ShowHeader="false" Layout="Region">
            <Items>


                <f:Grid ID="GridDpt" runat="server" ShowBorder="false" ShowHeader="false" OnPageIndexChange="GridDpt_PageIndexChange" OnPreRowDataBound="GridDpt_PreRowDataBound"
                    DataKeyNames="Id" EnableMultiSelect="false" ShowPagingMessage="true" AllowPaging="true" IsDatabasePaging="true"
                    OnRowCommand="GridDpt_RowCommand" AllowSorting="true" SortField="Id" SortDirection="asc" OnSort="GridDpt_Sort">
                    <Toolbars>
                        <f:Toolbar ID="Toolbar1" Position="Top" runat="server">
                            <Items>
                                <f:DropDownList runat="server" ID="drpSearch" AutoPostBack="true" OnSelectedIndexChanged="drpSearch_SelectedIndexChanged" Label="任务状态" Width="200" LabelWidth="100">
                                    <f:ListItem Text="全部" Value="" />
                                    <f:ListItem Text="已审核" Value="已审核" />
                                    <f:ListItem Text="待审核" Value="待审核" />
                                </f:DropDownList>
                            </Items>
                            <Items>
                                <f:TextBox runat="server" ID="txtValue" Label="任务名称"></f:TextBox>
                            </Items>
                            <Items>
                                <f:Button runat="server" ID="btnSelect" Text="查询" Icon="Zoom" OnClick="btnSelect_Click"></f:Button>
                                <f:Button runat="server" ID="btnReg" Text="刷新" Icon="Reload" OnClick="btnReg_Click"></f:Button>
                            </Items>
                            <Items>
                                <f:ToolbarFill ID="ToolbarFill1" runat="server">
                                </f:ToolbarFill>
                                <f:Button ID="btnLook" runat="server" Icon="ReportWord" Text="查看上报" OnClick="btnLook_Click">
                                </f:Button>
                                <f:Button ID="btnNew" runat="server" Icon="Add" Text="添加任务" OnClick="btnNew_Click">
                                </f:Button>
                            </Items>
                        </f:Toolbar>
                    </Toolbars>
                    <Columns>
                        <f:RowNumberField EnablePagingNumber="true" />
                        <f:BoundField DataField="TaskLevel" HeaderText="级别" ColumnID="TaskLevel" />
                        <f:BoundField DataField="Title" HeaderText="即时任务" ExpandUnusedSpace="true" />
                        <f:BoundField DataField="SavaPeo" HeaderText="发布人" />
                        <f:BoundField DataField="SaveTime" HeaderText="发布时间" />
                        <f:BoundField DataField="LockTime" HeaderText="截止日期" />

                        <f:BoundField DataField="IsCheck" HeaderText="状态" />


                        <f:LinkButtonField ColumnID="checkField" TextAlign="Center" ConfirmTarget="Top" CommandName="Check" Width="80px" HeaderText="审核" ConfirmText="确定进行审核操作？" />

                        <f:LinkButtonField ColumnID="editField" TextAlign="Center" ConfirmTarget="Top" CommandName="Edit" Width="80px" HeaderText="编辑" />
                        <f:LinkButtonField ColumnID="deleteField" TextAlign="Center" Icon="Delete" ConfirmText="确定删除该条信息？" ConfirmTarget="Top" CommandName="Delete" Width="50px" HeaderText="删除" />
                    </Columns>
                </f:Grid>
            </Items>
        </f:Panel>

        <f:Window ID="Window1" Hidden="true" EnableIFrame="true" runat="server" OnClose="Window1_Close"
            EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="870px" Title="编辑任务"
            Height="600px">
        </f:Window>
        <f:Window ID="Window2" Hidden="true" EnableIFrame="true" runat="server"  
            EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="900px"  
            Height="600px">
        </f:Window>
    </form>
</body>
</html>
